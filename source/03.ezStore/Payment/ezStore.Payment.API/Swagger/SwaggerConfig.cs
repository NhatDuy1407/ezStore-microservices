using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System.Collections.Generic;
using System.Linq;

namespace ezStore.Payment.API
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
                c.SwaggerDoc("v1", new Info { Title = "Payment API", Version = "v1" });
                c.AddSecurityDefinition("Bearer", BuildApiKeyScheme());
                c.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>> { { "Bearer", Enumerable.Empty<string>() } });
            });
        }

        /// <summary>
        ///     Uses swagger common service
        /// </summary>
        /// <param name="app"></param>
        public static void UseSwaggerCommon(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Payment API V1"); });
        }

        /// <summary>
        /// Build api key scheme
        /// </summary>
        /// <returns></returns>
        private static ApiKeyScheme BuildApiKeyScheme()
        {
            return new ApiKeyScheme()
            {
                Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                Name = "Authorization",
                In = "header",
                Type = "apiKey"
            };
        }
    }
}