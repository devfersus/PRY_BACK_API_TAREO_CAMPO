using MAESTRO.Producto_.Web.Aplicacion.CasosUso;
using MAESTRO.Producto_.Web.Aplicacion.Ports;
using MAESTRO.Producto_.Web.Dominio.Interface;
using MAESTRO.Producto_.Web.Infraestructura.Adaptador;

namespace API_TAREO_CAMPO.Controllers.Maestro.Producto_.Scoped
{
    public static class ProductoModuloExtensions
    {
        public static IServiceCollection AgregarModuloProducto(this IServiceCollection services)
        {
            services.AddScoped<IProductoRepository, ProductoRepositorioEfCore>();
            services.AddScoped<IProductoCasoUso, ProductoServicioAplicacion>();

            return services;
        }
    }
}
