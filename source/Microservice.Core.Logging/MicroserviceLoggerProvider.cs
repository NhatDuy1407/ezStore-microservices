using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;

namespace Microservice.Core.Logging
{
    public class MicroserviceLoggerProvider : ILoggerProvider
    {
        private readonly IBusControl _busControl;
        private IConfiguration Configuration;
        private readonly ConcurrentDictionary<string, MicroserviceLogging> _loggers = new ConcurrentDictionary<string, MicroserviceLogging>();

        public MicroserviceLoggerProvider(IBusControl busControl, IConfiguration configuration)
        {
            _busControl = busControl;
            Configuration = configuration;
        }

        public ILogger CreateLogger(string categoryName)
        {
            return new MicroserviceLogging(categoryName, Configuration, _busControl);
        }

        public void Dispose()
        {
            _loggers.Clear();
        }
    }
}
