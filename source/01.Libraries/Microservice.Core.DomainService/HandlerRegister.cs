using Microservice.Core.DomainService.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Reflection;

namespace Microservice.Core.DomainService
{
    public static class HandlerRegister
    {
        public static void Register(Assembly assembly, IServiceCollection services)
        {
            var allCommandHandler = assembly.GetTypes().Where(t =>
                t.IsClass &&
                !t.IsAbstract &&
                t.IsAssignableToGenericType(typeof(ICommandHandler<>)));
            foreach (var type in allCommandHandler)
            {
                var allInterfaces = type.GetInterfaces();
                var mainInterfaces = allInterfaces.Where(t => t.IsAssignableToGenericType(typeof(ICommandHandler<>)));
                foreach (var itype in mainInterfaces)
                {
                    services.AddTransient(itype, type);
                }
            }

            var allIQuery = assembly.GetTypes().Where(t =>
                t.IsClass &&
                !t.IsAbstract && t.FullName.EndsWith("Queries")).ToList();
            foreach (var typeIQuery in allIQuery)
            {
                var allInterfaces = typeIQuery.GetInterfaces().ToList();
                foreach (var itype in allInterfaces)
                {
                    services.AddTransient(itype, typeIQuery);
                }
            }
        }
    }
}
