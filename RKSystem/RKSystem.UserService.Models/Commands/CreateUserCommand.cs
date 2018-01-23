using RKSystem.Service.Core.Models;

namespace RKSystem.UserService.Models.Commands
{
    public class CreateUserCommand : Command
    {
        public AppUserDto userDto { get; }

        public CreateUserCommand(AppUserDto appUserDto)
        {
            this.userDto = appUserDto;
        }
    }
}
