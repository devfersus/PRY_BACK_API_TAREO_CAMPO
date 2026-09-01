using CORE.Ajuste_.Web.Dominio.Entidad;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CORE.Ajuste_.Web.Infraestructura.Persistencia
{
    public class AjusteDetalleConfiguration : IEntityTypeConfiguration<AjusteDetalle>
    {
        public void Configure(EntityTypeBuilder<AjusteDetalle> builder)
        {
            builder.ToTable("AJUSTE_DETALLE");

            builder.HasKey(a => a.IdAjusteDetalle);
            builder.Property(a => a.IdAjusteDetalle)
                   .HasColumnName("ajuste_detalle_id");

            builder.Property(a => a.CodigoAjuste)
                   .HasColumnName("codigo_ajuste")
                   .HasMaxLength(10);

            builder.Property(a => a.CodigoAlmacen)
                   .HasColumnName("codigo_almacen")
                   .HasMaxLength(10);

            builder.Property(a => a.CodigoProducto)
                   .HasColumnName("codigo_producto")
                   .HasMaxLength(10);

            builder.Property(a => a.CantidadSistema)
                   .HasColumnName("cantidad_sistema")
                   .HasPrecision(10, 2);

            builder.Property(a => a.CantidadFisica)
                   .HasColumnName("cantidad_fisica")
                   .HasPrecision(10, 2);

            builder.Property(a => a.Diferencia)
                   .HasColumnName("diferencia")
                   .HasPrecision(10, 2);

            builder.Property(a => a.Comentario)
                   .HasColumnName("comentario")
                   .HasMaxLength(200);

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
