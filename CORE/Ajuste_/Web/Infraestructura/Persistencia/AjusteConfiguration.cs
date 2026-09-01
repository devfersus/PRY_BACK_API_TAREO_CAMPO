using CORE.Ajuste_.Web.Dominio.Entidad;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CORE.Ajuste_.Web.Infraestructura.Persistencia
{
    public class AjusteConfiguration : IEntityTypeConfiguration<Ajuste>
    {
        public void Configure(EntityTypeBuilder<Ajuste> builder)
        {
            builder.ToTable("AJUSTE");

            builder.HasKey(a => a.IdAjuste);
            builder.Property(a => a.IdAjuste)
                   .HasColumnName("ajuste_id");

            builder.Property(a => a.CodigoAjuste)
                   .HasColumnName("codigo_ajuste")
                   .HasMaxLength(10);

            builder.Property(a => a.Motivo)
                   .HasColumnName("motivo")
                   .HasMaxLength(100);

            builder.Property(a => a.Estado)
                   .HasColumnName("estado");

            builder.Property(a => a.FechaRegistro)
                   .HasColumnName("fecha_registro")
                   .IsRequired();

            builder.Property(a => a.UsuarioRegistro)
                   .HasColumnName("usuario_registro")
                   .HasMaxLength(20);

            builder.Property(a => a.Ipv4Registro)
                   .HasColumnName("ipv4_registro")
                   .HasMaxLength(25);

            builder.Property(a => a.Ipv6Registro)
                   .HasColumnName("ipv6_registro")
                   .HasMaxLength(25);

            builder.Property(a => a.FechaModificacion)
                   .HasColumnName("fecha_modificacion")
                   .IsRequired();

            builder.Property(a => a.UsuarioModificacion)
                   .HasColumnName("usuario_modificacion")
                   .HasMaxLength(20);

            builder.Property(a => a.Ipv4Modificacion)
                   .HasColumnName("ipv4_modificacion")
                   .HasMaxLength(25);

            builder.Property(a => a.Ipv6Modificacion)
                   .HasColumnName("ipv6_modificacion")
                   .HasMaxLength(25);
        }
    }
}
