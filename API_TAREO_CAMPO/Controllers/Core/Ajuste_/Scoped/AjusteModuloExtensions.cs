using CORE.Ajuste_.Web.Aplicacion.CasosUso;
using CORE.Ajuste_.Web.Aplicacion.Ports;
using CORE.Ajuste_.Web.Dominio.Interface;
using CORE.Ajuste_.Web.Infraestructura.Adaptador;

namespace API_TAREO_CAMPO.Controllers.Core.Ajuste_.Scoped
{
    public static class AjusteModuloExtensions
    {
        public static IServiceCollection AgregarModuloAjuste(this IServiceCollection services)
        {
            services.AddScoped<IAjusteRepository, AjusteRepositorioEfCore>();
            services.AddScoped<IAjusteCasoUso, AjusteServicioAplicacion>();

            return services;
        }
    }
}
