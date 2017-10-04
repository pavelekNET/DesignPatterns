using Commons.Repository.Persisted;

namespace Commons.Repository.Converters
{
    public class CalculationConverter : IModelConverter<Models.Calculation, Persisted.Calculation>
    {
        public Calculation ToPersisted(Models.Calculation obj)
        {
            throw new System.NotImplementedException();
        }

        public Models.Calculation ToModel(Calculation obj)
        {
            throw new System.NotImplementedException();
        }

        public void CopyChanges(Models.Calculation pairKey, Calculation pairValue)
        {
            throw new System.NotImplementedException();
        }
    }
}
