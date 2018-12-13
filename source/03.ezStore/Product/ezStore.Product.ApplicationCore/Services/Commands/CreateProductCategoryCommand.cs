using Ws4vn.Microservices.ApplicationCore.Commands;

namespace ezStore.Product.ApplicationCore.Services.Commands
{
    public class CreateProductCategoryCommand : ValidationDecoratorCommand
    {
        public string Name { get; set; }

        public CreateProductCategoryCommand(string name) : base(new NameValidatorCommand(name))
        {
            this.Name = name;
        }

        public override bool SelfValidate()
        {
            return true;
        }
    }
}
