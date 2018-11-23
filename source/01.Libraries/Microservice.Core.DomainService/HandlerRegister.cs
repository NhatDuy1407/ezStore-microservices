using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Reflection;
using Ws4vn.Core;

namespace Microservice.Core.DomainService
{
    public static class HandlerRegister
    {
        public static void Register(Assembly assembly, IServiceCollection services)
        {
            var allICommandHandler = assembly.GetTypes().Where(t =>
                t.GetTypeInfo().IsClass &&
                !t.GetTypeInfo().IsAbstract &&
                t.IsAssignableToGenericType(typeof(ICommandHandler<>)));
            foreach (var type in allICommandHandler)
            {
                var allInterfaces = type.GetInterfaces();
                var mainInterfaces = allInterfaces.Where(t => t.IsAssignableToGenericType(typeof(ICommandHandler<>)));
                foreach (var itype in mainInterfaces)
                {
                    services.AddTransient(itype, type);
                }
            }
        }
    }
}
