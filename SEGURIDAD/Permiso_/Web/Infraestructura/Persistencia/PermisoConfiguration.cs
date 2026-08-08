using SEGURIDAD.Permiso_.Web.Dominio.Entidad;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SEGURIDAD.Permiso_.Web.Infraestructura.Persistencia
{
    public class PermisoConfiguration : IEntityTypeConfiguration<Permiso>
    {
        public void Configure(EntityTypeBuilder<Permiso> builder)
        {
            builder.ToTable("PERMISO");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("permiso_id");
            builder.Property(p => p.Descripcion).HasColumnName("descripcion");
            builder.Property(p => p.Activo).HasColumnName("activo");
        }
    }
}
