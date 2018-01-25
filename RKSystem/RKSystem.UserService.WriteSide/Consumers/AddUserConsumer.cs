using System.Threading.Tasks;
using MassTransit;
using RKSystem.CacheService.Interfaces;
using RKSystem.UserService.Models;
using RKSystem.UserService.Models.Commands;
using RKSystem.UserService.WriteSide.Interfaces;

namespace RKSystem.UserService.WriteSide.Consumers
{
    public class AddUserConsumer : IConsumer<CreateUserCommand>
    {
        public async Task Consume(ConsumeContext<CreateUserCommand> context)
        {
            IUserService service = new UserService();
            var newId = service.Add(context.Message.userDto);

            // write to cache for special data
            ICacheService cacheService = new CacheService.CacheService();
            await cacheService.Set(context.Message.CommandId, newId);

            // todo: publish event 
            //context.Publish(new UserCreatedEvent(newId));

            context.Respond(new ResultDto { Status = true });
        }
    }
}
