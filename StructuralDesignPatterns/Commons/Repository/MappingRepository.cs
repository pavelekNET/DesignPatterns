using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Commons.Repository
{
    public class MappingRepository<TModel, TPersistence, TDbContext> : IRepository<TModel>
        where TDbContext: DbContext
        where TPersistence: class 
    {
        private readonly TDbContext _dbContext;
        private readonly IModelConverter<TModel, TPersistence> _converter;
        private readonly Func<TDbContext, DbSet<TPersistence>> _getDbSet;
        private readonly IDictionary<TModel, TPersistence> _materializedObjects;
        private bool _isDisposed;

        private Action EnsureNotDisposed { get; set; } = () => { };

        public MappingRepository(
            Func<TDbContext> dbContextFactory,
            IModelConverter<TModel, TPersistence> converter,
            Func<TDbContext, DbSet<TPersistence>> getDbSet)
        {
            if(dbContextFactory == null) throw new ArgumentNullException(nameof(dbContextFactory));
            if (converter == null) throw new ArgumentNullException(nameof(converter));
            if (getDbSet == null) throw new ArgumentNullException(nameof(dbContextFactory));

            _isDisposed = false;
            _dbContext = dbContextFactory();
            _converter = converter;
            _getDbSet = getDbSet;
            _materializedObjects = new Dictionary<TModel, TPersistence>();
        }

        private DbSet<TPersistence> DbSet => _getDbSet(_dbContext);

        public IQueryable<TModel> GetAll()
        {
            
        }

        public TModel Find(int id)
        {
            EnsureNotDisposed();

            var persisted = DbSet.Find(id);
            var model = _converter.ToModel(persisted);
            _materializedObjects[model] = persisted;

            return model;
        }

        public void Add(TModel obj)
        {
            EnsureNotDisposed();
            if (obj == null) throw new ArgumentNullException(nameof(obj));

            var persisted = _converter.ToPersisted(obj);
            DbSet.Add(persisted);
            _materializedObjects[obj] = persisted;
        }

        public void Delete(TModel obj)
        {
            EnsureNotDisposed();
            if (obj == null) throw new ArgumentNullException(nameof(obj));
            if (!_materializedObjects.ContainsKey(obj)) throw new ArgumentException(nameof(obj));

            var persisted = _converter.ToPersisted(obj);
            DbSet.Remove(persisted);
            _materializedObjects.Remove(obj);
        }

        public void SaveChanges()
        {
            SaveChangesAsync().Wait();
        }

        public async Task SaveChangesAsync()
        {
            EnsureNotDisposed();

            foreach (var pair in _materializedObjects)
            {
                _converter.CopyChanges(pair.Key, pair.Value);
            }

            await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
           Dispose(true);
           GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!_isDisposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }

                _isDisposed = true;
            }
        }
    }
}
