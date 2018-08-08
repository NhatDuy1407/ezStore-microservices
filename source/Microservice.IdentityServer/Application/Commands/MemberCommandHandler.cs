using System.Threading.Tasks;
using Microservice.Core;
using Microservice.Core.DataAccess.Interfaces;
using Microservice.Member.Domain.MemberAggregate;

namespace Microservice.IdentityServer.Application.Commands
{
    public class MemberCommandHandler : ICommandHandler<UpdateUserLoginCommand>
    {
        private readonly IDomainService _service;

        public MemberCommandHandler(IDomainService service)
        {
            _service = service;
        }

        public Task ExecuteAsync(UpdateUserLoginCommand command)
        {
            var user = new UserDomain { Username = command.Email };
            user.Login();
            _service.Repository<UserDomain>().Save(user);
            _service.SaveChanges();
            return Task.CompletedTask;
        }
    }
}