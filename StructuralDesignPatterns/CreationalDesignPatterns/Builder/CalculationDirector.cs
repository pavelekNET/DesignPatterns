using Creational.Builder.Builders;
using Creational.Builder.ConcreteBuilders;
using Creational.Builder.Helpers;

namespace Creational.Builder
{
    public class CalculationDirector
    {
        private readonly CalculationBuilder _builder;

        public CalculationDirector(CalculationBuilder builder)
        {
            _builder = builder;
        }

        public void BuildCalculation()
        {
            _builder.CreateNewCalculation();
            _builder.BuildFinancialProduct();
            _builder.BuildSubjectOfFinancing();

            if (_builder is IndividualizedCalculationBuilder individualizedBuilder)
            {
                individualizedBuilder.BuildFinancialIndividualization();
                individualizedBuilder.BuildInsuranceIndividualization();
            }
        }

        public Calculation GetCalculation()
        {
            return _builder.GetCalculation();
        }
    }
}
