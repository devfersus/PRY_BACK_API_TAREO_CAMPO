using CORE.Salida_.Web.Dominio.Entidad;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CORE.Salida_.Web.Infraestructura.Persistencia
{
    public class SalidaConfiguration : IEntityTypeConfiguration<Salida>
    {
        public void Configure(EntityTypeBuilder<Salida> builder)
        {
            builder.ToTable("SALIDA");

            builder.HasKey(s => s.IdSalida);
            builder.Property(s => s.IdSalida)
                   .HasColumnName("salida_id");

            builder.Property(s => s.CodigoSalida)
                   .HasColumnName("codigo_salida")
                   .HasMaxLength(10);

            builder.Property(s => s.Motivo)
                   .HasColumnName("motivo")
                   .HasMaxLength(50);

            builder.Property(s => s.Estado)
                   .HasColumnName("estado");

            builder.Property(s => s.FechaRegistro)
                   .HasColumnName("fecha_registro")
                   .IsRequired();

            builder.Property(s => s.UsuarioRegistro)
                   .HasColumnName("usuario_registro")
                   .HasMaxLength(20);

            builder.Property(s => s.Ipv4Registro)
                   .HasColumnName("ipv4_registro")
                   .HasMaxLength(25);

            builder.Property(s => s.Ipv6Registro)
                   .HasColumnName("ipv6_registro")
                   .HasMaxLength(25);

            builder.Property(s => s.FechaModificacion)
                   .HasColumnName("fecha_modificacion")
                   .IsRequired();

            builder.Property(s => s.UsuarioModificacion)
                   .HasColumnName("usuario_modificacion")
                   .HasMaxLength(20);

            builder.Property(s => s.Ipv4Modificacion)
                   .HasColumnName("ipv4_modificacion")
                   .HasMaxLength(25);

            builder.Property(s => s.Ipv6Modificacion)
                   .HasColumnName("ipv6_modificacion")
                   .HasMaxLength(25);
        }
    }
}
