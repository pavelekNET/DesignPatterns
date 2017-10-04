namespace Commons.Repository
{
    public interface IRepository<TModel> : IReadonlyRepository<TModel>
    {
        void Add(TModel obj);
        void Delete(TModel obj);
        void SaveChanges();
    }
}
