﻿using Microservice.Core.DomainService.Commands;
using System;

namespace Microservice.Setting.Domain.Application.Commands
{
    public class UpdateCountryCommand : ValidationDecoratorCommand
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string IsoCode { get; set; }

        public int DisplayOrder { get; set; }

        public bool Published { get; set; }

        public UpdateCountryCommand(string id, string name) : base(new NameValidatorCommand(name))
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
