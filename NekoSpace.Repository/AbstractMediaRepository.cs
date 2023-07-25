using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using NekoSpace.Data;
using NekoSpace.Data.Contracts.Entities.Base;
using NekoSpace.ElasticSearch;
using NekoSpace.ElasticSearch.Contracts;
using NekoSpace.ElasticSearch.Contracts.Interfaces;
using NekoSpace.Repository.Contracts.Interfaces;
using NekoSpace.Repository.Contracts.Models;
using Nest;
using System.Linq.Expressions;

namespace NekoSpace.Repository;

public class AbstractMediaRepository<T, E> : IMediaRepository<T, E>, IInterconnectionExtensions where T : MediaEntity where E : ElasticSearchMediaBasicModel
{
    private ApplicationDbContext _dbcontext;
    private IElasticSearchRepository<E> _esrepository;
    private IMapper _mapper;

    public AbstractMediaRepository(ApplicationDbContext dbcontext, IElasticSearchRepository<E> esrepository, IMapper mapper)
    {
        _dbcontext = dbcontext;
        _esrepository = esrepository;
        _mapper = mapper;
    }

    public async void Add(T mediaEntity)
    {
        //DatabaseSection
        var entityMediaObj = _dbcontext.Set<T>().Add(mediaEntity).Entity;
        _dbcontext.SaveChanges();

        //ES section
        var edMediaModel = _mapper.Map<E>(entityMediaObj);
        await _esrepository.AddAsync(edMediaModel);
    }

    public void AddRange(List<T> mediaEntityCollection)
    {
        var entityMediaEntity = _dbcontext.Set<T>();
        var esItemList = new List<E>();

        foreach (var mediaEntity in mediaEntityCollection)
        {
            var entityMediaObj = entityMediaEntity.Add(mediaEntity).Entity;

            //ES section
            var edMediaModel = _mapper.Map<E>(entityMediaObj);
            esItemList.Add(edMediaModel);
        }
        _esrepository.AddManyAsync(esItemList);

        _dbcontext.SaveChanges();
    }
    public ISearchResponse<E> FindInElasticSearch(ElasticSearchQueryParameters elasticSearchQueryParameters)
    {
        var resAsync = _esrepository.SearchAsync(elasticSearchQueryParameters);
        resAsync.Wait();
        var res =  resAsync.Result;
        return res;
    }

    /*public IEnumerable<T> GetByIdListFromDB(List<Guid> guids)
    {
        List<T> list;

        var mediaTable = _dbcontext.Set<T>();
        mediaTable.Select( x => x.Id.ToString().cON )

        return list;
    }*/

    public IEnumerable<T> GetAllDb()
    {
        return _dbcontext.Set<T>();
    }

    /* public ICollection<TType> FindInDb<TType>(Expression<Func<T, bool>> filter = null, Expression<Func<T, T>> returnField = null, params Expression<Func<T, object>>[] includeProperties) where TType : class
     {
         DbSet<T> dbSet = _dbcontext.Set<T>();

         IQueryable<T> query = dbSet;

         if (filter != null)
         {
             query = query.Where(filter);
         }

         if (returnField != null)
         {
             query = query.Select(returnField);
         }

         foreach (var includeProperty in includeProperties)
         {
             query = query.Include(includeProperty);
         }

         return dbSet.ToList();
     }*/

    public IEnumerable<TDest> FindInDb<TDest>(
        Expression<Func<T, bool>> filter = null,
        Expression<Func<T, TDest>> select = null,
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
        params Expression<Func<T, object>>[] includeProperties)
    {
        IQueryable<T> query = _dbcontext.Set<T>();

        foreach (var includeProperty in includeProperties)
        {
            query = query.Include(includeProperty);
        }

        if (filter != null)
        {
            query = query.Where(filter);
        }

        if (orderBy != null)
        {
            if (select == null)
                return (IEnumerable<TDest>)orderBy(query).ToList();

            return orderBy(query).Select(select).ToList();
        }
        else
        {
            if (select == null)
                return (IEnumerable<TDest>)query.ToList();

            return query.Select(select).ToList();
        }
    }


    /*   public ICollection<TType> Get<TType>(Expression<Func<T, bool>> where, Expression<Func<T, TType>> select) where TType : class
       {
           var currentEntity = _dbcontext.Set<T>();
           return currentEntity.Where(where).Select(select).ToList();
       }*/

    /*   public ICollection<TType> FindInDb<TType>(Expression<Func<T, bool>> where, Expression<Func<T, TType>> select, params Expression<Func<T, object>>[] includeProperties) where TType : class
       {
           var currentEntity = _dbcontext.Set<T>();
           var prepere =  currentEntity.Include(x => includeProperties).Where(where).Select(select);
           return prepere.ToList();
       }*/

    public Guid? FindMediaIdByAnotherService(InterconnectionLinkModel interconnectionLinkModel)
    {
        var dbSet = _dbcontext.Set<T>();

        var mediaGuid = dbSet
            .Where(x => x.AssociatedService.Any(c => c.ServiceName == interconnectionLinkModel.ServiceName))
            .Where(x => x.AssociatedService.Any(c => c.ServiceId == interconnectionLinkModel.Id))
            .Select(x => x.Id)
            .FirstOrDefault();
        return mediaGuid;
    }

    public Guid? FindMediaIdByAnotherServiceList(List<InterconnectionLinkModel> interconnectionLinkModelList)
    {
        var dbSet = _dbcontext.Set<T>();
        foreach (var link in interconnectionLinkModelList)
        {
            var mediaGuid = dbSet
            .Where(x => x.AssociatedService.Any(c => c.ServiceName == link.ServiceName))
            .Where(x => x.AssociatedService.Any(c => c.ServiceId == link.Id))
            .Select(x => x.Id)
            .FirstOrDefault();
            if(mediaGuid != null) return mediaGuid;
        }
        return null;
    }

    public Dictionary<Guid, List<InterconnectionLinkModel>> GetAllInterconnection()
    {
        var dbSet = _dbcontext.Set<T>();

        var servicsInterconnectionList = dbSet
            .Include(x => x.AssociatedService)
            .Select(x => new
            {
                x.Id,
                associatedService = x.AssociatedService.Select(y => new
                {
                    y.ServiceId,
                    y.ServiceName
                }),
            }
            ).ToList();


        var servicsInterconnectionDic = new Dictionary<Guid, List<InterconnectionLinkModel>>();
        foreach (var service in servicsInterconnectionList)
        {
            List<InterconnectionLinkModel> associatedServices = new List<InterconnectionLinkModel>();
            foreach (var link in service.associatedService)
            {
                var interconnectionLinkModel = new InterconnectionLinkModel
                {
                    Id = link.ServiceId,
                    ServiceName = link.ServiceName
                };
                associatedServices.Add(interconnectionLinkModel);
            }
            servicsInterconnectionDic.Add(service.Id, associatedServices);
    }

        return servicsInterconnectionDic;
    }

    public Dictionary<Guid, List<InterconnectionLinkModel>> GetInterconnectionFromService(string serviceName)
    {
        var dbSet = _dbcontext.Set<T>();

        var servicsInterconnectionList = dbSet
            .Select(x => new
            {
                x.Id,
                associatedService = x.AssociatedService.Select(y => new
                {
                    y.ServiceId,
                    y.ServiceName
                })
                .Where(z => z.ServiceName == serviceName)
            }
            ).ToList();


        var servicsInterconnectionDic = new Dictionary<Guid, List<InterconnectionLinkModel>>();
        foreach (var service in servicsInterconnectionList)
        {
            List<InterconnectionLinkModel> associatedServices = new List<InterconnectionLinkModel>();
            foreach (var link in service.associatedService)
            {
                var interconnectionLinkModel = new InterconnectionLinkModel
                {
                    Id = link.ServiceId,
                    ServiceName = link.ServiceName
                };
                associatedServices.Add(interconnectionLinkModel);
            }
            servicsInterconnectionDic.Add(service.Id, associatedServices);
        }

        return servicsInterconnectionDic;
    }

    public void Remove(T mediaEntity)
    {
        var entityMediaEntity = _dbcontext.Set<T>();
        entityMediaEntity.Remove(mediaEntity);

        //ES section
        var edMediaModel = _mapper.Map<E>(mediaEntity);
        _esrepository.RemoveAsync(edMediaModel);
    }

    public void RemoveRange(IEnumerable<T> mediaEntityList)
    {
        var entityMediaEntity = _dbcontext.Set<T>();
        entityMediaEntity.RemoveRange(entityMediaEntity);

        //ES section
        var edMediaModelList = _mapper.Map<List<E>>(mediaEntityList);
        _esrepository.RemoveRangeAsync(edMediaModelList);
    }

    public void Update(T mediaEntity)
    {
        var entityMediaEntity = _dbcontext.Set<T>();
        entityMediaEntity.Update(mediaEntity);

        //ES section
        var edMediaModelList = _mapper.Map<E>(mediaEntity);
        _esrepository.UpdateAsync(mediaEntity.Id, edMediaModelList);
    }
}