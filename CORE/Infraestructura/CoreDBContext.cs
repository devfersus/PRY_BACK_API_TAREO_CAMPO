using CORE.Compra_.Web.Dominio.Entidad;
using CORE.Compra_.Web.Infraestructura.Persistencia;
using Microsoft.EntityFrameworkCore;

namespace CORE.Infraestructura
{
    public class CoreDBContext : DbContext
    {
        public CoreDBContext(DbContextOptions<CoreDBContext> options) : base(options) { }

        public DbSet<Compra>        Compras        => Set<Compra>();
        public DbSet<CompraDetalle> CompraDetalles => Set<CompraDetalle>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CompraConfiguration());
            modelBuilder.ApplyConfiguration(new CompraDetalleConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
