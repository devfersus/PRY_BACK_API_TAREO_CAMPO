using MAESTRO.Almacen_.Web.Dominio.Entidad;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MAESTRO.Almacen_.Web.Infraestructura.Persistencia
{
    public class AlmacenConfiguration : IEntityTypeConfiguration<Almacen>
    {
        public void Configure(EntityTypeBuilder<Almacen> builder)
        {
            builder.ToTable("ALMACEN");

            builder.HasKey(a => a.IdAlmacen);
            builder.Property(a => a.IdAlmacen)
                   .HasColumnName("ID_ALMACEN");

            builder.Property(a => a.Codigo)
                   .HasColumnName("CODIGO")
                   .HasMaxLength(10);

            builder.Property(a => a.Descripcion)
                   .HasColumnName("DESCRIPCION")
                   .HasMaxLength(50);

            builder.Property(a => a.Ubicacion)
                   .HasColumnName("UBICACION")
                   .HasMaxLength(100);

            builder.Property(a => a.Estado)
                   .HasColumnName("ESTADO");

            builder.Property(a => a.FechaRegistro)
                   .HasColumnName("FECHA_REGISTRO")
                   .IsRequired();

            builder.Property(a => a.UsuarioRegistro)
                   .HasColumnName("USUARIO_REGISTRO")
                   .HasMaxLength(20);

            builder.Property(a => a.Ipv4Registro)
                   .HasColumnName("IPV4_REGISTRO")
                   .HasMaxLength(25);

            builder.Property(a => a.Ipv6Registro)
                   .HasColumnName("IPV6_REGISTRO")
                   .HasMaxLength(25);

            builder.Property(a => a.FechaModificacion)
                   .HasColumnName("FECHA_MODIFICACION")
                   .IsRequired();

            builder.Property(a => a.UsuarioModificacion)
                   .HasColumnName("USUARIO_MODIFICACION")
                   .HasMaxLength(20);

            builder.Property(a => a.Ipv4Modificacion)
                   .HasColumnName("IPV4_MODIFICACION")
                   .HasMaxLength(25);

            builder.Property(a => a.Ipv6Modificacion)
                   .HasColumnName("IPV6_MODIFICACION")
                   .HasMaxLength(25);
        }
    }
}
