using System;
using Structural.Decorator.Component;

namespace Structural.Decorator.ConcreteComponent
{
    public class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
