using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace Microservice.Logging.BackgroundProcess
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices()
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IHostingEnvironment env)
        {
            var requestService = new ComsummerService(Configuration, env);
            requestService.Start();
        }
    }
}
