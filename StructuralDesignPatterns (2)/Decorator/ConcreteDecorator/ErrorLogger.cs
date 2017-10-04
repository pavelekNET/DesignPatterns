using Structural.Decorator.Component;
using Structural.Decorator.Decorator;

namespace Structural.Decorator.ConcreteDecorator
{
    public class ErrorLogger : LoggerDecorator
    {
        public ErrorLogger(ILogger logger) : base(logger)
        {
        }

        public override void Log(string message)
        {
            message = "ERROR:" + message;
            base.Log(message);
        }
    }
}
