using System.Threading.Tasks;
using MassTransit;

namespace RKSystem.UserService.WriteSide
{
    public class UserRequestConsumer : IConsumer<object>
    {
        public async Task Consume(ConsumeContext<object> context)
        {
            //context.Respond(new CalculationResponse
            //{
            //    result = context.Message.a + context.Message.b
            //});
        }
    }
}
