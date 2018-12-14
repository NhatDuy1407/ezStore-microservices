using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ezStore.WareHouse.ApplicationCore
{
    public static class HandlerRegister
    {
        public static void Register(IServiceCollection services)
        {
            Ws4vn.Microservicess.ApplicationCore.SharedKernel.HandlerRegister.Register(Assembly.GetExecutingAssembly(), services);
        }
    }
}
