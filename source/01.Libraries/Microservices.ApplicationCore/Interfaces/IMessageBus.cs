using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ws4vn.Microservices.ApplicationCore.Interfaces
{
    public interface IMessageBus
    {
        Task Send<T>(string channel, T message, CancellationToken cancellationToken = default(CancellationToken)) where T : class;

        Task Send<T>(string channel, T message, Type messageType, CancellationToken cancellationToken = default(CancellationToken)) where T : class;

        Task Publish<T>(T message, Type messageType, CancellationToken cancellationToken = default(CancellationToken)) where T : class;
    }
}
