using System.Threading.Tasks;
using Microservice.Core.DataAccess.Interfaces;
using Microservice.Core.DomainService;
using Microservice.Core.DomainService.Interfaces;
using Microservice.Member.Domain.MemberAggregate;

namespace Microservice.Member.Domain.Application.Commands
{
    public class MemberCommandHandler : ICommandHandler<UpdateUserLoginCommand>
    {
        private readonly IDomainService _service;
        private readonly IWriteService _writeService;

        public MemberCommandHandler(IDomainService service, IWriteService writeService)
        {
            _service = service;
            _writeService = writeService;
        }

        public Task ExecuteAsync(UpdateUserLoginCommand command)
        {
            var user = new UserDomain(_writeService) { Username = command.Email };
            user.Login();
            _service.Repository<UserDomain>().Save(user);
            _service.SaveChanges();
            return Task.CompletedTask;
        }
    }
}