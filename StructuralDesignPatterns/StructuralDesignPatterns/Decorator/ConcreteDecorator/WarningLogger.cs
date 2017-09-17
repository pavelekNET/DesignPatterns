using Structural.Decorator.Component;
using Structural.Decorator.Decorator;

namespace Structural.Decorator.ConcreteDecorator
{
    public class WarningLogger : LoggerDecorator
    {
        private readonly ILogger _logger;

        public WarningLogger(ILogger logger) : base(logger)
        {
            _logger = logger;
        }

        public override void Log(string message)
        {
            message = "WARNING: " + message;
            base.Log(message);
        }
    }
}
