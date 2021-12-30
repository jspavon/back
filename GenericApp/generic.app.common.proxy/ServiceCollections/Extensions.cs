
using generic.app.common.proxy.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace generic.app.common.proxy.ServiceCollections
{
    /// <summary>
    /// Class Extensions.
    /// </summary>
    /// <remarks>Jhon Steven Pavón Bedoya</remarks>
    public static class Extensions
    {
        /// <summary>
        /// Adds the proxy HTTP.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns>IServiceCollection.</returns>
        /// <remarks>Jhon Steven Pavón Bedoya</remarks>
        public static IServiceCollection AddProxyHttp(this IServiceCollection services)
        {
            services.AddSingleton<IHttpClientHelper, HttpClientHelper>();
            return services;
        }
    }
}
