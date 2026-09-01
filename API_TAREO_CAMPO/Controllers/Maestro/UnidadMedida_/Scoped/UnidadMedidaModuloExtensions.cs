using MAESTRO.UnidadMedida_.Web.Aplicacion.CasosUso;
using MAESTRO.UnidadMedida_.Web.Aplicacion.Ports;
using MAESTRO.UnidadMedida_.Web.Dominio.Interface;
using MAESTRO.UnidadMedida_.Web.Infraestructura.Adaptador;

namespace API_TAREO_CAMPO.Controllers.Maestro.UnidadMedida_.Scoped
{
    public static class UnidadMedidaModuloExtensions
    {
        public static IServiceCollection AgregarModuloUnidadMedida(this IServiceCollection services)
        {
            services.AddScoped<IUnidadMedidaRepository, UnidadMedidaRepositorioEfCore>();
            services.AddScoped<IUnidadMedidaCasoUso, UnidadMedidaServicioAplicacion>();
            return services;
        }
    }
}
