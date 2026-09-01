using CORE.Ajuste_.Web.Dominio.Entidad;
using CORE.Ajuste_.Web.Infraestructura.Persistencia;
using CORE.Compra_.Web.Dominio.Entidad;
using CORE.Compra_.Web.Infraestructura.Persistencia;
using CORE.Kardex_.Web.Dominio.Entidad;
using CORE.Kardex_.Web.Infraestructura.Persistencia;
using CORE.Salida_.Web.Dominio.Entidad;
using CORE.Salida_.Web.Infraestructura.Persistencia;
using CORE.Stock_.Web.Dominio.Entidad;
using CORE.Stock_.Web.Infraestructura.Persistencia;
using Microsoft.EntityFrameworkCore;

namespace CORE.Infraestructura
{
    public class CoreDBContext : DbContext
    {
        public CoreDBContext(DbContextOptions<CoreDBContext> options) : base(options) { }

        public DbSet<Compra>         Compras        => Set<Compra>();
        public DbSet<CompraDetalle>  CompraDetalles => Set<CompraDetalle>();
        public DbSet<Stock>          Stocks         => Set<Stock>();
        public DbSet<Salida>         Salidas        => Set<Salida>();
        public DbSet<SalidaDetalle>  SalidaDetalles => Set<SalidaDetalle>();
        public DbSet<Kardex>         Kardexs        => Set<Kardex>();
        public DbSet<Ajuste>         Ajustes        => Set<Ajuste>();
        public DbSet<AjusteDetalle>  AjusteDetalles => Set<AjusteDetalle>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CompraConfiguration());
            modelBuilder.ApplyConfiguration(new CompraDetalleConfiguration());
            modelBuilder.ApplyConfiguration(new StockConfiguration());
            modelBuilder.ApplyConfiguration(new SalidaConfiguration());
            modelBuilder.ApplyConfiguration(new SalidaDetalleConfiguration());
            modelBuilder.ApplyConfiguration(new KardexConfiguration());
            modelBuilder.ApplyConfiguration(new AjusteConfiguration());
            modelBuilder.ApplyConfiguration(new AjusteDetalleConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
