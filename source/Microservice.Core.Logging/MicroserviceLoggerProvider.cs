using MassTransit;
using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;

namespace Microservice.Core.Logging
{
    public class MicroserviceLoggerProvider : ILoggerProvider
    {
        private readonly IBusControl _busControl;
        private readonly ConcurrentDictionary<string, MicroserviceLogging> _loggers = new ConcurrentDictionary<string, MicroserviceLogging>();

        public MicroserviceLoggerProvider(IBusControl busControl)
        {
            _busControl = busControl;
        }

        public ILogger CreateLogger(string categoryName)
        {
            return new MicroserviceLogging(categoryName, _busControl);
        }

        public void Dispose()
        {
            _loggers.Clear();
        }
    }
}
