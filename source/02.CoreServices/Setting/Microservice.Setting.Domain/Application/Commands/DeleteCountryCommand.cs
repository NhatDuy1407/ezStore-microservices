using Microservice.Core.DomainService.Commands;
using System;

namespace Microservice.Setting.Domain.Application.Commands
{
    public class DeleteCountryCommand : ValidationDecoratorCommand
    {
        public string Id { get; set; }

        public DeleteCountryCommand(string id)
        {
            this.Id = id;
        }
        public override bool SelfValidate()
        {
            return true;
        }
    }
}
