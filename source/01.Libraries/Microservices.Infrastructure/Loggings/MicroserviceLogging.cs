﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using Ws4vn.Microservices.ApplicationCore.Events;
using Ws4vn.Microservices.ApplicationCore.Exceptions;
using Ws4vn.Microservices.ApplicationCore.Interfaces;
using Ws4vn.Microservices.ApplicationCore.SharedKernel;

namespace Ws4vn.Microservices.Infrastructure.Loggings
{
    public class MicroservicesLogging : ILogger
    {
        private readonly IMessageBus _messageBus;
        private readonly string CategoryName;
        private readonly IConfiguration Configuration;

        public MicroservicesLogging(string categoryName, IConfiguration configuration, IMessageBus messageBus)
        {
            CategoryName = categoryName;
            _messageBus = messageBus;
            Configuration = configuration;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return new NoopDisposable();
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            var logNamespaces = Configuration.GetSection(MicroservicesConstants.Logging)[MicroservicesConstants.LoggingNamespaces];
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

            _messageBus.Send(EventRouteConstants.LoggingService, new WriteLogEvent()
            {
                Level = logLevel.ToString(),
                Logger = CategoryName,
                Thread = eventId.ToString(),
                Message = logLevel != LogLevel.Error ?
                    message :
                    string.Format(Configuration.GetSection(MicroservicesConstants.Notification)[MicroservicesConstants.ErrorEmailSubject], exception?.Message),
                Data = state.ToString(),
                StackTrace = exception?.StackTrace,
                ExceptionTypeName = exception?.GetType().Name
            });

            if ((logLevel == LogLevel.Error || logLevel == LogLevel.Critical) && exception != null && !(exception is ValidationErrorException))
            {
                _messageBus.Send(EventRouteConstants.NotificationService, new EmailContentCreated()
                {
                    From = Configuration.GetSection(MicroservicesConstants.Notification)[MicroservicesConstants.SystemEmail],
                    To = Configuration.GetSection(MicroservicesConstants.Notification)[MicroservicesConstants.AdminEmail],
                    Subject = string.Format(Configuration.GetSection(MicroservicesConstants.Notification)[MicroservicesConstants.ErrorEmailSubject], exception?.Message.Replace("\n"," ")),
                    Body = $"Data:{message}, Trace:{exception?.StackTrace}",
                });
            }
        }

        private class NoopDisposable : IDisposable
        {
            public void Dispose()
            {
                // do nothing now
            }
        }
    }
}
