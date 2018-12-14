using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Ws4vn.Microservicess.Infrastructure.Loggings
{
    public class MicroservicesLoggerProvider : ILoggerProvider
    {
        private readonly IBusControl _busControl;
        private readonly IConfiguration Configuration;

        public MicroservicesLoggerProvider(IBusControl busControl, IConfiguration configuration)
        {
            _busControl = busControl;
            Configuration = configuration;
        }

        public ILogger CreateLogger(string categoryName)
        {
            return new MicroservicesLogging(categoryName, Configuration, _busControl);
        }

        public void Dispose()
        {
        }
    }
}
