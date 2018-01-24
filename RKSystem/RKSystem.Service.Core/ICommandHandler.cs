using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RKSystem.Service.Core.Interfaces;

namespace RKSystem.Service.Core
{
    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        Task ExecuteAsync(TCommand command);
    }
}
