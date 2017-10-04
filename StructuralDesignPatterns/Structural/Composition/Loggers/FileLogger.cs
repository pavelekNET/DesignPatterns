using System.IO;
using System.Text;
using Structural.Decorator.Component;

namespace Structural.Composition.Loggers
{
    public class FileLogger : ILogger
    {
        private readonly FileInfo _file;
        private int _messageBuffer;
        private const int MessageBufferMultiplier = 2;

        public int MessageBuffer
        {
            get => _messageBuffer;
            set => _messageBuffer = value * MessageBufferMultiplier;
        }

        public FileLogger(string logFilePath)
        {
            _file = new FileInfo(logFilePath);
        }

        public void Log(string message)
        {
            _messageBuffer--;
            var byteMessage = Encoding.UTF8.GetBytes(message);
            using (var stream = _file.OpenWrite())
            {
                stream.WriteAsync(byteMessage, 0, byteMessage.Length);
            }
        }
    }
}
