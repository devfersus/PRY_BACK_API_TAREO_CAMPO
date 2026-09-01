using CORE.Stock_.Web.Dominio.Entidad;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CORE.Stock_.Web.Infraestructura.Persistencia
{
    public class StockConfiguration : IEntityTypeConfiguration<Stock>
    {
        public void Configure(EntityTypeBuilder<Stock> builder)
        {
            builder.ToTable("STOCK");

            builder.HasKey(s => s.IdStock);
            builder.Property(s => s.IdStock)
                   .HasColumnName("ID_STOCK");

            builder.Property(s => s.CodigoProducto)
                   .HasColumnName("CODIGO_PRODUCTO")
                   .HasMaxLength(10);

            builder.Property(s => s.CodigoAlmacen)
                   .HasColumnName("CODIGO_ALMACEN")
                   .HasMaxLength(10);

            builder.Property(s => s.StockActual)
                   .HasColumnName("STOCK_ACTUAL")
                   .HasPrecision(10, 2);

            builder.Property(s => s.StockMinimo)
                   .HasColumnName("STOCK_MINIMO")
                   .HasPrecision(10, 2);

            builder.Property(s => s.StockMaximo)
                   .HasColumnName("STOCK_MAXIMO")
                   .HasPrecision(10, 2);

            builder.Property(s => s.FechaActualizacion)
                   .HasColumnName("FECHA_ACTUALIZACION")
                   .IsRequired();
        }
    }
}
