using System;
using Microservice.Core.DomainService.Interfaces;

namespace Microservice.Core.DomainService
{
    public abstract class ValidationDecoratorCommand : ICommand
    {
        private ValidationDecoratorCommand _root { get; set; }

        public Guid CommandId { get; set; }

        public ValidationDecoratorCommand(ValidationDecoratorCommand root)
        {
            _root = root;
            CommandId = Guid.NewGuid();
        }

        public ValidationDecoratorCommand()
        {
            CommandId = Guid.NewGuid();
        }

        public virtual bool Validate()
        {
            return (_root == null ? true : _root.Validate()) && SelfValidate();
        }

        public abstract bool SelfValidate();
    }
}