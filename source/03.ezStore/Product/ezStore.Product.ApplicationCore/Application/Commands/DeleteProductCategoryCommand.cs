using Microservices.ApplicationCore.Commands;
using System;

namespace ezStore.Product.ApplicationCore.Application.Commands
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
