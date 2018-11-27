using Microservice.Core.DomainService.Commands;

namespace ezStore.WareHouse.Domain.Application.Commands
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
