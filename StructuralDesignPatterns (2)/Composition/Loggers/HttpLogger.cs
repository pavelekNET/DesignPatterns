using System;
using System.Net.Http;
using Structural.Decorator.Component;

namespace Structural.Composition.Loggers
{
    public class HttpLogger : ILogger
    {
        private readonly Uri _logUrl;
        private int _messageBuffer;
        private const int MessageBufferMultiplier = 1;

        public int MessageBuffer
        {
            get => _messageBuffer;
            set => _messageBuffer = value * MessageBufferMultiplier;
        }

        public HttpLogger(Uri logUrl)
        {
            _logUrl = logUrl;
        }

        public async void Log(string message)
        {
            using (var client = new HttpClient())
            {
                await client.PostAsync(_logUrl, new StringContent(message));
            }
        }
    }
}
