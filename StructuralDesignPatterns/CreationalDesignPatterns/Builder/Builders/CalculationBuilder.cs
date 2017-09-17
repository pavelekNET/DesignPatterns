using Creational.Builder.Helpers;

namespace Creational.Builder.Builders
{
    public abstract class CalculationBuilder
    {
        protected Calculation Calculation;

        public Calculation GetCalculation()
        {
            return Calculation;
        }

        public void CreateNewCalculation()
        {
            Calculation = new Calculation();   
        }

        public abstract void BuildFinancialProduct();
        public abstract void BuildSubjectOfFinancing();

    }
}
