using CORE.Compra_.Web.Dominio.Entidad;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CORE.Compra_.Web.Infraestructura.Persistencia
{
    public class CompraDetalleConfiguration : IEntityTypeConfiguration<CompraDetalle>
    {
        public void Configure(EntityTypeBuilder<CompraDetalle> builder)
        {
            builder.ToTable("COMPRA_DETALLE");

            builder.HasKey(c => c.IdCompraDetalle);
            builder.Property(c => c.IdCompraDetalle)
                   .HasColumnName("compra_detalle_id");

            builder.Property(c => c.CodigoCompra)
                   .HasColumnName("codigo_compra")
                   .HasMaxLength(10);

            builder.Property(c => c.CodigoAlmacen)
                   .HasColumnName("codigo_almacen")
                   .HasMaxLength(10);

            builder.Property(c => c.Unidad)
                   .HasColumnName("unidad")
                   .HasPrecision(10, 2);

            builder.Property(c => c.Cantidad)
                   .HasColumnName("cantidad")
                   .HasPrecision(10, 2);

            builder.Property(c => c.CodigoProducto)
                   .HasColumnName("codigo_producto")
                   .HasMaxLength(10);

            builder.Property(c => c.Comentario)
                   .HasColumnName("comentario")
                   .HasMaxLength(200);

            builder.Property(c => c.Estado)
                   .HasColumnName("estado");

            builder.Property(c => c.FechaRegistro)
                   .HasColumnName("fecha_registro")
                   .IsRequired();

            builder.Property(c => c.UsuarioRegistro)
                   .HasColumnName("usuario_registro")
                   .HasMaxLength(20);

            builder.Property(c => c.Ipv4Registro)
                   .HasColumnName("ipv4_registro")
                   .HasMaxLength(25);

            builder.Property(c => c.Ipv6Registro)
                   .HasColumnName("ipv6_registro")
                   .HasMaxLength(25);

            builder.Property(c => c.FechaModificacion)
                   .HasColumnName("fecha_modificacion")
                   .IsRequired();

            builder.Property(c => c.UsuarioModificacion)
                   .HasColumnName("usuario_modificacion")
                   .HasMaxLength(20);

            builder.Property(c => c.Ipv4Modificacion)
                   .HasColumnName("ipv4_modificacion")
                   .HasMaxLength(25);

            builder.Property(c => c.Ipv6Modificacion)
                   .HasColumnName("ipv6_modificacion")
                   .HasMaxLength(25);
        }
    }
}
