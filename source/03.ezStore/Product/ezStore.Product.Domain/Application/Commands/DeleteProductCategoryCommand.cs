using Microservice.Core.DomainService.Commands;
using System;

namespace ezStore.Product.Domain.Application.Commands
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
