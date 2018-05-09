using System;
using System.Threading.Tasks;
using MassTransit;
using MassTransit.Util;
using Microsoft.Extensions.Configuration;
using Microservice.Service.UserService.Models;
using Microservice.Service.UserService.Models.Commands;
using Microservice.Core.Service;

namespace Microservice.Service.UserService
{
    public class CommandUserService : ICommandHandler<CreateUserCommand>
    {
        private readonly IBusControl _busControl;
        private readonly IConfiguration _configuration;
        public CommandUserService(IBusControl busControl, IConfiguration configuration)
        {
            _busControl = busControl;
            _configuration = configuration;
        }

        public Task ExecuteAsync(CreateUserCommand command)
        {
            //TaskUtil.Await(() => _busControl.StartAsync());
            var serviceAddress = GetServiceAddress("user_service");
            var client = _busControl.CreateRequestClient<CreateUserCommand, ResultDto>(serviceAddress, TimeSpan.FromSeconds(500));
            client.Request(command).Wait();
            //TaskUtil.Await(() => _busControl.StopAsync());

            return Task.CompletedTask;
        }

        private Uri GetServiceAddress(string address)
        {
            var serviceAddress = new Uri(_configuration.GetConnectionString("RabbitMQHost") + "/" + address);
            return serviceAddress;
        }
    }
}
