namespace Creational.Builder.Builders
{
    public abstract class CalculationIndividualizationBuilder : CalculationBuilder
    {
        public abstract void BuildFinancialIndividualization();

        public abstract void BuildInsuranceIndividualization();
    }
}
