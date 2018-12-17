using Ws4vn.Microservicess.ApplicationCore.Commands;

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
