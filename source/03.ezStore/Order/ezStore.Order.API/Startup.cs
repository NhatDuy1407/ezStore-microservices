using ezStore.Order.Infrastructure;
using IdentityServer4.AccessTokenValidation;
using MassTransit;
using Ws4vn.Microservices.ApplicationCore.SharedKernel;
using Ws4vn.Microservices.Infrastructure.Loggings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;

namespace ezStore.Order.API
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

            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            });

            services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
                .AddIdentityServerAuthentication(options =>
                {
                    options.Authority = Configuration.GetConnectionString(MicroservicesConstants.IdentityServerIssuerUri);
                    options.RequireHttpsMetadata = false;
                    options.ApiName = MicroservicesConstants.IdentityServerAPIName;
                    options.ApiSecret = MicroservicesConstants.IdentityServerSecret;
                });

            services.AddDbContext<OrderDbContext>(options =>
                options.UseMySql(Configuration.GetConnectionString(MicroservicesConstants.DefaultConnection), b => b.MigrationsAssembly("ezStore.Order.API")));

            ServiceConfiguration.ConfigureServices(services, Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IServiceProvider serviceProvider)
        {
            app.UseCors("AllowAllOrigins");
            app.UseAuthentication();

            loggerFactory.AddProvider(new MicroservicesLoggerProvider(serviceProvider.GetService<IBusControl>(), Configuration));

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseSwaggerCommon();
            }

            var logger = serviceProvider.GetService<ILogger<Startup>>();
            app.UseErrorLogging(logger);

            app.UseMvc();
        }
    }
}
