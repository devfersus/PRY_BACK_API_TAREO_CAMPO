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
            builder.ToTable("SUB_MODULO");
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Descripcion).HasMaxLength(100).IsRequired();
            builder.Property(s => s.Activo).IsRequired();

        }
    }
}
