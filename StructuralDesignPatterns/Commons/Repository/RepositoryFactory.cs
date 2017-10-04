using AutoMapper;

namespace Commons.Repository
{
    public static class RepositoryFactory
    {
        static RepositoryFactory()
        {
            Mapper.Initialize(SetupMapping);
        }

        private static void SetupMapping(IMapperConfigurationExpression configuration)
        {
            //configuration.CreateMap<>();
        }

        public static IReadonlyRepository<Models.FinancialProduct> CreateFinancialProductReadonlyRepository() =>
            new ReadonlyRepository<Models.FinancialProduct, Persisted.FinancialProduct, CalculationModuleDbContext>(
                 () => new CalculationModuleDbContext(), (dbContext) => dbContext.FinancialProducts);

        public static IReadonlyRepository<Models.Calculation> CreateCalculationRepository() =>
            new ReadonlyRepository<Models.Calculation, Persisted.Calculation, CalculationModuleDbContext>(
                () => new CalculationModuleDbContext(), (dbContext) => dbContext.Calculations);
    }
}
