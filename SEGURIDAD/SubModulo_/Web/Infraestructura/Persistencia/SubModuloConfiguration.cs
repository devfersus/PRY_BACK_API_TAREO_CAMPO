using SEGURIDAD.Modulo_.Web.Dominio.Entidad;
using SEGURIDAD.SubModulo_.Web.Dominio.Entidad;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SEGURIDAD.SubModulo_.Web.Infraestructura.Persistencia
{
    public class SubModuloConfiguration : IEntityTypeConfiguration<SubModulo>
    {
        public void Configure(EntityTypeBuilder<SubModulo> builder)
        {
            builder.ToTable("sub_modulo");
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id).HasColumnName("id");
            builder.Property(s => s.Descripcion).HasColumnName("descripcion").HasMaxLength(100).IsRequired();
            builder.Property(s => s.Activo).HasColumnName("activo").IsRequired();

        }
    }
}
