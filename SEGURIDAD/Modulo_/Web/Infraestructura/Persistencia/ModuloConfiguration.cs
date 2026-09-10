using SEGURIDAD.Modulo_.Web.Dominio.Entidad;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SEGURIDAD.Modulo_.Web.Infraestructura.Persistencia
{
    public class ModuloConfiguration : IEntityTypeConfiguration<Modulo>
    {
        public void Configure(EntityTypeBuilder<Modulo> builder)
        {
            builder.ToTable("modulo");
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).HasColumnName("id");
            builder.Property(m => m.Descripcion).HasColumnName("descripcion").HasMaxLength(100).IsRequired();
            builder.Property(m => m.Activo).HasColumnName("activo").IsRequired();
        }
    }
}
