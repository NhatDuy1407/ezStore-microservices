using Ws4vn.Microservices.ApplicationCore.Commands;
using System;

namespace Microservices.Setting.ApplicationCore.Services.Commands
{
    public class DeleteCountryCommand : ValidationDecoratorCommand
    {
        public string Id { get; set; }

        public DeleteCountryCommand(string id)
        {
            this.Id = id;
        }
        public override bool SelfValidate()
        {
            return true;
        }
    }
}
