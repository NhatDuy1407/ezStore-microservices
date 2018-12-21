using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Ws4vn.Microservices.ApplicationCore.Interfaces;

namespace Ws4vn.Microservices.Infrastructure.Loggings
{
    public class MicroservicesLoggerProvider : ILoggerProvider
    {
        private readonly IMessageBus _messageBus;
        private readonly IConfiguration Configuration;

        public MicroservicesLoggerProvider(IMessageBus messageBus, IConfiguration configuration)
        {
            _messageBus = messageBus;
            Configuration = configuration;
        }

        public ILogger CreateLogger(string categoryName)
        {
            return new MicroservicesLogging(categoryName, Configuration, _messageBus);
        }

        public void Dispose()
        {
        }
    }
}
