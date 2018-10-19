using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using MassTransit;
using Microservice.Core;
using Microservice.Core.MessageQueue;
using Microservice.SharedEvents;
using Microservice.SharedEvents.Logging;
using Microservice.SharedEvents.Notification;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Microservice.Notification.BackgroundProcess.Consumers
{
    public class EmailNotificationConsumer : BaseConsumer, IConsumer<EmailContentCreated>
    {
        private readonly IConfiguration Configuration;

        public EmailNotificationConsumer(IConfiguration configuration) : base()
        {
            Configuration = configuration;
        }

        public Task Consume(ConsumeContext<EmailContentCreated> context)
        {
            var sendEndPoint = context.GetSendEndpoint(new System.Uri($"{Configuration.GetConnectionString(Constants.RabbitMQHost)}/{EventRouteConstants.LoggingService}")).Result;
            try
            {
                var userName = Configuration.GetSection(Constants.SmtpSettings)[Constants.SmtpUserName];
                var password = Configuration.GetSection(Constants.SmtpSettings)[Constants.SmtpPassword];
                var address = Configuration.GetSection(Constants.SmtpSettings)[Constants.SmtpAddress];
                var port = Configuration.GetSection(Constants.SmtpSettings)[Constants.SmtpPort];
                var enableSsl = Configuration.GetSection(Constants.SmtpSettings)[Constants.SmtpEnableSsl];

                var client = new SmtpClient(address, int.Parse(port))
                {
                    Credentials = new NetworkCredential(userName, password),
                    EnableSsl = bool.Parse(enableSsl)
                };
                client.Send(context.Message.From, context.Message.To, context.Message.Subject, context.Message.Body);

                sendEndPoint.Send(new WriteLogEvent()
                {
                    Level = LogLevel.Information.ToString(),
                    Logger = typeof(EmailNotificationConsumer).FullName,
                    Message = "Email was sent!",
                    Thread = ""
                });
            }
            catch (System.Exception ex)
            {
                sendEndPoint.Send(new WriteLogEvent()
                {
                    Level = LogLevel.Error.ToString(),
                    Logger = typeof(EmailNotificationConsumer).FullName,
                    Message = $"Failure sending mail. {ex.Message} {ex.InnerException.Message}",
                    Thread = "",
                    Data = JsonConvert.SerializeObject(context.Message)
                });
                throw;
            }

            context.Respond(new { Status = true });
            return Task.CompletedTask;
        }
    }
}