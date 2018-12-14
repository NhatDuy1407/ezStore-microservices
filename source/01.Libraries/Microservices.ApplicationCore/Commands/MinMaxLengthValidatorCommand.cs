namespace Ws4vn.Microservicess.ApplicationCore.Commands
{
    public class MinMaxLengthValidatorCommand : ValidationDecoratorCommand
    {
        public int MinLength { get; }
        public int MaxLength { get; }
        public string Name { get; }

        public MinMaxLengthValidatorCommand(string name, int maxLength, int minLength = 0)
        {
            Name = name;
            MinLength = minLength;
            MaxLength = maxLength;
        }

        public override bool SelfValidate()
        {
            return !string.IsNullOrEmpty(Name) && Name.Length >= MinLength && Name.Length <= MaxLength;
        }

        public override string ErrorMessage()
        {
            return $"Field Name='{Name}' should be at least {MinLength} character(s) and smaller than {MaxLength} charaters";
        }
    }
}