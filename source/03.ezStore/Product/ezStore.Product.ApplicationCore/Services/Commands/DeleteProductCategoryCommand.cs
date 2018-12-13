using Microservices.ApplicationCore.Commands;
using System;

namespace ezStore.Product.ApplicationCore.Services.Commands
{
    public class DeleteProductCategoryCommand : ValidationDecoratorCommand
    {
        public Guid Id { get; set; }

        public DeleteProductCategoryCommand(Guid id)
        {
            this.Id = id;
        }
        public override bool SelfValidate()
        {
            return true;
        }
    }
}
