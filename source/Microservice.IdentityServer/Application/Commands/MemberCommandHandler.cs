using System.Threading.Tasks;
using Microservice.Core.DataAccess.Interfaces;
using Microservice.Core.Service;
using Microservice.Member.Domain.MemberAggregate;

namespace Microservice.IdentityServer.Application.Commands
{
    public class MemberCommandHandler : ICommandHandler<UpdateUserLoginCommand>
    {
        private readonly IAttachEntityWriteService _writeService;

        public MemberCommandHandler(IAttachEntityWriteService writeService)
        {
            _writeService = writeService;
        }

        public Task ExecuteAsync(UpdateUserLoginCommand command)
        {
            var user = new User { UserName = command.Email };
            user.NotifyUserLogin();
            _writeService.AttachEntity(user);
            _writeService.SaveChanges();
            return Task.CompletedTask;
        }
    }
}