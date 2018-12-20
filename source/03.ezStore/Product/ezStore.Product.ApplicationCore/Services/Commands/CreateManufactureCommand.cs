using Ws4vn.Microservices.ApplicationCore.Commands;

namespace ezStore.Product.ApplicationCore.Services.Commands
{
    public class CreateManufactureCommand : ValidationDecoratorCommand
    {
        public string Name { get; set; }

        public CreateManufactureCommand(string name)
        {
            Name = name;
        }

        public override bool SelfValidate()
        {
            return true;
        }
    }
}
