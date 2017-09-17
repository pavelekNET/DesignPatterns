using System;
using System.Net.Http;
using Structural.Decorator.Component;

namespace Structural.Decorator.ConcreteComponent
{
    public class HttpLogger : ILogger
    {
        private readonly Uri _logUrl;

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
