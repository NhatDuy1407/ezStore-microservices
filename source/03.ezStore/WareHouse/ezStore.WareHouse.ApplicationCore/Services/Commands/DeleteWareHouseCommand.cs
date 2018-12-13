using Microservices.ApplicationCore.Commands;
using System;

namespace ezStore.WareHouse.ApplicationCore.Services.Commands
{
    public class DeleteWareHouseCommand : ValidationDecoratorCommand
    {
        public Guid Id { get; set; }

        public DeleteWareHouseCommand(Guid id)
        {
            this.Id = id;
        }
        public override bool SelfValidate()
        {
            return true;
        }
    }
}
