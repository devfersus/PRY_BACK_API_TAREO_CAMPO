using CORE.Kardex_.Web.Aplicacion.CasosUso;
using CORE.Kardex_.Web.Aplicacion.Ports;
using CORE.Kardex_.Web.Dominio.Interface;
using CORE.Kardex_.Web.Infraestructura.Adaptador;

namespace API_TAREO_CAMPO.Controllers.Core.Kardex_.Scoped
{
    public static class KardexModuloExtensions
    {
        public static IServiceCollection AgregarModuloKardex(this IServiceCollection services)
        {
            services.AddScoped<IKardexRepository, KardexRepositorioEfCore>();
            services.AddScoped<IKardexCasoUso, KardexServicioAplicacion>();

            return services;
        }
    }
}
