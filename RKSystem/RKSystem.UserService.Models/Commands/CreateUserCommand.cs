using RKSystem.Service.Core.Models;

namespace RKSystem.UserService.Models.Commands
{
    public class CreateUserCommand : Command
    {
        private AppUserDto userDto { get; }

        public CreateUserCommand(AppUserDto appUserDto)
        {
            this.userDto = appUserDto;
        }
    }
}
