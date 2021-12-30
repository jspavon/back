using generic.app.common.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;

namespace Postobon.CCV.Integration.Api.Swagger
{
    /// <summary>
    /// Class SwaggerConfig.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class Extensions
    {

        /// <summary>
        /// Adds the registration.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns>IServiceCollection.</returns>
        /// <remarks>Jhon Steven Pavon Bedoya</remarks>
        public static IServiceCollection AddRegistrationSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc($"v{Assembly.GetExecutingAssembly().GetName().Version}",
                    new OpenApiInfo
                    {
                        Title = "Generic.App",
                        Version = $"{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")} - v{Assembly.GetExecutingAssembly().GetName().Version}",
                        Description = "Design a DDD (Domain-Driven Design) Microservice, Identity ASP.NET Core / .NET Framework CORE 5.0",
                        Contact = new OpenApiContact
                        {
                            Name = CommonConfiguration.ContactName,
                            Email = CommonConfiguration.Email
                        }
                    });
            });

            services.AddMvcCore().AddApiExplorer();
            return services;
        }

        /// <summary>
        /// Adds the registration.
        /// </summary>
        /// <param name="app">The application.</param>
        /// <returns>IApplicationBuilder.</returns>
        /// <remarks>Jhon Steven Pavon Bedoya</remarks>
        public static IApplicationBuilder AddRegistrationSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"/swagger/v{Assembly.GetExecutingAssembly().GetName().Version}/swagger.json", $"Generic.App (v{Assembly.GetExecutingAssembly().GetName().Version})");
                c.RoutePrefix = string.Empty;
            });
            return app;
        }
    }
}
