using MassTransit;
using Microservice.DomainEvents;
using Microservice.DomainEvents.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Microservice.Core.MessageQueue
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

        protected void WriteLog<T>(ConsumeContext<T> context, IConfiguration Configuration, LogLevel logLevel, string message, object data = null) where T : class
        {
            var sendEndPoint = context.GetSendEndpoint(new System.Uri(Configuration.GetConnectionString(MicroserviceConstants.RabbitMQHost) + "/" + EventRouteConstants.LoggingService)).Result;
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