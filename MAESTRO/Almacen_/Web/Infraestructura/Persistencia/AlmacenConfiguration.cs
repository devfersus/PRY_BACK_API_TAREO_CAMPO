using MAESTRO.Almacen_.Web.Dominio.Entidad;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MAESTRO.Almacen_.Web.Infraestructura.Persistencia
{
    public class AlmacenConfiguration : IEntityTypeConfiguration<Almacen>
    {
        public void Configure(EntityTypeBuilder<Almacen> builder)
        {
            builder.ToTable("almacen");

            builder.HasKey(a => a.IdAlmacen);
            builder.Property(a => a.IdAlmacen)
                   .HasColumnName("id_almacen");

            builder.Property(a => a.Codigo)
                   .HasColumnName("codigo")
                   .HasMaxLength(10);

            builder.Property(a => a.Descripcion)
                   .HasColumnName("descripcion")
                   .HasMaxLength(50);

            builder.Property(a => a.Ubicacion)
                   .HasColumnName("ubicacion")
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
