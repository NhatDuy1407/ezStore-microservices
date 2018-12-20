using Ws4vn.Microservices.ApplicationCore.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Reflection;
using Ws4vn.Microservices.ApplicationCore.Services;
using Microsoft.Extensions.Configuration;
using MassTransit;
using Ws4vn.Microservices.ApplicationCore;
using Ws4vn.Microservices.ApplicationCore.Validations;

namespace Ws4vn.Microservices.ApplicationCore.SharedKernel
{
    public static class HandlerRegister
    {
        public static void Register(Assembly assembly, IServiceCollection services)
        {
            services.AddTransient<IValidationContext, ValidationContext>();
            services.AddScoped<ICommandBus, CommandBus>();
            services.AddScoped<IEventBus, EventBus>();

            services.AddScoped<IDomainContext>(i => new DomainContext(i.GetService<IConfiguration>(), i.GetService<IBusControl>(), i.GetService<IEventBus>()));
            services.AddScoped<IDomainService>(i => new DomainService(i.GetService<IDomainContext>(), i.GetService<IDataAccessWriteService>()));

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
                    services.AddScoped(itype, type);
                }
            }

            var allEventHandlers = assembly.GetTypes().Where(t =>
               t.IsClass &&
               !t.IsAbstract &&
               t.IsAssignableToGenericType(typeof(IEventHandler<>)));
            foreach (var type in allEventHandlers)
            {
                var allInterfaces = type.GetInterfaces();
                var mainInterfaces = allInterfaces.Where(t => t.IsAssignableToGenericType(typeof(IEventHandler<>)));
                foreach (var itype in mainInterfaces)
                {
                    services.AddScoped(itype, type);
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
                    services.AddScoped(itype, typeIQuery);
                }
            }
        }
    }
}
