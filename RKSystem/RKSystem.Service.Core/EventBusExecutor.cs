using System.Threading.Tasks;
using RKSystem.Service.Core.Interfaces;

namespace RKSystem.Service.Core
{
    public class EventBusExecutor : IEventBusExecutor
    {
        IEventHandlerExecutor EventHandlerExecutor { get; }

        public EventBusExecutor(IEventHandlerExecutor eventHandlerExecutor)
        {
            EventHandlerExecutor = eventHandlerExecutor;
        }

        public async Task ExecuteAsync(IEvent @event)
        {
            var eventType = @event.GetType();
            var executorType = EventHandlerExecutor.GetType();

            await (Task)executorType.GetMethod(nameof(IEventBusExecutor.ExecuteAsync))
                .MakeGenericMethod(eventType)
                .Invoke(EventHandlerExecutor, new[] { @event });
        }
    }
}
