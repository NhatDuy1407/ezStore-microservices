using Microservice.Core.Models;

namespace Microservice.IdentityServer.Application.Commands
{
    public class UpdateUserLoginCommand : Command
    {
        private readonly string _email;
        public string Email => _email;

        public UpdateUserLoginCommand(string email)
        {
            this._email = email;
        }
    }
}