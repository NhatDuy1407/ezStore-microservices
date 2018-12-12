namespace Microservices.ApplicationCore.Commands
{
    public class MaxLengthValidatorCommand : ValidationDecoratorCommand
    {
        public int MaxLength { get; }
        public string Name { get; }

        public MaxLengthValidatorCommand(string name, int maxLength)
        {
            Name = name;
            MaxLength = maxLength;
        }

        public override bool SelfValidate()
        {
            return !string.IsNullOrEmpty(Name) && Name.Length <= MaxLength;
        }

        public override string ErrorMessage()
        {
            return $"'{Name}' should be smaller than {MaxLength} charaters";
        }
    }
}