using System.Collections.Generic;
using System.Linq;
using Structural.Decorator.Component;

namespace Structural.Composition.Loggers
{
    public class CompositeLogger : ILogger
    {
        private readonly List<ILogger> _loggers;

        public CompositeLogger()
        {
            _loggers = new List<ILogger>();
        }

        public CompositeLogger(params ILogger[] loggers) : this()
        {
            _loggers.AddRange(loggers);
        }

        public int MessageBuffer
        {
            get => _loggers.Sum(l => l.MessageBuffer);
            set => _loggers.ForEach(l => l.MessageBuffer += value / _loggers.Count);
        }

        public void Log(string message)
        {
            foreach (var logger in _loggers)
            {
                logger.Log(message);
            }  
        }

        public void Add(ILogger logger)
        {
            _loggers.Add(logger);
        }
    }
}
