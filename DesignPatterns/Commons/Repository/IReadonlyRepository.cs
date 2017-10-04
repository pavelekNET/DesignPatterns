using System;
using System.Linq;

namespace Commons.Repository
{
    public interface IReadonlyRepository<out TModel> : IDisposable
    {
        IQueryable<TModel> GetAll();
        TModel Find(int id);
    }
}
