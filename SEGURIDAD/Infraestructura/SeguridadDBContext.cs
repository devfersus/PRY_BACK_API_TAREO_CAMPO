using Microsoft.EntityFrameworkCore;
using SEGURIDAD.Accion_.Web.Dominio.Entidad;
using SEGURIDAD.Accion_.Web.Infraestructura.Persistencia;
using SEGURIDAD.AccionSubModulo_.Web.Dominio.Entidad;
using SEGURIDAD.AccionSubModulo_.Web.Infraestructura.Persistencia;
using SEGURIDAD.Modulo_.Web.Dominio.Entidad;
using SEGURIDAD.Modulo_.Web.Infraestructura.Persistencia;
using SEGURIDAD.Permiso_.Web.Dominio.Entidad;
using SEGURIDAD.Permiso_.Web.Infraestructura.Persistencia;
using SEGURIDAD.Proveedor_.Web.Dominio.Entidad;
using SEGURIDAD.Proveedor_.Web.Infraestructura.Persistencia;
using SEGURIDAD.SubModulo_.Web.Dominio.Entidad;
using SEGURIDAD.SubModulo_.Web.Infraestructura.Persistencia;
using SEGURIDAD.Usuario_.Web.Dominio.Entidad;
using SEGURIDAD.Usuario_.Web.Infraestructura.Persistencia;
using SEGURIDAD.UsuarioPermiso_.Web.Dominio.Entidad;
using SEGURIDAD.UsuarioPermiso_.Web.Infraestructura.Persistencia;

namespace SEGURIDAD.Infraestructura
{
    public class SeguridadDBContext : DbContext
    {
        public SeguridadDBContext(DbContextOptions<SeguridadDBContext> options) : base(options) { }

        public DbSet<Usuario>         Usuarios         => Set<Usuario>();
        public DbSet<Accion>          Acciones         => Set<Accion>();
        public DbSet<Modulo>          Modulos          => Set<Modulo>();
        public DbSet<SubModulo>       SubModulos       => Set<SubModulo>();
        public DbSet<AccionSubModulo> AccionSubModulos => Set<AccionSubModulo>();
        public DbSet<Permiso>         Permisos         => Set<Permiso>();
        public DbSet<PermisoDetalle>  PermisoDetalles  => Set<PermisoDetalle>();
        public DbSet<Proveedor>        Proveedores       => Set<Proveedor>();
        public DbSet<UsuarioPermiso>   UsuarioPermisos   => Set<UsuarioPermiso>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
            modelBuilder.ApplyConfiguration(new AccionConfiguration());
            modelBuilder.ApplyConfiguration(new ModuloConfiguration());
            modelBuilder.ApplyConfiguration(new SubModuloConfiguration());
            modelBuilder.ApplyConfiguration(new AccionSubModuloConfiguration());
            modelBuilder.ApplyConfiguration(new PermisoConfiguration());
            modelBuilder.ApplyConfiguration(new PermisoDetalleConfiguration());
            modelBuilder.ApplyConfiguration(new ProveedorConfiguration());
            modelBuilder.ApplyConfiguration(new UsuarioPermisoConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
