using Application.Implements;
using Domain.Interfaces.Application;
using Domain.Interfaces.Infraestructure;
using Infraestrutcure.SQLServer;

namespace CrudProductManagement.Configurations
{
    internal static class DependencyInjectionConfig
    {
        internal static void AddDependenciesInjectionConfig(this IServiceCollection services)
        {
            #region Aplication BL
            services.AddScoped(typeof(IProductoBL), typeof(ProductoBL));
            services.AddScoped<IClimaBL, ClimaBL>();
            #endregion

            #region Repository BL
            services.AddScoped(typeof(IProductoRepository), typeof(ProductoRepository));
            services.AddHttpClient<IClimaRepository, ClimaRepository>();
            #endregion
        }
    }
}