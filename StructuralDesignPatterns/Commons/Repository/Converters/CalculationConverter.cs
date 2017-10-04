namespace Commons.Repository.Converters
{
    public class CalculationConverter : IModelConverter<Models.Calculation, Persisted.Calculation>
    {
        private readonly IModelConverter<Models.FinancialProduct, Persisted.FinancialProduct> _financialProductConverter;

        public CalculationConverter(IModelConverter<Models.FinancialProduct, Persisted.FinancialProduct> financialProductConverter)
        {
            _financialProductConverter = financialProductConverter;
        }

        public Persisted.Calculation ToPersisted(Models.Calculation obj)
        {
            var persisted = new Persisted.Calculation()
            {
                Label = obj.Label,
                FinancialProduct = _financialProductConverter.ToPersisted(obj.FinancialProduct)
            };

            return persisted;
        }

        public Models.Calculation ToModel(Persisted.Calculation obj)
        {
            var model = new Models.Calculation(
                obj.Label,
                _financialProductConverter.ToModel(obj.FinancialProduct
                ));

            return model;
        }

        public void CopyChanges(Models.Calculation from, Persisted.Calculation to)
        {
            // primitive types
            to.Label = from.Label;

            // complex types
            _financialProductConverter.CopyChanges(from.FinancialProduct, to.FinancialProduct);
        }
    }
}
