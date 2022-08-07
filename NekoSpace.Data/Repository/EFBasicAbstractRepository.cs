using AnimeDB;
using Microsoft.EntityFrameworkCore;
using NekoSpace.Data.Interfaces;

namespace NekoSpace.Data.Repository
{
    public abstract class EFBasicAbstractRepository<E> : IBasicRepository<E> where E : class
    {
        private readonly ApplicationDbContext _dbContext;
        //protected DbSet<E> _tableContext;

        protected EFBasicAbstractRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            //_tableContext = _dbContext.Set<E>();
        }

        public void Delete(E media)
        {
            /*using (var context = new _dbContext.Set<E>())
            {
                return context.Companies;
            }*/
            //_tableContext.Remove(media);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IQueryable<E> Find(int limit, int offset)
        {
            throw new NotImplementedException();
        }

        public IQueryable<E> GetAll(int limit, int offset)
        {
            /*var b = _dbContext.Set<E>();
            using (var bb = _dbContext.Set<E>())
            {
                var a = _dbContext.Set<E>();
                var l = a.ToList();
                _tableContext.First();
            }*/
                var tableContext = _dbContext.Set<E>();
            var aaa = tableContext.ToList();
                return tableContext;
            /*
            return b;*/

            /* using (var _tableContext = new _dbContext.Set<E>())
             {
                 //return context.Companies;
             }*/

            //return _tableContext;
        }

        public E GetByID(Guid mediaId)
        {
            //_tableContext.FirstOrDefault();
            throw new NotImplementedException();
        }

        public void Insert(E media)
        {
                var tableContext = _dbContext.Set<E>();
                tableContext.Add(media);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void Update(E media)
        {
            using (_dbContext)
            {
                var tableContext = _dbContext.Set<E>();
                tableContext.Update(media);
            }
        }
    }
}