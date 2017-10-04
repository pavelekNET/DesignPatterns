using Structural.Decorator.Component;

namespace Structural.Decorator.Decorator
{
    public abstract class LoggerDecorator : ILogger
    {
        private readonly ILogger _logger;

        protected LoggerDecorator(ILogger logger)
        {
            _logger = logger;
        }

        public virtual void Log(string message)
        {
            _logger.Log(message);
        }
    }
}
