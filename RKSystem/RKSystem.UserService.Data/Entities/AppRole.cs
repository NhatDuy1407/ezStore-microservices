using RKSystem.DataAccess.MongoDB.Entities;
using RKSystem.UserService.Models;

namespace RKSystem.UserService.Data.Entities
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