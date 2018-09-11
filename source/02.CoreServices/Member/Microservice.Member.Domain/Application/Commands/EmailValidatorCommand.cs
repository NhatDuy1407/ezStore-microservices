using Microservice.Core;
using Microservice.Core.DomainService;

namespace Microservice.Member.Domain.Application.Commands
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