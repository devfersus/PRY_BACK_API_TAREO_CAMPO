using SEGURIDAD.Accion_.Web.Dominio.Entidad;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SEGURIDAD.Accion_.Web.Infraestructura.Persistencia
{
    public class AccionConfiguration : IEntityTypeConfiguration<Accion>
    {
        public void Configure(EntityTypeBuilder<Accion> builder)
        {
            builder.ToTable("accion");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).HasColumnName("id");
            builder.Property(a => a.Descripcion).HasColumnName("descripcion").HasMaxLength(100).IsRequired();
            builder.Property(a => a.Activo).HasColumnName("activo").IsRequired();
        }
    }
}
