using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Repository
{
    public class MappingRepository<TModel, TPersistence, TDbContext> : IRepository<TModel>
    {
        private TDbContext _dbContext;

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IQueryable<TModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public TModel Find(int id)
        {
            throw new NotImplementedException();
        }

        public void Add(TModel obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(TModel obj)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
