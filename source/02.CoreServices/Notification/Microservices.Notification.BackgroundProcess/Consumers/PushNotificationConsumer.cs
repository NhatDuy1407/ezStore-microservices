using MassTransit;
using Ws4vn.Microservicess.ApplicationCore.Events;
using Ws4vn.Microservicess.Infrastructure.Events;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace Microservices.Notification.BackgroundProcess.Consumers
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