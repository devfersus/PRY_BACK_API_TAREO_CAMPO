using MAESTRO.Pais_.Web.Dominio.Entidad;
using Microsoft.EntityFrameworkCore;

namespace MAESTRO.Pais_.Web.Infraestructura
{
    public class PaisDBContext : DbContext
    {
        public PaisDBContext(DbContextOptions<PaisDBContext> options) : base(options) { }

        public DbSet<Pais> Paises => Set<Pais>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PaisDBContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
