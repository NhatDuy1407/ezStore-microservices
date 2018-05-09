using System.Threading.Tasks;
using MassTransit;
using Microservice.Service.UserService.Models;
using Microservice.Service.UserService.Models.Commands;
using Microsoft.Extensions.Configuration;
using Microservice.Service.UserService.WriteSide.Interfaces;

namespace Microservice.Service.UserService.WriteSide.Consumers
{
    public class AddUserConsumer : BaseConsumer, IConsumer<CreateUserCommand>
    {
        readonly IWriteUserService _service;
        public AddUserConsumer(IConfiguration configuration, IWriteUserService service) : base(configuration)
        {
            _service = service;
        }

        public async Task Consume(ConsumeContext<CreateUserCommand> context)
        {
            var newId = _service.Add(context.Message.userDto);

            await WriteCacheAsync(context.Message.CommandId, newId);

            // context.Publish(new UserCreatedEvent(newId));

            context.Respond(new ResultDto { Status = true });
        }
    }
}
