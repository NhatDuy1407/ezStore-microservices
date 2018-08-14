using MassTransit;
using Microservice.SharedEvents.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace Microservice.Core.Logging
{
    public class MicroserviceLogging : ILogger
    {
        private readonly IBusControl _busControl;
        private readonly string CategoryName;
        private IConfiguration Configuration;

        public MicroserviceLogging(string categoryName, IConfiguration configuration, IBusControl busControl)
        {
            CategoryName = categoryName;
            _busControl = busControl;
            Configuration = configuration;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return new NoopDisposable();
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            var logNamespaces = Configuration.GetSection("Logging")[Constants.LoggingNamespaces];
            if (logNamespaces != null)
            {
                var logNamespacesArr = logNamespaces.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(i => i + ".").ToList();
                return logNamespacesArr.Any(i => CategoryName.StartsWith(i));
            }
            return false;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (!IsEnabled(logLevel))
            {
                return;
            }

            string message = "";
            if (formatter != null)
            {
                message = formatter(state, exception);
            }

            var sendEndPoint = _busControl.GetSendEndpoint(new Uri(Configuration.GetConnectionString(Constants.RabbitMQHost) + "/logging_service")).Result;
            sendEndPoint.Send(new WriteLogEvent()
            {
                Level = logLevel.ToString(),
                Logger = CategoryName,
                Thread = eventId.ToString(),
                Message = message
            });
        }

        private class NoopDisposable : IDisposable
        {
            public void Dispose()
            {
            }
        }
    }
}
