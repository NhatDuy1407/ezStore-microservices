using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RKSystem.DataAccess.MongoDB;
using RKSystem.UserService.WriteSide.Mapper;

namespace RKSystem.UserService.WriteSide
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddMvc();

            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<ServiceMapperProfile>();
            });

            ServiceConfiguration.ConfigureServices(services, Configuration);

            Task.Factory.StartNew(() =>
            {
                var requestService = new UserRequestService(Configuration);
                requestService.Start();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseMvc();
        }
    }
}
