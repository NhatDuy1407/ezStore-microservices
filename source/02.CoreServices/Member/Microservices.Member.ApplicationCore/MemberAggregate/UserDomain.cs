using Ws4vn.Microservicess.ApplicationCore.Entities;
using Ws4vn.Microservicess.ApplicationCore.Interfaces;
using Microservices.Member.ApplicationCore.Entities;

namespace Microservices.Member.Domain.MemberAggregate
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