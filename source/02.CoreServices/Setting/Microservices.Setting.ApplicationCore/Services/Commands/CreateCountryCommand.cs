using Ws4vn.Microservicess.ApplicationCore.Commands;

namespace Microservices.Setting.ApplicationCore.Services.Commands
{
    public class CreateCountryCommand : ValidationDecoratorCommand
    {
        public string Name { get; set; }

        public string IsoCode { get; set; }

        public int DisplayOrder { get; set; }

        public bool Published { get; set; }

        public CreateCountryCommand(string name) : base(new NameValidatorCommand(name))
        {
            this.Name = name;
        }

        public override bool SelfValidate()
        {
            return true;
        }
    }
}
