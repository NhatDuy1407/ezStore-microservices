namespace Ws4vn.Microservicess.ApplicationCore.Commands
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

        public override string ErrorMessage()
        {
            return "The Name field should not be empty";
        }
    }
}