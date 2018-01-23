using System.Threading.Tasks;
using MassTransit;
using RKSystem.DataAccess.MongoDB;
using RKSystem.UserService.Models.Commands;
using RKSystem.UserService.WriteSide.Interfaces;

namespace RKSystem.UserService.WriteSide
{
    public class AddUserConsumer : IConsumer<CreateUserCommand>
    {
        public Task Consume(ConsumeContext<CreateUserCommand> context)
        {
            IUserService service = new UserService();
            service.Add(context.Message.userDto);

            return Task.CompletedTask;
        }
    }
}
