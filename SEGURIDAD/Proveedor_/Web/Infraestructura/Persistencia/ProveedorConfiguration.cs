using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SEGURIDAD.Proveedor_.Web.Dominio.Entidad;

namespace SEGURIDAD.Proveedor_.Web.Infraestructura.Persistencia
{
    public class ProveedorConfiguration : IEntityTypeConfiguration<Proveedor>
    {
        public void Configure(EntityTypeBuilder<Proveedor> builder)
        {
            builder.ToTable("PROVEEDOR");

            builder.HasKey(p => p.IdProveedor);
            builder.Property(p => p.IdProveedor)
                   .HasColumnName("id_proveedor");

            builder.Property(p => p.Codigo)
                   .HasColumnName("codigo")
                   .HasMaxLength(10);

            builder.Property(p => p.Descripcion)
                   .HasColumnName("descripcion")
                   .HasMaxLength(50);

            builder.Property(p => p.Comentario)
                   .HasColumnName("comentario")
                   .HasMaxLength(100);

            builder.Property(p => p.CodigoUsuario)
                   .HasColumnName("codigo_usuario")
                   .HasMaxLength(10);

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
