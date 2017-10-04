using System.Diagnostics;
using Structural.Decorator.Component;

namespace Structural.Decorator.ConcreteComponent
{
    public class OutputLogger : ILogger
    {
        public void Log(string message)
        {
            Debug.WriteLine(message);
        }
    }
}
