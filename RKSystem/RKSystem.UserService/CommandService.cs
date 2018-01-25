using System;
using System.Threading.Tasks;
using MassTransit;
using MassTransit.Util;
using RKSystem.Service.Core;
using RKSystem.UserService.Models;
using RKSystem.UserService.Models.Commands;

namespace RKSystem.UserService
{
    public class CommandService : ICommandHandler<CreateUserCommand>
    {
        private readonly IBusControl _busControl;
        public CommandService()
        {
            _busControl = Bus.Factory.CreateUsingRabbitMq(x =>
            {
                x.Host(new Uri("rabbitmq://192.168.0.101"), h =>
                {
                    //h.Username("guest");
                    //h.Password("guest");
                });

            });

            TaskUtil.Await(() => _busControl.StartAsync());
        }

        public Task ExecuteAsync(CreateUserCommand command)
        {
            TaskUtil.Await(() => _busControl.StartAsync());
            var serviceAddress = new Uri("rabbitmq://192.168.0.101/user_service");
            var client = _busControl.CreateRequestClient<CreateUserCommand, ResultDto>(serviceAddress, TimeSpan.FromSeconds(500));
            client.Request(command).Wait();

            return Task.CompletedTask;
        }
    }
}
