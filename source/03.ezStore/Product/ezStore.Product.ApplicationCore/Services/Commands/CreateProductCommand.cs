using Ws4vn.Microservices.ApplicationCore.Commands;

namespace ezStore.Product.ApplicationCore.Services.Commands
{
    public class CreateProductCommand : ValidationDecoratorCommand
    {
        public string Name { get; set; }

        public CreateProductCommand(string name)
        {
            Name = name;
        }

        public override bool SelfValidate()
        {
            return true;
        }
    }
}
