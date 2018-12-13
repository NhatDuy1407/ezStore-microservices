using System;
using System.Net.Mail;

namespace Ws4vn.Microservices.ApplicationCore.Commands
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
            try
            {
                var mail = new MailAddress(Email);
                if (string.IsNullOrEmpty(mail.Address))
                {
                    return false;
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}