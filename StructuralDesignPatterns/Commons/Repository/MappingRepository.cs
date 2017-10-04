using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace Commons.Repository
{
    public class MappingRepository<TModel, TPersistence, TDbContext> : IRepository<TModel>
        where TDbContext: DbContext
        where TPersistence: class 
    {
        private readonly TDbContext _dbContext;
        private readonly Func<TDbContext, DbSet<TPersistence>> _getDbSet;
        private readonly IDictionary<TModel, TPersistence> _materializedObjects;
        private bool _isDisposed;

        private Action EnsureNotDisposed { get; set; } = () => { };
        private DbSet<TPersistence> DbSet => _getDbSet(_dbContext);

        public MappingRepository(
            Func<TDbContext> dbContextFactory,
            Func<TDbContext, DbSet<TPersistence>> getDbSet)
        {
            if(dbContextFactory == null) throw new ArgumentNullException(nameof(dbContextFactory));
            if (getDbSet == null) throw new ArgumentNullException(nameof(dbContextFactory));

            _isDisposed = false;
            _dbContext = dbContextFactory();
            _getDbSet = getDbSet;
            _materializedObjects = new Dictionary<TModel, TPersistence>();
        }

        public IQueryable<TModel> GetAll()
        {
            return DbSet.ProjectTo<TModel>();
        }

        public TModel Find(int id)
        {
            EnsureNotDisposed();

            var persisted = DbSet.Find(id);
            var model = Mapper.Map<TModel>(persisted);
            _materializedObjects[model] = persisted;

            return model;
        }

        public void Add(TModel obj)
        {
            EnsureNotDisposed();
            if (obj == null) throw new ArgumentNullException(nameof(obj));

            var persisted = Mapper.Map<TPersistence>(obj);
            DbSet.Add(persisted);
            _materializedObjects[obj] = persisted;
        }

        public void Delete(TModel obj)
        {
            EnsureNotDisposed();
            if (obj == null) throw new ArgumentNullException(nameof(obj));
            if (!_materializedObjects.ContainsKey(obj)) throw new ArgumentException(nameof(obj));

            var persisted = Mapper.Map<TPersistence>(obj);
            DbSet.Remove(persisted);
            _materializedObjects.Remove(obj);
        }

        public void SaveChanges()
        {
            EnsureNotDisposed();
            foreach (var pair in _materializedObjects)
            {
                Mapper.Map(pair.Key, pair.Value);
            }

            _dbContext.SaveChanges();
        }


        public void Dispose()
        {
           Dispose(true);
           GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (_isDisposed || !disposing)
                return;

            _dbContext.Dispose();
            EnsureNotDisposed = () => throw new ObjectDisposedException("repository");
            _isDisposed = true;
        }

        ~MappingRepository()
        {
            Dispose(false);
        }
    }
}
