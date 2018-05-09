using Microservice.Core.DataAccess.Entities;
using Microservice.Service.UserService.Models;

namespace Microservice.Service.UserService.Entities
{
    public class AppRole: BaseGuidEntity<AppRoleDto>
    {
        public string Name { get; set; }

        protected override void UpdateDomain(AppRoleDto data, string userId)
        {
            this.Name = data.Name;
        }
    }
}