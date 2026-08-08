using SEGURIDAD.Accion_.Web.Aplicacion.CasosUso;
using SEGURIDAD.Accion_.Web.Aplicacion.Ports;
using SEGURIDAD.Accion_.Web.Dominio.Interface;
using SEGURIDAD.Accion_.Web.Infraestructura.Adaptador;
using SEGURIDAD.AccionSubModulo_.Web.Aplicacion.CasosUso;
using SEGURIDAD.AccionSubModulo_.Web.Aplicacion.Ports;
using SEGURIDAD.AccionSubModulo_.Web.Dominio.Interface;
using SEGURIDAD.AccionSubModulo_.Web.Infraestructura.Adaptador;
using SEGURIDAD.Modulo_.Web.Aplicacion.CasosUso;
using SEGURIDAD.Modulo_.Web.Aplicacion.Ports;
using SEGURIDAD.Modulo_.Web.Dominio.Interface;
using SEGURIDAD.Modulo_.Web.Infraestructura.Adaptador;
using SEGURIDAD.Permiso_.Web.Aplicacion.CasosUso;
using SEGURIDAD.Permiso_.Web.Aplicacion.Ports;
using SEGURIDAD.Permiso_.Web.Dominio.Interface;
using SEGURIDAD.Permiso_.Web.Infraestructura.Adaptador;
using SEGURIDAD.SubModulo_.Web.Aplicacion.CasosUso;
using SEGURIDAD.SubModulo_.Web.Aplicacion.Ports;
using SEGURIDAD.SubModulo_.Web.Dominio.Interface;
using SEGURIDAD.SubModulo_.Web.Infraestructura.Adaptador;
using SEGURIDAD.Usuario_.Web.Aplicacion.CasosUso;
using SEGURIDAD.Usuario_.Web.Aplicacion.Ports;
using SEGURIDAD.Usuario_.Web.Dominio.Interface;
using SEGURIDAD.Usuario_.Web.Dominio.Servicio;
using SEGURIDAD.Usuario_.Web.Infraestructura.Adapter;

namespace API_TAREO_CAMPO.Controllers.Seguridad.Navegacion_.Scoped
{
    public static class NavegacionModuloExtensions
    {
        public static IServiceCollection AgregarModuloNavegacion(this IServiceCollection services)
        {
            services.AddScoped<IAccionRepository         , AccionRepositorioEfCore>();
            services.AddScoped<IModuloRepository         , ModuloRepositorioEfCore>();
            services.AddScoped<ISubModuloRepository      , SubModuloRepositorioEfCore>();
            services.AddScoped<IAccionSubModuloRepository, AccionSubModuloRepositorioEfCore>();
            services.AddScoped<IPermisoRepository        , PermisoRepositorioEfCore>();
            services.AddScoped<IPermisoDetalleRepository , PermisoDetalleRepositorioEfCore>();
            services.AddScoped<IUsuarioRepository        , UsuarioRepositorioEfCore>();

            services.AddScoped<ServicioDominioUsuario>();

            services.AddScoped<IAccionCasoUso            , AccionServicioAplicacion>();
            services.AddScoped<IModuloCasoUso            , ModuloServicioAplicacion>();
            services.AddScoped<ISubModuloCasoUso         , SubModuloServicioAplicacion>();
            services.AddScoped<IAccionSubModuloCasoUso   , AccionSubModuloServicioAplicacion>();
            services.AddScoped<IPermisoCasoUso           , PermisoServicioAplicacion>();
            services.AddScoped<IPermisoDetalleCasoUso    , PermisoDetalleServicioAplicacion>();
            services.AddScoped<IUsuarioCasoUso           , UsuarioServicioAplicacion>();

            return services;
        }
    }
} 