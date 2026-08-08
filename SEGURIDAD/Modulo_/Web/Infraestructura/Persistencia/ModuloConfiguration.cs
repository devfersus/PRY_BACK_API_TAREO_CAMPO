using SEGURIDAD.Modulo_.Web.Dominio.Entidad;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SEGURIDAD.Modulo_.Web.Infraestructura.Persistencia
{
    public class ModuloConfiguration : IEntityTypeConfiguration<Modulo>
    {
        public void Configure(EntityTypeBuilder<Modulo> builder)
        {
            builder.ToTable("MODULO");
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Descripcion).HasMaxLength(100).IsRequired();
            builder.Property(m => m.Activo).IsRequired();
        }
    }
}
