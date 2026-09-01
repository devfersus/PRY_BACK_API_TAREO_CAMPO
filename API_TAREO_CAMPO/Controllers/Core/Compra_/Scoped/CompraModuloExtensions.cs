using CORE.Compra_.Web.Aplicacion.CasosUso;
using CORE.Compra_.Web.Aplicacion.Ports;
using CORE.Compra_.Web.Dominio.Interface;
using CORE.Compra_.Web.Infraestructura.Adaptador;

namespace API_TAREO_CAMPO.Controllers.Core.Compra_.Scoped
{
    public static class CompraModuloExtensions
    {
        public static IServiceCollection AgregarModuloCompra(this IServiceCollection services)
        {
            services.AddScoped<ICompraRepository, CompraRepositorioEfCore>();
            services.AddScoped<ICompraCasoUso, CompraServicioAplicacion>();

            return services;
        }
    }
}
