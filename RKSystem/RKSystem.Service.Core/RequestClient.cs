using System;
using System.IO;
using MassTransit;
using Microsoft.Extensions.Configuration;

namespace RKSystem.Service.Core
{
    public class RequestClient : RabbitMQRequestClient<object, object>
    {
        public RequestClient()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            var configuration = builder.Build();
            _rabbitMqHost = configuration["ConnectionStrings:RabbitMQHost"];
            _service = configuration["ConnectionStrings:ServiceAddress"];
        }

        protected override string _rabbitMqHost { get; }
        protected string _service { get; }

        public override IRequestClient<object, object> CreateRequestClient(IBusControl busControl)
        {
            var serviceAddress = new Uri(_service);

            IRequestClient<object, object> client = busControl.CreateRequestClient<object, object>(serviceAddress, TimeSpan.FromSeconds(500));
            return client;
        }
    }
}
