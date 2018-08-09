﻿using Microservice.Core;

namespace Microservice.IdentityServer.Application.Commands
{
    public class UpdateUserLoginCommand : ValidationDecoratorCommand
    {
        public string Email { get; }

        public UpdateUserLoginCommand(string email) : base(new EmailValidatorCommand(email))
        {
            this.Email = email;
        }

        public override bool SelfValidate()
        {
            return true;
        }
    }
}