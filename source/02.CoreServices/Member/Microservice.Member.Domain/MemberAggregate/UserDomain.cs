using Microservice.Core.DomainService.Models;
using Microservice.Member.Infrastructure.Models;
using Microservice.DataAccess.Core.Interfaces;

namespace Microservice.Member.Domain.MemberAggregate
{
    public class UserDomain : AggregateRoot
    {
        public UserDomain(IDataAccessService dataAccessService) : base(dataAccessService)
        {
        }

        public string Username { get; set; }

        public void Login()
        {
            dataAccessService.Repository<UserLog>().Insert(new UserLog() { Content = Username + " loged in." });
        }
    }
}