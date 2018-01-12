using RKSystem.DataAccess.Entities;

namespace RKSystem.UserService.Models
{
    public class AppUserDto: BaseGuidModel
    {
        public string Password { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
    }
}
