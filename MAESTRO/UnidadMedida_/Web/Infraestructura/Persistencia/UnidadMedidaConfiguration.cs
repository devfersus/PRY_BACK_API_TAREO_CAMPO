using MAESTRO.UnidadMedida_.Web.Dominio.Entidad;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MAESTRO.UnidadMedida_.Web.Infraestructura.Persistencia
{
    public class UnidadMedidaConfiguration : IEntityTypeConfiguration<UnidadMedida>
    {
        public void Configure(EntityTypeBuilder<UnidadMedida> builder)
        {
            builder.ToTable("unidad_medida");

            builder.HasKey(u => u.IdUnidadMedida);
            builder.Property(u => u.IdUnidadMedida)
                   .HasColumnName("id_unidad_medida");

            builder.Property(u => u.Codigo)
                   .HasColumnName("codigo")
                   .HasMaxLength(10);

            builder.Property(u => u.Descripcion)
                   .HasColumnName("descripcion")
                   .HasMaxLength(50);

            builder.Property(u => u.Abreviatura)
                   .HasColumnName("abreviatura")
                   .HasMaxLength(10);

            builder.Property(u => u.Estado)
                   .HasColumnName("estado");

            builder.Property(u => u.FechaRegistro)
                   .HasColumnName("fecha_registro")
                   .IsRequired();

            builder.Property(u => u.UsuarioRegistro)
                   .HasColumnName("usuario_registro")
                   .HasMaxLength(20);

            builder.Property(u => u.Ipv4Registro)
                   .HasColumnName("ipv4_registro")
                   .HasMaxLength(25);

            builder.Property(u => u.Ipv6Registro)
                   .HasColumnName("ipv6_registro")
                   .HasMaxLength(25);

            builder.Property(u => u.FechaModificacion)
                   .HasColumnName("fecha_modificacion")
                   .IsRequired();

            builder.Property(u => u.UsuarioModificacion)
                   .HasColumnName("usuario_modificacion")
                   .HasMaxLength(20);

            builder.Property(u => u.Ipv4Modificacion)
                   .HasColumnName("ipv4_modificacion")
                   .HasMaxLength(25);

            builder.Property(u => u.Ipv6Modificacion)
                   .HasColumnName("ipv6_modificacion")
                   .HasMaxLength(25);
        }
    }
}
