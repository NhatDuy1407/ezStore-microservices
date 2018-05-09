using Microservice.Core.Service.Models;

namespace Microservice.Service.UserService.Models.Commands
{
    public class CreateUserCommand : Command
    {
        public AppUserDto userDto { get; set; }

        public CreateUserCommand(AppUserDto appUserDto)
        {
            this.userDto = appUserDto;
        }
    }
}
