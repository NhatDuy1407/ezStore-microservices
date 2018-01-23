//using System.Threading.Tasks;
//using EasyNetQ;
//using RKSystem.Service.Core.Interfaces;
//using IEventBus = RKSystem.Service.Core.Interfaces.IEventBus;

//namespace RKSystem.Service.Core
//{
//    public class EventBus : IEventBus
//    {
//        IBus Bus { get; }
//        IEventBusExecutor EventBusExecutor { get; }

//        public EventBus(IEventBusExecutor eventBusExecutor)
//        {
//            EventBusExecutor = eventBusExecutor;

//            Bus = RabbitHutch.CreateBus("host=localhost");
//            Bus.Receive(nameof(EventBus), (IEvent @event) => EventBusExecutor.ExecuteAsync(@event));
//        }

//        public async Task SendAsync<TEvent>(TEvent @event) where TEvent : class, IEvent =>
//            await Bus.SendAsync(nameof(EventBus), @event);
//    }
//}
