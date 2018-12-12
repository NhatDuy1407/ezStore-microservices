using Microservices.ApplicationCore.Interfaces;
using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;

namespace Microservices.ApplicationCore.Commands
{
    public abstract class ValidationDecoratorCommand : ICommand
    {
        private ValidationDecoratorCommand[] _roots { get; set; }

        public Guid CommandId { get; set; }

        protected ValidationDecoratorCommand() : this(null)
        {
        }

        protected ValidationDecoratorCommand(params ValidationDecoratorCommand[] roots)
        {
            _roots = roots;
            CommandId = Guid.NewGuid();
        }

        public virtual bool Validate(IValidationContext validationContext)
        {
            var selfValidationResult = SelfValidate();
            if (!selfValidationResult)
            {
                validationContext.AddValidationError(ErrorMessage());
            }

            ConcurrentBag<bool> bag = new ConcurrentBag<bool>();
            if (_roots != null)
            {
                Parallel.ForEach(_roots, (item) =>
                {
                    bag.Add(item.Validate(validationContext));
                });
            }


            return (_roots == null || bag.All(i => i)) && selfValidationResult;
        }

        public abstract bool SelfValidate();

        public virtual string ErrorMessage()
        {
            return string.Empty;
        }
    }
}