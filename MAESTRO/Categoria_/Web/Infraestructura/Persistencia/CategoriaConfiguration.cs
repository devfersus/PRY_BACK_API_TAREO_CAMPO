using MAESTRO.Categoria_.Web.Dominio.Entidad;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MAESTRO.Categoria_.Web.Infraestructura.Persistencia
{
    public class CategoriaConfiguration : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.ToTable("categoria");

            builder.HasKey(c => c.IdCategoria);
            builder.Property(c => c.IdCategoria)
                   .HasColumnName("id_categoria");

            builder.Property(c => c.Codigo)
                   .HasColumnName("codigo")
                   .HasMaxLength(10);

            builder.Property(c => c.Descripcion)
                   .HasColumnName("descripcion")
                   .HasMaxLength(50);

            builder.Property(c => c.Comentario)
                   .HasColumnName("comentario")
                   .HasMaxLength(100);

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
