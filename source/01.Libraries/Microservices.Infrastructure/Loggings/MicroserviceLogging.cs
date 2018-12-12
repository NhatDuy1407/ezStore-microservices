using MassTransit;
using Microservices.ApplicationCore.Events;
using Microservices.ApplicationCore.Exceptions;
using Microservices.ApplicationCore.SharedKernel;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace Microservices.Infrastructure.Loggings
{
    public class MicroserviceLogging : ILogger
    {
        private readonly IBusControl _busControl;
        private readonly string CategoryName;
        private readonly IConfiguration Configuration;

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
            var logNamespaces = Configuration.GetSection(MicroserviceConstants.Logging)[MicroserviceConstants.LoggingNamespaces];
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

            var sendEndPoint = _busControl.GetSendEndpoint(new Uri(Configuration.GetConnectionString(MicroserviceConstants.RabbitMQHost) + $"/{EventRouteConstants.LoggingService}")).Result;
            sendEndPoint.Send(new WriteLogEvent()
            {
                Level = logLevel.ToString(),
                Logger = CategoryName,
                Thread = eventId.ToString(),
                Message = logLevel != LogLevel.Error ?
                    message :
                    string.Format(Configuration.GetSection(MicroserviceConstants.Notification)[MicroserviceConstants.ErrorEmailSubject], exception?.Message),
                Data = state.ToString(),
                StackTrace = exception?.StackTrace,
                ExceptionTypeName = exception?.GetType().Name
            });

            if ((logLevel == LogLevel.Error || logLevel == LogLevel.Critical) && exception != null && !(exception is ValidationErrorException))
            {
                var sendNotificationEndPoint = _busControl.GetSendEndpoint(new Uri(Configuration.GetConnectionString(MicroserviceConstants.RabbitMQHost) + $"/{EventRouteConstants.NotificationService}")).Result;
                sendNotificationEndPoint.Send(new EmailContentCreated()
                {
                    From = Configuration.GetSection(MicroserviceConstants.Notification)[MicroserviceConstants.SystemEmail],
                    To = Configuration.GetSection(MicroserviceConstants.Notification)[MicroserviceConstants.AdminEmail],
                    Subject = string.Format(Configuration.GetSection(MicroserviceConstants.Notification)[MicroserviceConstants.ErrorEmailSubject], exception?.Message.Replace("\n"," ")),
                    Body = $"Data:{message}, Trace:{exception?.StackTrace}",
                });
            }
        }

        private class NoopDisposable : IDisposable
        {
            public void Dispose()
            {
            }
        }
    }
}
