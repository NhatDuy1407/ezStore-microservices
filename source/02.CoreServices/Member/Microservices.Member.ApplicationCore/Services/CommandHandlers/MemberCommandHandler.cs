using Microservices.Member.Domain.MemberAggregate;
using Ws4vn.Microservicess.ApplicationCore.Interfaces;
using System.Threading.Tasks;

namespace Microservices.Member.Domain.Application.Commands
{
    public class MemberCommandHandler : ICommandHandler<UpdateUserLoginCommand>
    {
        private readonly IDomainService _domainService;

        public MemberCommandHandler(IDomainService domainService)
        {
            _domainService = domainService;
        }

        public Task ExecuteAsync(UpdateUserLoginCommand command)
        {
            var user = new UserDomain(_domainService.WriteService) { Username = command.Email };
            user.Login();
            _domainService.ApplyChanges(user);
            return Task.CompletedTask;
        }
    }
}