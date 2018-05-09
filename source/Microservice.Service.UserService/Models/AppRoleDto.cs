using Microservice.Core.DataAccess.Entities;

namespace Microservice.Service.UserService.Models
{
    public class AppRoleDto: BaseGuidModel
    {
        public string Name { get; set; }
    }
}
