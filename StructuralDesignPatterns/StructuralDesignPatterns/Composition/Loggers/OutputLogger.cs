using System.Diagnostics;
using Structural.Decorator.Component;

namespace Structural.Composition.Loggers
{
    public class OutputLogger : ILogger
    {
        private int _messageBuffer;
        private const int MessageBufferMultiplier = 10;

        public int MessageBuffer
        {
            get => _messageBuffer;
            set => _messageBuffer = value * MessageBufferMultiplier;
        }

        public void Log(string message)
        {
            _messageBuffer--;
            Debug.WriteLine(message);
        }
    }
}
