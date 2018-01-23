using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RKSystem.UserService.API.ViewModels
{
    public class UserVm
    {
        public string Password { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
    }
}
