namespace Ws4vn.Microservices.ApplicationCore.Commands
{
    public class MinLengthValidatorCommand : ValidationDecoratorCommand
    {
        public int MinLength { get; }
        public string Name { get; }

        public MinLengthValidatorCommand(string name, int minLength = 0)
        {
            Name = name;
            MinLength = minLength;
        }

        public override bool SelfValidate()
        {
            return !string.IsNullOrEmpty(Name) && Name.Length >= MinLength;
        }

        public override string ErrorMessage()
        {
            return $"'{Name}' should be at least {MinLength} character(s)";
        }
    }
}