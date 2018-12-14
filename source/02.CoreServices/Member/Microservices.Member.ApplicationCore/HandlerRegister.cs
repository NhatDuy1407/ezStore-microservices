using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Microservices.Member.ApplicationCore
{
    public static class HandlerRegister
    {
        public static void Register(IServiceCollection services)
        {
            Ws4vn.Microservicess.ApplicationCore.SharedKernel.HandlerRegister.Register(Assembly.GetExecutingAssembly(), services);
        }
    }
}
