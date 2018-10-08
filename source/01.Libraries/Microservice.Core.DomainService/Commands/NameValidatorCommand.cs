namespace Microservice.Core.DomainService.Commands
{
    public class NameValidatorCommand : ValidationDecoratorCommand
    {
        public string Name { get; }

        public NameValidatorCommand(string name)
        {
            this.Name = name;
        }

        public override bool SelfValidate()
        {
            return !string.IsNullOrEmpty(Name);
        }
    }
}