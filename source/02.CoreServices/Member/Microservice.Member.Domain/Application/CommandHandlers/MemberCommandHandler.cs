using System.Threading.Tasks;
using Microservice.Core.DataAccess.Interfaces;
using Microservice.Core.DomainService;
using Microservice.Core.DomainService.Interfaces;
using Microservice.Member.Domain.MemberAggregate;

namespace Microservice.Member.Domain.Application.Commands
{
    public class MemberCommandHandler : ICommandHandler<UpdateUserLoginCommand>
    {
        private readonly IDomainService _domainService;
        private readonly IDataAccessWriteService _writeService;

        public MemberCommandHandler(IDomainService domainService, IDataAccessWriteService writeService)
        {
            _domainService = domainService;
            _writeService = writeService;
        }

        public Task ExecuteAsync(UpdateUserLoginCommand command)
        {
            var user = new UserDomain(_writeService) { Username = command.Email };
            user.Login();
            _domainService.ApplyChanges(user);
            _domainService.SaveChanges();
            return Task.CompletedTask;
        }
    }
}