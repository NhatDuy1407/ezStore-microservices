using System;
using Microservice.Core.DomainService.Interfaces;

namespace Microservice.Core.DomainService.Commands
{
    public abstract class ValidationDecoratorCommand : ICommand
    {
        private ValidationDecoratorCommand _root { get; set; }

        public Guid CommandId { get; set; }

        protected ValidationDecoratorCommand(ValidationDecoratorCommand root)
        {
            _root = root;
            CommandId = Guid.NewGuid();
        }

        protected ValidationDecoratorCommand()
        {
            CommandId = Guid.NewGuid();
        }

        public virtual bool Validate()
        {
            return (_root == null || _root.Validate()) && SelfValidate();
        }

        public abstract bool SelfValidate();
    }
}