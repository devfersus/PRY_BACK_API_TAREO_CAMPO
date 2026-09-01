using MAESTRO.Categoria_.Web.Aplicacion.CasosUso;
using MAESTRO.Categoria_.Web.Aplicacion.Ports;
using MAESTRO.Categoria_.Web.Dominio.Interface;
using MAESTRO.Categoria_.Web.Infraestructura.Adaptador;

namespace API_TAREO_CAMPO.Controllers.Maestro.Categoria_.Scoped
{
    public static class CategoriaModuloExtensions
    {
        public static IServiceCollection AgregarModuloCategoria(this IServiceCollection services)
        {
            services.AddScoped<ICategoriaRepository, CategoriaRepositorioEfCore>();
            services.AddScoped<ICategoriaCasoUso, CategoriaServicioAplicacion>();

            return services;
        }
    }
}
