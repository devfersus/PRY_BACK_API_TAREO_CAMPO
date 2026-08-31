using MAESTRO.Producto_.Web.Dominio.Entidad;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MAESTRO.Producto_.Web.Infraestructura.Persistencia
{
    public class ProductoConfiguration : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            builder.ToTable("PRODUCTO");

            builder.HasKey(p => p.IdProducto);
            builder.Property(p => p.IdProducto)
                   .HasColumnName("ID_PRODUCTO");

            builder.Property(p => p.Codigo)
                   .HasColumnName("CODIGO")
                   .HasMaxLength(10);

            builder.Property(p => p.IdCategoria)
                   .HasColumnName("CODIGO_CATEGORIA")
                   .HasMaxLength(10);

            builder.Property(p => p.IdProveedor)
                   .HasColumnName("CODIGO_PROVEEDOR")
                   .HasMaxLength(10);

            builder.Property(p => p.Precio)
                   .HasColumnName("PRECIO")
                   .HasPrecision(10, 2);

            builder.Property(p => p.Descripcion)
                   .HasColumnName("DESCRIPCION")
                   .HasMaxLength(50);

            builder.Property(p => p.Comentario)
                   .HasColumnName("COMENTARIO")
                   .HasMaxLength(100);

            builder.Property(p => p.Estado)
                   .HasColumnName("ESTADO");

            builder.Property(p => p.FechaRegistro)
                   .HasColumnName("FECHA_REGISTRO")
                   .IsRequired();

            builder.Property(p => p.UsuarioRegistro)
                   .HasColumnName("USUARIO_REGISTRO")
                   .HasMaxLength(20);

            builder.Property(p => p.Ipv4Registro)
                   .HasColumnName("IPV4_REGISTRO")
                   .HasMaxLength(25);

            builder.Property(p => p.Ipv6Registro)
                   .HasColumnName("IPV6_REGISTRO")
                   .HasMaxLength(25);

            builder.Property(p => p.FechaModificacion)
                   .HasColumnName("FECHA_MODIFICACION")
                   .IsRequired();

            builder.Property(p => p.UsuarioModificacion)
                   .HasColumnName("USUARIO_MODIFICACION")
                   .HasMaxLength(20);

            builder.Property(p => p.Ipv4Modificacion)
                   .HasColumnName("IPV4_MODIFICACION")
                   .HasMaxLength(25);

            builder.Property(p => p.Ipv6Modificacion)
                   .HasColumnName("IPV6_MODIFICACION")
                   .HasMaxLength(25);
        }
    }
}
