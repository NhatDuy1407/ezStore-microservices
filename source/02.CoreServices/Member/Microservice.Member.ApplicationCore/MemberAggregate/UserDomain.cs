using Microservice.Core.DomainService.Models;
using Microservice.DataAccess.Core.Interfaces;
using Microservice.Member.ApplicationCore.Entities;

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