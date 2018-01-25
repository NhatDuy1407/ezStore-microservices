using System;
using System.Threading.Tasks;
using MassTransit;
using MassTransit.Util;
using RKSystem.Service.Core;
using RKSystem.UserService.Models;
using RKSystem.UserService.Models.Commands;

namespace RKSystem.UserService
{
    public class CommandUserService : ICommandHandler<CreateUserCommand>
    {
        private readonly IBusControl _busControl;
        private readonly string _serviceAddress;
        public CommandUserService(string rabbitMqHost, string serviceAddress)
        {
            _serviceAddress = serviceAddress;
            _busControl = Bus.Factory.CreateUsingRabbitMq(x =>
            {
                x.Host(new Uri(rabbitMqHost), h =>
                {
                    //h.Username("guest");
                    //h.Password("guest");
                });
            });
        }

        public Task ExecuteAsync(CreateUserCommand command)
        {
            TaskUtil.Await(() => _busControl.StartAsync());
            var serviceAddress = new Uri(_serviceAddress);
            var client = _busControl.CreateRequestClient<CreateUserCommand, ResultDto>(serviceAddress, TimeSpan.FromSeconds(500));
            client.Request(command).Wait();
            TaskUtil.Await(() => _busControl.StopAsync());

            return Task.CompletedTask;
        }
    }
}
