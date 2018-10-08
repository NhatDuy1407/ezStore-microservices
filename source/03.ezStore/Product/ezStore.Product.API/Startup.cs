using ezStore.Product.Infrastructure;
using MassTransit;
using Microservice.Core;
using Microservice.Core.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace ezStore.Product.API
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
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins",
                    builder => builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());

                // note: use this if you want to allow a specific origin
                //options.AddPolicy("AllowSpecificOrigins",
                //    builder => builder
                //    .WithOrigins("http://localhost:4200") // for a specific url. Don't add a forward slash on the end!
                //    .AllowAnyMethod()
                //    .AllowAnyHeader()
                //    .AllowCredentials());
            });

            // Add configuration for Swagger
            services.AddSwaggerCommon();

            services.AddMvc();

            services.AddDbContext<ApplicationDbContext>(options => 
                options.UseMySql(Configuration.GetConnectionString(Constants.DefaultConnection), b => b.MigrationsAssembly("ezStore.Product.API")));

            ServiceConfiguration.ConfigureServices(services, Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IServiceProvider serviceProvider)
        {
            app.UseCors("AllowAllOrigins");

            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            loggerFactory.AddProvider(new MicroserviceLoggerProvider(serviceProvider.GetService<IBusControl>(), Configuration));

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            app.UseSwaggerCommon();
        }
    }
}
