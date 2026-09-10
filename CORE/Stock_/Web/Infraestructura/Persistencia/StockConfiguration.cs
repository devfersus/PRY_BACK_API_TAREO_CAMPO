using CORE.Stock_.Web.Dominio.Entidad;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CORE.Stock_.Web.Infraestructura.Persistencia
{
    public class StockConfiguration : IEntityTypeConfiguration<Stock>
    {
        public void Configure(EntityTypeBuilder<Stock> builder)
        {
            builder.ToTable("stock");

            builder.HasKey(s => s.IdStock);
            builder.Property(s => s.IdStock)
                   .HasColumnName("id_stock");

            builder.Property(s => s.CodigoProducto)
                   .HasColumnName("codigo_producto")
                   .HasMaxLength(10);

            builder.Property(s => s.CodigoAlmacen)
                   .HasColumnName("codigo_almacen")
                   .HasMaxLength(10);

            builder.Property(s => s.StockActual)
                   .HasColumnName("stock_actual")
                   .HasPrecision(10, 2);

            builder.Property(s => s.StockMinimo)
                   .HasColumnName("stock_minimo")
                   .HasPrecision(10, 2);

            builder.Property(s => s.StockMaximo)
                   .HasColumnName("stock_maximo")
                   .HasPrecision(10, 2);

            builder.Property(s => s.FechaActualizacion)
                   .HasColumnName("fecha_actualizacion")
                   .IsRequired();
        }
    }
}
