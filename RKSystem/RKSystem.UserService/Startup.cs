using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RKSystem.DataAccess.MongoDB;
using RKSystem.DataAccess.MongoDB.Interfaces;
using RKSystem.UserService.Mapper;
using RKSystem.UserService.Services;
using RKSystem.UserService.Swagger;

namespace RKSystem.UserService
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
            var corsBuilder = new CorsPolicyBuilder();
            corsBuilder.AllowAnyHeader();
            corsBuilder.AllowAnyMethod();
            corsBuilder.AllowAnyOrigin(); // For anyone access.
            corsBuilder.WithOrigins("http://localhost:4200"); // for a specific url. Don't add a forward slash on the end!
            corsBuilder.AllowCredentials();

            services.AddCors(options => { options.AddPolicy("SiteCorsPolicy", corsBuilder.Build()); });

            // Add configuration for Swagger
            services.AddSwaggerCommon();

            // Add framework services.
            services.AddMvc();

            AutoMapper.Mapper.Initialize(cfg => { cfg.AddProfile<ServiceMapperProfile>(); }
            );

            // Add application services.
            services.AddTransient(i => new MongoDbContext(Configuration.GetConnectionString("DefaultConnection"), Configuration.GetConnectionString("DefaultDatabaseName"), false));
            services.AddTransient<IUnitOfWork>(i => new UnitOfWork(i.GetService<MongoDbContext>()));
            services.AddTransient<IUserService, Services.UserService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseCors("SiteCorsPolicy");

            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //    app.UseBrowserLink();
            //}
            //else
            //{
            //    app.UseExceptionHandler("/Home/Error");
            //}

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    "default",
                    "{controller=Home}/{action=Index}/{id?}");
            });
            app.UseSwaggerCommon();
        }
    }
}
