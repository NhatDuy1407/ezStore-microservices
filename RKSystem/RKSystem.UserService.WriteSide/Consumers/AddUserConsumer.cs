using System.Threading.Tasks;
using MassTransit;
using Microsoft.Extensions.Configuration;
using RKSystem.UserService.Models;
using RKSystem.UserService.Models.Commands;
using RKSystem.UserService.WriteSide.Interfaces;

namespace RKSystem.UserService.WriteSide.Consumers
{
    public class AddUserConsumer : BaseConsumer, IConsumer<CreateUserCommand>
    {
        IUserService _service;
        public AddUserConsumer(IConfiguration configuration, IUserService service) : base(configuration)
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
