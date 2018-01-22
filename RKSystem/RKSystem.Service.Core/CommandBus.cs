using System;
using System.Threading.Tasks;
using RKSystem.Service.Core.Interfaces;

namespace RKSystem.Service.Core
{
    public class CommandBus : ICommandBus
    {
        public Task ExecuteAsync<TCommand>(TCommand command) where TCommand : ICommand
        {
            if (command == null)
                throw new ArgumentNullException("command");

            //1.Validate the report object.
            
            //2.Convert the command into an event.
            
            //Emit the event on a message queue.
            //var requestClient = new RequestClient();
            //var busControl = requestClient.CreateBus();

            //TaskUtil.Await(() => busControl.StartAsync());
            //requestClient.CreateRequestClient(busControl);
            //var client = requestClient.CreateRequestClient(busControl);
            //var respone = client.Request(command);

            return Task.FromResult(true);
        }
    }
}
