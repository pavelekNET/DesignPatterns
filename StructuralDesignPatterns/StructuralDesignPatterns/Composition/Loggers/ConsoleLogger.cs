using System;
using Structural.Decorator.Component;

namespace Structural.Composition.Loggers
{
    public class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
