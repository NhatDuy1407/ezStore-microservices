﻿using ezStore.WareHouse.Infrastructure;
using IdentityServer4.AccessTokenValidation;
using MassTransit;
using Microservice.Core;
using Microservice.Core.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Net;

namespace ezStore.WareHouse.API
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

            services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
                .AddIdentityServerAuthentication(options =>
                {
                    options.Authority = Configuration.GetConnectionString(MicroserviceConstants.IdentityServerIssuerUri);
                    options.RequireHttpsMetadata = false;
                    options.ApiName = MicroserviceConstants.IdentityServerAPIName;
                    options.ApiSecret = MicroserviceConstants.IdentityServerSecret;
                });

            services.AddDbContext<WareHouseDbContext>(options =>
                options.UseMySql(Configuration.GetConnectionString(MicroserviceConstants.DefaultConnection), b => b.MigrationsAssembly("ezStore.WareHouse.API")));

            ServiceConfiguration.ConfigureServices(services, Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IServiceProvider serviceProvider)
        {
            app.UseCors("AllowAllOrigins");
            app.UseAuthentication();

            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            loggerFactory.AddProvider(new MicroserviceLoggerProvider(serviceProvider.GetService<IBusControl>(), Configuration));

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            var logger = serviceProvider.GetService<ILogger<Startup>>();
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        logger.LogError($"Something went wrong: {contextFeature.Error}", contextFeature.Error);

                        await context.Response.WriteAsync(JsonConvert.SerializeObject(new
                        {
                            context.Response.StatusCode,
                            contextFeature.Error.Message
                        }));
                    }
                });
            });

            app.UseMvc();

            app.UseSwaggerCommon();
        }
    }
}