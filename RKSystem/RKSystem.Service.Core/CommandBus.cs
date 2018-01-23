using System;
using System.Threading.Tasks;
using MassTransit;
using MassTransit.Util;
using RKSystem.Service.Core.Interfaces;

namespace RKSystem.Service.Core
{
    public class CommandBus : ICommandBus
    {
        public Task ExecuteAsync<TCommand>(TCommand command) where TCommand : ICommand
        {
            if (command == null)
                throw new ArgumentNullException("command");

            //1.Validate the report object.

            //2.Convert the command into an event.

            //Emit the event on a message queue.
            var busControl = Bus.Factory.CreateUsingRabbitMq(x => {
                x.Host(new Uri("rabbitmq://192.168.0.101"), h =>
                {
                    //h.Username("guest");
                    //h.Password("guest");
                });

            });

            TaskUtil.Await(() => busControl.StartAsync());
            var serviceAddress = new Uri("rabbitmq://192.168.0.101/user_service");
            IRequestClient<object, object> client = busControl.CreateRequestClient<object, object>(serviceAddress, TimeSpan.FromSeconds(500));
            client.Request(command);

            return Task.FromResult(true);
        }
    }
}
