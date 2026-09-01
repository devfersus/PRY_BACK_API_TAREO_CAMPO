using MAESTRO.UnidadMedida_.Web.Dominio.Entidad;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MAESTRO.UnidadMedida_.Web.Infraestructura.Persistencia
{
    public class UnidadMedidaConfiguration : IEntityTypeConfiguration<UnidadMedida>
    {
        public void Configure(EntityTypeBuilder<UnidadMedida> builder)
        {
            builder.ToTable("UNIDAD_MEDIDA");

            builder.HasKey(u => u.IdUnidadMedida);
            builder.Property(u => u.IdUnidadMedida)
                   .HasColumnName("ID_UNIDAD_MEDIDA");

            builder.Property(u => u.Codigo)
                   .HasColumnName("CODIGO")
                   .HasMaxLength(10);

            builder.Property(u => u.Descripcion)
                   .HasColumnName("DESCRIPCION")
                   .HasMaxLength(50);

            builder.Property(u => u.Abreviatura)
                   .HasColumnName("ABREVIATURA")
                   .HasMaxLength(10);

            builder.Property(u => u.Estado)
                   .HasColumnName("ESTADO");

            builder.Property(u => u.FechaRegistro)
                   .HasColumnName("FECHA_REGISTRO")
                   .IsRequired();

            builder.Property(u => u.UsuarioRegistro)
                   .HasColumnName("USUARIO_REGISTRO")
                   .HasMaxLength(20);

            builder.Property(u => u.Ipv4Registro)
                   .HasColumnName("IPV4_REGISTRO")
                   .HasMaxLength(25);

            builder.Property(u => u.Ipv6Registro)
                   .HasColumnName("IPV6_REGISTRO")
                   .HasMaxLength(25);

            builder.Property(u => u.FechaModificacion)
                   .HasColumnName("FECHA_MODIFICACION")
                   .IsRequired();

            builder.Property(u => u.UsuarioModificacion)
                   .HasColumnName("USUARIO_MODIFICACION")
                   .HasMaxLength(20);

            builder.Property(u => u.Ipv4Modificacion)
                   .HasColumnName("IPV4_MODIFICACION")
                   .HasMaxLength(25);

            builder.Property(u => u.Ipv6Modificacion)
                   .HasColumnName("IPV6_MODIFICACION")
                   .HasMaxLength(25);
        }
    }
}
