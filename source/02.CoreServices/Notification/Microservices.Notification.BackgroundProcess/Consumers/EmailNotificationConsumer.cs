using MassTransit;
using Ws4vn.Microservicess.ApplicationCore.Events;
using Ws4vn.Microservicess.ApplicationCore.SharedKernel;
using Ws4vn.Microservicess.Infrastructure.Events;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Microservices.Notification.BackgroundProcess.Consumers
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
            var sendEndPoint = context.GetSendEndpoint(new System.Uri($"{Configuration.GetConnectionString(MicroservicesConstants.RabbitMQHost)}/{EventRouteConstants.LoggingService}")).Result;
            try
            {
                var userName = Configuration.GetSection(MicroservicesConstants.SmtpSettings)[MicroservicesConstants.SmtpUserName];
                var password = Configuration.GetSection(MicroservicesConstants.SmtpSettings)[MicroservicesConstants.SmtpPassword];
                var address = Configuration.GetSection(MicroservicesConstants.SmtpSettings)[MicroservicesConstants.SmtpAddress];
                var port = Configuration.GetSection(MicroservicesConstants.SmtpSettings)[MicroservicesConstants.SmtpPort];
                var enableSsl = Configuration.GetSection(MicroservicesConstants.SmtpSettings)[MicroservicesConstants.SmtpEnableSsl];

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