using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Microservices.FileSystem.ApplicationCore
{
    public static class HandlerRegister
    {
        public static void Register(IServiceCollection services)
        {
            Ws4vn.Microservices.ApplicationCore.SharedKernel.HandlerRegister.Register(Assembly.GetExecutingAssembly(), services);
        }
    }
}
