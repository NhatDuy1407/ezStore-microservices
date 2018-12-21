﻿using MassTransit;
using Ws4vn.Microservices.ApplicationCore.Events;
using Ws4vn.Microservices.ApplicationCore.SharedKernel;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;

namespace Ws4vn.Microservices.Infrastructure.RabbitMQ
{
    public class BaseConsumer
    {
        protected void WriteErrorLog<T>(ConsumeContext<T> context, IConfiguration Configuration, string message, object data) where T : class
        {
            WriteLog(context, Configuration, LogLevel.Error, message, data);
        }

        protected void WriteInformationLog<T>(ConsumeContext<T> context, IConfiguration Configuration, string message) where T : class
        {
            WriteLog(context, Configuration, LogLevel.Information, message);
        }

        private void WriteLog<T>(ConsumeContext<T> context, IConfiguration Configuration, LogLevel logLevel, string message, object data = null) where T : class
        {
            var sendEndPoint = context.GetSendEndpoint(new Uri($"{Configuration.GetConnectionString(MicroservicesConstants.MessageBusHost)}/{EventRouteConstants.LoggingService}")).Result;
            sendEndPoint.Send(new WriteLogEvent()
            {
                Level = logLevel.ToString(),
                Logger = typeof(T).FullName,
                Message = message,
                Data = data == null ? "" : JsonConvert.SerializeObject(data)
            });
        }
    }
}