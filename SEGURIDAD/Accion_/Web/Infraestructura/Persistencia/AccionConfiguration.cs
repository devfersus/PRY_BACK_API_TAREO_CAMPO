using SEGURIDAD.Accion_.Web.Dominio.Entidad;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SEGURIDAD.Accion_.Web.Infraestructura.Persistencia
{
    public class AccionConfiguration : IEntityTypeConfiguration<Accion>
    {
        public void Configure(EntityTypeBuilder<Accion> builder)
        {
            builder.ToTable("ACCION");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Descripcion).HasMaxLength(100).IsRequired();
            builder.Property(a => a.Activo).IsRequired();
        }
    }
}
