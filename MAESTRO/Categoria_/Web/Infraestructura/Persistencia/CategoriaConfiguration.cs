using MAESTRO.Categoria_.Web.Dominio.Entidad;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MAESTRO.Categoria_.Web.Infraestructura.Persistencia
{
    public class CategoriaConfiguration : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.ToTable("CATEGORIA");

            builder.HasKey(c => c.IdCategoria);
            builder.Property(c => c.IdCategoria)
                   .HasColumnName("ID_CATEGORIA");

            builder.Property(c => c.Codigo)
                   .HasColumnName("CODIGO")
                   .HasMaxLength(10);

            builder.Property(c => c.Descripcion)
                   .HasColumnName("DESCRIPCION")
                   .HasMaxLength(50);

            builder.Property(c => c.Comentario)
                   .HasColumnName("COMENTARIO")
                   .HasMaxLength(100);

            builder.Property(c => c.Estado)
                   .HasColumnName("ESTADO");

            builder.Property(c => c.FechaRegistro)
                   .HasColumnName("FECHA_REGISTRO")
                   .IsRequired();

            builder.Property(c => c.UsuarioRegistro)
                   .HasColumnName("USUARIO_REGISTRO")
                   .HasMaxLength(20);

            builder.Property(c => c.Ipv4Registro)
                   .HasColumnName("IPV4_REGISTRO")
                   .HasMaxLength(25);

            builder.Property(c => c.Ipv6Registro)
                   .HasColumnName("IPV6_REGISTRO")
                   .HasMaxLength(25);

            builder.Property(c => c.FechaModificacion)
                   .HasColumnName("FECHA_MODIFICACION")
                   .IsRequired();

            builder.Property(c => c.UsuarioModificacion)
                   .HasColumnName("USUARIO_MODIFICACION")
                   .HasMaxLength(20);

            builder.Property(c => c.Ipv4Modificacion)
                   .HasColumnName("IPV4_MODIFICACION")
                   .HasMaxLength(25);

            builder.Property(c => c.Ipv6Modificacion)
                   .HasColumnName("IPV6_MODIFICACION")
                   .HasMaxLength(25);
        }
    }
}
