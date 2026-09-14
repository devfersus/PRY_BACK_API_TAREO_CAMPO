using CORE.TareoCosecha_.Web.Aplicacion.CasosUso;
using CORE.TareoCosecha_.Web.Aplicacion.Ports;
using CORE.TareoCosecha_.Web.Dominio.Interface;
using CORE.TareoCosecha_.Web.Infraestructura.Adaptador;

namespace API_TAREO_CAMPO.Controllers.Core.TareoCosecha_.Scoped
{
    public static class TareoCosechaModuloExtensions
    {
        public static IServiceCollection AgregarModuloTareoCosecha(this IServiceCollection services)
        {
            services.AddScoped<ITareoCosechaRepository, TareoCosechaRepositorioEfCore>();
            services.AddScoped<ITareoCosechaCasoUso, TareoCosechaServicioAplicacion>();

            return services;
        }
    }
}
