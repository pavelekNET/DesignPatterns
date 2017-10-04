using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Repository
{
    public interface IRepository<TModel> : IReadonlyRepository<TModel>
    {
        void Add(TModel obj);
        void Delete(TModel obj);
        void SaveChanges();
    }
}
