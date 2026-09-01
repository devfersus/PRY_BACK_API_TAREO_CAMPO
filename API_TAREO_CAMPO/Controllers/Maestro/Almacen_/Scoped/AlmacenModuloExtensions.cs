using MAESTRO.Almacen_.Web.Aplicacion.CasosUso;
using MAESTRO.Almacen_.Web.Aplicacion.Ports;
using MAESTRO.Almacen_.Web.Dominio.Interface;
using MAESTRO.Almacen_.Web.Infraestructura.Adaptador;

namespace API_TAREO_CAMPO.Controllers.Maestro.Almacen_.Scoped
{
    public static class AlmacenModuloExtensions
    {
        public static IServiceCollection AgregarModuloAlmacen(this IServiceCollection services)
        {
            services.AddScoped<IAlmacenRepository, AlmacenRepositorioEfCore>();
            services.AddScoped<IAlmacenCasoUso, AlmacenServicioAplicacion>();
            return services;
        }
    }
}
