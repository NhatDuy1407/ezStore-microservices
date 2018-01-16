using System;
using MassTransit;

namespace RKSystem.Service.Core
{
    public abstract class RequestClient<IRequest, IResponse>
    {
        readonly string _rabbitMqHost;

        public RequestClient(string rabbitMQHost)
        {
            _rabbitMqHost = rabbitMQHost;
        }

        public IBusControl CreateBus()
        {
            return Bus.Factory.CreateUsingRabbitMq(x => {
                x.Host(new Uri(_rabbitMqHost), h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });

            });
        }

        public abstract IRequestClient<IRequest, IResponse> CreateRequestClient(IBusControl busControl);
    }
}
