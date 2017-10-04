using Structural.Decorator.Component;
using Structural.Decorator.Decorator;

namespace Structural.Decorator.ConcreteDecorator
{
    public class UpperCaseLoggerDecorator : LoggerDecorator
    {
        public UpperCaseLoggerDecorator(ILogger logger) : base(logger)
        {
        }

        public override void Log(string message)
        {
            base.Log(message.ToUpper());
        }
    }
}
