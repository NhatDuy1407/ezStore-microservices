﻿using Ws4vn.Microservices.ApplicationCore.Commands;
using System;

namespace ezStore.Product.ApplicationCore.Services.Commands
{
    public class UpdateManufactureCommand : ValidationDecoratorCommand
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public UpdateManufactureCommand(Guid id, string name) : base(new NameValidatorCommand(name))
        {
            this.Id = id;
            this.Name = name;
        }

        public override bool SelfValidate()
        {
            return true;
        }
    }
}
