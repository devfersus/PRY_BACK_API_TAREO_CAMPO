using CORE.Salida_.Web.Aplicacion.CasosUso;
using CORE.Salida_.Web.Aplicacion.Ports;
using CORE.Salida_.Web.Dominio.Interface;
using CORE.Salida_.Web.Infraestructura.Adaptador;

namespace API_TAREO_CAMPO.Controllers.Core.Salida_.Scoped
{
    public static class SalidaModuloExtensions
    {
        public static IServiceCollection AgregarModuloSalida(this IServiceCollection services)
        {
            services.AddScoped<ISalidaRepository, SalidaRepositorioEfCore>();
            services.AddScoped<ISalidaCasoUso, SalidaServicioAplicacion>();

            return services;
        }
    }
}
