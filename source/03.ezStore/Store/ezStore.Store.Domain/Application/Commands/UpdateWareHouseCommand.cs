using Microservice.Core.DomainService.Commands;
using System;

namespace ezStore.WareHouse.Domain.Application.Commands
{
    public class UpdateWareHouseCommand : ValidationDecoratorCommand
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public UpdateWareHouseCommand(Guid id, string name) : base(new NameValidatorCommand(name))
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
