using Ws4vn.Microservices.ApplicationCore.Entities;
using Ws4vn.Microservices.ApplicationCore.Interfaces;
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
            _dataAccessService.Repository<UserLog>().Insert(new UserLog() { Content = Username + " loged in." });
        }
    }
}