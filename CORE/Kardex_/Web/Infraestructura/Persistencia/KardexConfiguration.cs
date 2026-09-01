using CORE.Kardex_.Web.Dominio.Entidad;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CORE.Kardex_.Web.Infraestructura.Persistencia
{
    public class KardexConfiguration : IEntityTypeConfiguration<Kardex>
    {
        public void Configure(EntityTypeBuilder<Kardex> builder)
        {
            builder.ToTable("KARDEX");

            builder.HasKey(k => k.IdKardex);
            builder.Property(k => k.IdKardex)
                   .HasColumnName("id_kardex");

            builder.Property(k => k.TipoMovimiento)
                   .HasColumnName("tipo_movimiento")
                   .HasMaxLength(10)
                   .IsRequired();

            builder.Property(k => k.CodigoProducto)
                   .HasColumnName("codigo_producto")
                   .HasMaxLength(10);

            builder.Property(k => k.CodigoAlmacen)
                   .HasColumnName("codigo_almacen")
                   .HasMaxLength(10);

            builder.Property(k => k.Cantidad)
                   .HasColumnName("cantidad")
                   .HasPrecision(10, 2)
                   .IsRequired();

            builder.Property(k => k.SaldoUnidades)
                   .HasColumnName("saldo_unidades")
                   .HasPrecision(10, 2)
                   .IsRequired();

            builder.Property(k => k.ReferenciaTipo)
                   .HasColumnName("referencia_tipo")
                   .HasMaxLength(10);

            builder.Property(k => k.ReferenciaCodig)
                   .HasColumnName("referencia_codigo")
                   .HasMaxLength(10);

            builder.Property(k => k.FechaMovimiento)
                   .HasColumnName("fecha_movimiento")
                   .IsRequired();

            builder.Property(k => k.UsuarioRegistro)
                   .HasColumnName("usuario_registro")
                   .HasMaxLength(20);
        }
    }
}
