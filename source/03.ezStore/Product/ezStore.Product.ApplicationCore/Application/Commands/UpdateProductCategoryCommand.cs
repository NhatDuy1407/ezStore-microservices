using Microservices.ApplicationCore.Commands;
using System;

namespace ezStore.Product.ApplicationCore.Application.Commands
{
    public class UpdateProductCategoryCommand : ValidationDecoratorCommand
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public UpdateProductCategoryCommand(Guid id, string name) : base(new NameValidatorCommand(name))
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
