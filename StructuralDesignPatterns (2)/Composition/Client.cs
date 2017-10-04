using System;
using Structural.Composition.Loggers;

namespace Structural.Composition
{
    public class Client
    {
        public static void Main()
        {
            var fileLogger = new FileLogger("c:\\path");
            var httpLogger = new HttpLogger(new Uri("www.idnes.cz/logs"));
            var outputLogger = new OutputLogger();

            var multiLogger = new CompositeLogger(fileLogger, httpLogger, outputLogger)
            {
                MessageBuffer = 50
            };

            multiLogger.Log("LOG FOR MULTIPLE LOGGERS");
        }
    }
}
