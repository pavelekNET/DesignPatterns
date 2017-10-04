namespace Commons.Repository
{
    public interface IModelConverter<TModel, TPersistence>
    {
        TPersistence ToPersisted(TModel obj);
        TModel ToModel(TPersistence obj);
        void CopyChanges(TModel from, TPersistence to);
    }
}