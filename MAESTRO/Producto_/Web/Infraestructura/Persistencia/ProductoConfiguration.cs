using MAESTRO.Producto_.Web.Dominio.Entidad;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MAESTRO.Producto_.Web.Infraestructura.Persistencia
{
    public class ProductoConfiguration : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            builder.ToTable("producto");

            builder.HasKey(p => p.IdProducto);
            builder.Property(p => p.IdProducto)
                   .HasColumnName("id_producto");

            builder.Property(p => p.Codigo)
                   .HasColumnName("codigo")
                   .HasMaxLength(10);

            builder.Property(p => p.IdCategoria)
                   .HasColumnName("codigo_categoria")
                   .HasMaxLength(10);

            builder.Property(p => p.IdProveedor)
                   .HasColumnName("codigo_proveedor")
                   .HasMaxLength(10);

            builder.Property(p => p.Precio)
                   .HasColumnName("precio")
                   .HasPrecision(10, 2);

            builder.Property(p => p.Descripcion)
                   .HasColumnName("descripcion")
                   .HasMaxLength(50);

            builder.Property(p => p.Comentario)
                   .HasColumnName("comentario")
                   .HasMaxLength(100);

            builder.Property(p => p.Estado)
                   .HasColumnName("estado");

            builder.Property(p => p.FechaRegistro)
                   .HasColumnName("fecha_registro")
                   .IsRequired();

            builder.Property(p => p.UsuarioRegistro)
                   .HasColumnName("usuario_registro")
                   .HasMaxLength(20);

            builder.Property(p => p.Ipv4Registro)
                   .HasColumnName("ipv4_registro")
                   .HasMaxLength(25);

            builder.Property(p => p.Ipv6Registro)
                   .HasColumnName("ipv6_registro")
                   .HasMaxLength(25);

            builder.Property(p => p.FechaModificacion)
                   .HasColumnName("fecha_modificacion")
                   .IsRequired();

            builder.Property(p => p.UsuarioModificacion)
                   .HasColumnName("usuario_modificacion")
                   .HasMaxLength(20);

            builder.Property(p => p.Ipv4Modificacion)
                   .HasColumnName("ipv4_modificacion")
                   .HasMaxLength(25);

            builder.Property(p => p.Ipv6Modificacion)
                   .HasColumnName("ipv6_modificacion")
                   .HasMaxLength(25);
        }
    }
}
