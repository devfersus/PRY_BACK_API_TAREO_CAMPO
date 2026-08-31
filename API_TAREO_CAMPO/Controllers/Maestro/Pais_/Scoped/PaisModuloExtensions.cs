using MAESTRO.Pais_.Web.Aplicacion.CasosUso;
using MAESTRO.Pais_.Web.Aplicacion.Ports;
using MAESTRO.Pais_.Web.Dominio.Interface;
using MAESTRO.Pais_.Web.Infraestructura.Adaptador;

namespace API_TAREO_CAMPO.Controllers.Maestro.Pais_.Scoped
{
    public static class PaisModuloExtensions
    {
        public static IServiceCollection AgregarModuloPais(this IServiceCollection services)
        {
            services.AddScoped<IPaisRepository, PaisRepositorioEfCore>();
            services.AddScoped<IPaisCasoUso, PaisServicioAplicacion>();

            return services;
        }
    }
}
