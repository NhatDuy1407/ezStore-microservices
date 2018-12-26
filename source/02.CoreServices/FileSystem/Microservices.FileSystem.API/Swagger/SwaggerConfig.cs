using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace Microservices.FileSystem.API.Swagger
{
    public static class SwaggerConfig
    {
        /// <summary>
        ///     Add swagger service
        /// </summary>
        /// <param name="services"></param>
        public static void AddSwaggerCommon(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "FileSystem API", Version = "v1" });
            });
        }

        /// <summary>
        ///     Uses swagger common service
        /// </summary>
        /// <param name="app"></param>
        public static void UseSwaggerCommon(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "FileSystem API V1"); });
        }
    }
}