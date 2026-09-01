using MAESTRO.Almacen_.Web.Dominio.Entidad;
using MAESTRO.Almacen_.Web.Infraestructura.Persistencia;
using MAESTRO.Categoria_.Web.Dominio.Entidad;
using MAESTRO.Categoria_.Web.Infraestructura.Persistencia;
using MAESTRO.Pais_.Web.Dominio.Entidad;
using MAESTRO.Pais_.Web.Infraestructura.Persistencia;
using MAESTRO.Producto_.Web.Dominio.Entidad;
using MAESTRO.Producto_.Web.Infraestructura.Persistencia;
using MAESTRO.UnidadMedida_.Web.Dominio.Entidad;
using MAESTRO.UnidadMedida_.Web.Infraestructura.Persistencia;
using Microsoft.EntityFrameworkCore;

namespace MAESTRO.Infraestructura
{
    public class MaestroDBContext : DbContext
    {
        public MaestroDBContext(DbContextOptions<MaestroDBContext> options) : base(options) { }

        public DbSet<Pais>          Paises         => Set<Pais>();
        public DbSet<Categoria>     Categorias     => Set<Categoria>();
        public DbSet<Producto>      Productos      => Set<Producto>();
        public DbSet<UnidadMedida>  UnidadesMedida => Set<UnidadMedida>();
        public DbSet<Almacen>       Almacenes      => Set<Almacen>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PaisConfiguration());
            modelBuilder.ApplyConfiguration(new CategoriaConfiguration());
            modelBuilder.ApplyConfiguration(new ProductoConfiguration());
            modelBuilder.ApplyConfiguration(new UnidadMedidaConfiguration());
            modelBuilder.ApplyConfiguration(new AlmacenConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
