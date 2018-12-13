using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Microservice.Member.ApplicationCore
{
    public static class HandlerRegister
    {
        public static void Register(IServiceCollection services)
        {
            Microservices.ApplicationCore.SharedKernel.HandlerRegister.Register(Assembly.GetExecutingAssembly(), services);
        }
    }
}
