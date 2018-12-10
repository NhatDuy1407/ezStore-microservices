using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Microservice.Setting.ApplicationCore
{
    public static class HandlerRegister
    {
        public static void Register(IServiceCollection services)
        {
            Core.DomainService.HandlerRegister.Register(Assembly.GetExecutingAssembly(), services);
        }
    }
}
