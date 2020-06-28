using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace ApiService.Configuration
{
    public static class ServicesConfiguration
    {
        public static void AddSwaggerServices(this IServiceCollection services)
        {
            var ver = typeof(Startup).Assembly.GetName().Version.ToString();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                     new OpenApiInfo
                     {
                         Title = "API de Serviços Diversos",
                         Version = "v1",
                         Description = "Build: " + ver,
                         Contact = new OpenApiContact
                         {
                             Name = "ApiService",
                         }
                     });

                //c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                //{
                //    Description = "Please enter into field the word 'Bearer' followed by a space and the JWT value",
                //    Name = "Authorization",
                //    In = ParameterLocation.Header,
                //    Type = SecuritySchemeType.ApiKey,
                //    Scheme = "bearer"
                //});

                //c.AddSecurityRequirement(new OpenApiSecurityRequirement
                //{
                //    { new OpenApiSecurityScheme
                //    {
                //        Reference = new OpenApiReference()
                //        {
                //            Id = "Bearer",
                //            Type = ReferenceType.SecurityScheme
                //        }
                //    }, Array.Empty<string>() }
                //});
            });
        }
    }
}
