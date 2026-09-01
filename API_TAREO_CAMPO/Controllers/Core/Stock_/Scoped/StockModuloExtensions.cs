using CORE.Stock_.Web.Aplicacion.CasosUso;
using CORE.Stock_.Web.Aplicacion.Ports;
using CORE.Stock_.Web.Dominio.Interface;
using CORE.Stock_.Web.Infraestructura.Adaptador;

namespace API_TAREO_CAMPO.Controllers.Core.Stock_.Scoped
{
    public static class StockModuloExtensions
    {
        public static IServiceCollection AgregarModuloStock(this IServiceCollection services)
        {
            services.AddScoped<IStockRepository, StockRepositorioEfCore>();
            services.AddScoped<IStockCasoUso, StockServicioAplicacion>();
            return services;
        }
    }
}
