using System.Threading.Tasks;
using MassTransit;
using RKSystem.UserService.Models;
using RKSystem.UserService.Models.Commands;
using RKSystem.UserService.Models.Events;
using RKSystem.UserService.WriteSide.Interfaces;

namespace RKSystem.UserService.WriteSide.Consumers
{
    public class AddUserConsumer : BaseConsumer, IConsumer<CreateUserCommand>
    {
        public async Task Consume(ConsumeContext<CreateUserCommand> context)
        {
            IUserService service = new UserService();
            var newId = service.Add(context.Message.userDto);

            await WriteCacheAsync(context.Message.CommandId, newId);

            context.Publish(new UserCreatedEvent(newId));

            context.Respond(new ResultDto { Status = true });
        }
    }
}
