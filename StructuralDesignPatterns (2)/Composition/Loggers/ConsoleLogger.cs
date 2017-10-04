using System;
using Structural.Decorator.Component;

namespace Structural.Composition.Loggers
{
    public class ConsoleLogger : ILogger
    {
        private int _messageBuffer;
        private const int MessageBufferMultiplier = 4;

        public int MessageBuffer
        {
            get => _messageBuffer;
            set => _messageBuffer = value * MessageBufferMultiplier;
        }

        public void Log(string message)
        {
            _messageBuffer--;
            Console.WriteLine(message);
        }
    }
}
