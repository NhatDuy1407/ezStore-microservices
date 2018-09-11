using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace ezStore.Microservice.Product.API
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
                c.SwaggerDoc("v1", new Info { Title = "OO API", Version = "v1" });
                //c.AddSecurityDefinition("Bearer", BuildApiKeyScheme());
            });
        }

        /// <summary>
        ///     Uses swagger common service
        /// </summary>
        /// <param name="app"></param>
        public static void UseSwaggerCommon(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "OO API V1"); });
        }

        /// <summary>
        /// Build api key scheme
        /// </summary>
        /// <returns></returns>
        //private static ApiKeyScheme BuildApiKeyScheme()
        //{
        //    return new ApiKeyScheme()
        //    {
        //        Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
        //        Name = "Authorization",
        //        In = "header",
        //        Type = "apiKey"
        //    };
        //}
    }
}