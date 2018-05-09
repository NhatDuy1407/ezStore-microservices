using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microservice.Core.Service.Interfaces;

namespace Microservice.Core.Service
{
    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        Task ExecuteAsync(TCommand command);
    }
}
