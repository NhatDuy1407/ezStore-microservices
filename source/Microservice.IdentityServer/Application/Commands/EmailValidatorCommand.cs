using Microservice.Core;

namespace Microservice.IdentityServer.Application.Commands
{
    public class EmailValidatorCommand : ValidationDecoratorCommand
    {
        public string Email { get; }

        public EmailValidatorCommand(string email)
        {
            this.Email = email;
        }

        public override bool SelfValidate()
        {
            return !string.IsNullOrEmpty(Email);
        }
    }
}