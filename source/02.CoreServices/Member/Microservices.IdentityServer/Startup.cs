using IdentityServer4.AccessTokenValidation;
using Microservices.IdentityServer.Data;
using Microservices.IdentityServer.Models;
using Microservices.IdentityServer.Services;
using Microservices.IdentityServer.Swagger;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Reflection;
using Ws4vn.Microservices.ApplicationCore.Interfaces;
using Ws4vn.Microservices.ApplicationCore.SharedKernel;
using Ws4vn.Microservices.Infrastructure.Loggings;

namespace Microservices.IdentityServer
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseMySql(Configuration.GetConnectionString(MicroservicesConstants.DefaultConnection)));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

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

            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            });

            // Add configuration for Swagger
            services.AddSwaggerCommon();

            // Add application services.
            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();

            var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;

            services.AddIdentityServer(x => { x.IssuerUri = Configuration.GetConnectionString(MicroservicesConstants.IdentityServerIssuerUri); })
                .AddDeveloperSigningCredential()
                .AddAspNetIdentity<ApplicationUser>()
                .AddConfigurationStore(options =>
                {
                    options.ConfigureDbContext = builder =>
                        builder.UseMySql(Configuration.GetConnectionString(MicroservicesConstants.DefaultConnection),
                            db => db.MigrationsAssembly(migrationsAssembly));
                })
                .AddOperationalStore(options =>
                {
                    options.ConfigureDbContext = builder =>
                        builder.UseMySql(Configuration.GetConnectionString(MicroservicesConstants.DefaultConnection),
                            db => db.MigrationsAssembly(migrationsAssembly));
                });

            //services.AddAuthentication().AddTwitter(twitterOptions =>
            //{
            //    twitterOptions.ConsumerKey = Configuration["Authentication:Twitter:ConsumerKey"];
            //    twitterOptions.ConsumerSecret = Configuration["Authentication:Twitter:ConsumerSecret"];
            //});

            services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
                .AddIdentityServerAuthentication(options =>
                {
                    options.Authority = Configuration.GetConnectionString(MicroservicesConstants.IdentityServerIssuerUri);
                    options.RequireHttpsMetadata = false;
                    options.ApiName = MicroservicesConstants.IdentityServerAPIName;
                    options.ApiSecret = MicroservicesConstants.IdentityServerSecret;
                });

            ServiceConfiguration.ConfigureServices(services, Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IServiceProvider serviceProvider)
        {
            app.UseCors("AllowAllOrigins");

            app.UseSwaggerCommon();

            loggerFactory.AddProvider(new MicroservicesLoggerProvider(serviceProvider.GetService<IMessageBus>(), Configuration));

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                //app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseIdentityServer();

            var logger = serviceProvider.GetService<ILogger<Startup>>();
            app.UseErrorLogging(logger);

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}