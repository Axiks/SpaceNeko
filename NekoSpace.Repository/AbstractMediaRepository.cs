using Arch.EntityFrameworkCore;
using MapsterMapper;
using NekoSpace.Data;
using NekoSpace.Data.Contracts.Entities.Base;
using NekoSpace.ElasticSearch;
using NekoSpace.ElasticSearch.Contracts;
using NekoSpace.Repository.Contracts.Interfaces;
using NekoSpace.Repository.Contracts.Models;
using System.Linq.Expressions;

namespace NekoSpace.Repository;

public class AbstractMediaRepository<T, E> : IMediaRepository<T>, IInterconnectionExtensions where T : MediaEntity where E : ElasticSearchMediaBasicModel
{
    private ApplicationDbContext _dbcontext;
    private AbstractElasticSearchRepository<E> _esrepository;
    private IMapper _mapper;

    public AbstractMediaRepository(ApplicationDbContext dbcontext, AbstractElasticSearchRepository<E> esrepository, IMapper mapper)
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

    public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
    {
        return _dbcontext.Set<T>().Where(expression);
    }

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