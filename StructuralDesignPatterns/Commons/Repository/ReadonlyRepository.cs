using System;
using System.Data.Entity;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace Commons.Repository
{
    public class ReadonlyRepository<TModel, TPersistence, TDbContext> : IReadonlyRepository<TModel>
        where TDbContext : DbContext
        where TPersistence : Persisted.PersistentObject
    {
        private bool _isDisposed;
        private readonly Func<TDbContext, DbSet<TPersistence>> _getDbSet;
        private TDbContext _dbContext;
        private Action EnsureNotDisposed { get; set; } = () => { };

        private IQueryable<TPersistence> NonTrackingQuery => _getDbSet(_dbContext).AsNoTracking<TPersistence>();
        private IQueryable<TModel> NonTrackingModelQuery => NonTrackingQuery.ProjectTo<TModel>();

        public ReadonlyRepository(Func<TDbContext> dbContextFactory, Func<TDbContext, DbSet<TPersistence>> getDbSet)
        {
            if (dbContextFactory == null) throw new ArgumentNullException(nameof(dbContextFactory));
            if (getDbSet == null) throw new ArgumentNullException(nameof(dbContextFactory));
            _getDbSet = getDbSet;

            _isDisposed = false;
        }

        public IQueryable<TModel> GetAll()
        {
            EnsureNotDisposed();
            return NonTrackingModelQuery;
        }

        public TModel Find(int id)
        {
            EnsureNotDisposed();
            var persisted = NonTrackingQuery.Single(p => p.Id == id);
            var model = Mapper.Map<TModel>(persisted);
            return model;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_isDisposed || !disposing)
                return;

            _dbContext.Dispose();
            EnsureNotDisposed = () => throw new ObjectDisposedException("repository");
            _isDisposed = true;
        }

        ~ReadonlyRepository()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
