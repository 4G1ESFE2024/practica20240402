
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Practica20240402.AccesoADatos;
namespace Practica20240402.LogicaDeNegocio
{
    public static class DependecyContainer
    {
        public static IServiceCollection AddBLDependecies(this IServiceCollection services, IConfiguration configuration)
        {           
            services.AddDALDependecies(configuration);
            services.AddScoped<ClienteBL>();
            return services;
        }
    }
}
