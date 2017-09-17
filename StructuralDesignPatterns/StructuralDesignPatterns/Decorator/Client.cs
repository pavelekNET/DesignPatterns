using Structural.Decorator.ConcreteComponent;
using Structural.Decorator.ConcreteDecorator;

namespace Structural.Decorator
{
    public class Client
    {
        public static void Main()
        {
            var logger = new OutputLogger();
            var warningLogger = new WarningLogger(logger);
            var errorLogger = new ErrorLogger(new UpperCaseLoggerDecorator(logger));

            const string message = "decorator works!";

            logger.Log(message);
            warningLogger.Log(message);
            errorLogger.Log(message);
        }
    }
}
