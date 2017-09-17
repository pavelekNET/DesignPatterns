using Creational.Builder.Builders;
using Creational.Builder.ConcreteBuilders;

namespace Creational.Builder
{
    public class Client
    {
        public static void Main()
        {
            var isIndividualized = true;

            CalculationBuilder builder;
            if (isIndividualized)
            {
                builder = new IndividualizedCalculationBuilder();
            }
            else
            {
                builder = new NormalCalculationBuilder();
            }

            var director = new CalculationDirector(builder);
            director.BuildCalculation();
            var calc = director.GetCalculation();
        }
    }
}
