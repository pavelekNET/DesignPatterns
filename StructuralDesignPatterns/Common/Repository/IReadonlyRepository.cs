using System;
using System.Linq;

namespace Common.Repository
{
    public interface IReadonlyRepository<out TModel> : IDisposable
    {
        IQueryable<TModel> GetAll();
        TModel Find(int id);
    }
}
