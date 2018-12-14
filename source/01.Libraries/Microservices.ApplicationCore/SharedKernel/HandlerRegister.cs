using Ws4vn.Microservicess.ApplicationCore.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Reflection;
using Ws4vn.Microservicess.ApplicationCore.Services;
using Microsoft.Extensions.Configuration;
using MassTransit;
using Ws4vn.Microservices.ApplicationCore;
using Ws4vn.Microservicess.ApplicationCore.Validations;

namespace Ws4vn.Microservicess.ApplicationCore.SharedKernel
{
    public static class HandlerRegister
    {
        public static void Register(Assembly assembly, IServiceCollection services)
        {
            services.AddScoped<IValidationContext, ValidationContext>();
            services.AddTransient<ICommandBus, CommandBus>();
            services.AddTransient<IEventBus, EventBus>();

            services.AddTransient<IDomainContext>(i => new DomainContext(i.GetService<IConfiguration>(), i.GetService<IBusControl>(), i.GetService<IEventBus>()));
            services.AddTransient<IDomainService>(i => new DomainService(i.GetService<IDomainContext>(), i.GetService<IDataAccessWriteService>()));

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
