using MassTransit;
using Microservice.SharedEvents;
using Microservice.SharedEvents.Logging;
using Microservice.SharedEvents.Notification;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
            var logNamespaces = Configuration.GetSection(Constants.Logging)[Constants.LoggingNamespaces];
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

            var sendEndPoint = _busControl.GetSendEndpoint(new Uri(Configuration.GetConnectionString(Constants.RabbitMQHost) + $"/{EventRouteConstants.LoggingService}")).Result;
            sendEndPoint.Send(new WriteLogEvent()
            {
                Level = logLevel.ToString(),
                Logger = CategoryName,
                Thread = eventId.ToString(),
                Message = logLevel != LogLevel.Error ? message : string.Format(Configuration.GetSection(Constants.Notification)[Constants.ErrorEmailSubject], exception.Message),
                Data = state.ToString(),
                StackTrace = exception == null ? "" : exception.StackTrace,
            });

            if (logLevel == LogLevel.Error || exception != null)
            {
                var sendNotificationEndPoint = _busControl.GetSendEndpoint(new Uri(Configuration.GetConnectionString(Constants.RabbitMQHost) + $"/{EventRouteConstants.NotificationService}")).Result;
                sendNotificationEndPoint.Send(new EmailContentCreated()
                {
                    From = Configuration.GetSection(Constants.Notification)[Constants.SystemEmail],
                    To = Configuration.GetSection(Constants.Notification)[Constants.AdminEmail],
                    Subject = string.Format(Configuration.GetSection(Constants.Notification)[Constants.ErrorEmailSubject], exception.Message),
                    Body = $"Data:{message}, Trace:{exception.StackTrace}",
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
