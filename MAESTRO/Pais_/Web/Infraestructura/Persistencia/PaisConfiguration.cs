using MAESTRO.Pais_.Web.Dominio.Entidad;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MAESTRO.Pais_.Web.Infraestructura.Persistencia
{
    public class PaisConfiguration : IEntityTypeConfiguration<Pais>
    {
        public void Configure(EntityTypeBuilder<Pais> builder)
        {
            builder.ToTable("PAIS");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Descripcion).HasMaxLength(50).IsRequired();
            builder.Property(p => p.Activo).IsRequired();
        }
    }
}
