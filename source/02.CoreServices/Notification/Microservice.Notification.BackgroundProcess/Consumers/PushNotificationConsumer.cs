using MassTransit;
using Microservice.ApplicationEvents.Notification;
using Microservice.Core.MessageQueue;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace Microservice.Notification.BackgroundProcess.Consumers
{
    public class PushNotificationConsumer : BaseConsumer, IConsumer<PushNotificationContentCreated>
    {

        public PushNotificationConsumer(IConfiguration configuration) : base()
        {
        }

        public Task Consume(ConsumeContext<PushNotificationContentCreated> context)
        {
            // implement PushNotification with a online service. E.g: OneSignal
            context.Respond(new { Status = true });
            return Task.CompletedTask;
        }
    }
}