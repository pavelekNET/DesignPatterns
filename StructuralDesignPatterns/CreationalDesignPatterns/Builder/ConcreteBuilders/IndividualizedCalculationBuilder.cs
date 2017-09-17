using Creational.Builder.Builders;
using Creational.Builder.Helpers;

namespace Creational.Builder.ConcreteBuilders
{
    public class IndividualizedCalculationBuilder : CalculationIndividualizationBuilder
    {
        public override void BuildFinancialProduct()
        {
            Calculation.FinancialProduct = new FinancialProduct()
            {
                Description = "Some text",
                PriceWithVat = 1000,
                PriceWitoutVat = 800
            };
        }

        public override void BuildSubjectOfFinancing()
        {
            Calculation.SubjectOfFinancing = new SubjectOfFinancing()
            {
                CommodityKind = "Osobní automobil",
                CommodityModel = "M4",
                CommodityType = "BMW"
            };
        }

        public override void BuildFinancialIndividualization()
        {
            Calculation.FinancialIndividualization = new FinancialIndividualization()
            {
                Amount = 500
            };
        }

        public override void BuildInsuranceIndividualization()
        {
            Calculation.InsuranceIndividualization = new InsuranceIndividualization()
            {
                Amount = 3213
            };
        }
    }
}
