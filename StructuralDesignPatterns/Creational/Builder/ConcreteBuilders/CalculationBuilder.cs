using Creational.Builder.Builders;
using Creational.Builder.Helpers;

namespace Creational.Builder.ConcreteBuilders
{
    public class NormalCalculationBuilder : CalculationBuilder
    {
        public override void BuildFinancialProduct()
        {
            Calculation.FinancialProduct = new FinancialProduct()
            {
              Description  = "Some text",
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
    }
}
