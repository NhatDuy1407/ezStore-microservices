using Microservices.ApplicationCore.Commands;

namespace ezStore.WareHouse.ApplicationCore.Services.Commands
{
    public class CreateWareHouseCommand : ValidationDecoratorCommand
    {
        public string Name { get; set; }

        public CreateWareHouseCommand(string name) : base(new NameValidatorCommand(name), new MinMaxLengthValidatorCommand(name, 50))
        {
            this.Name = name;
        }

        public override bool SelfValidate()
        {
            return true;
        }
    }
}
