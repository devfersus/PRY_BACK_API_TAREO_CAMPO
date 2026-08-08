using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SEGURIDAD.Usuario_.Web.Dominio.Entidad;
using SEGURIDAD.Usuario_.Web.Dominio.ValueObject;

namespace SEGURIDAD.Usuario_.Web.Infraestructura.Persistencia
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("USUARIO");
            builder.HasKey(u => u.Id);

            // Value Object -> columnas planas con conversores.
            builder.Property(u => u.Nombre)
                .HasConversion(n => n.Value, s => Nombre.Agregar(s))
                .HasMaxLength(512).IsRequired();

            builder.Property(u => u.ApellidoMaterno)
                .HasConversion(am => am.Value, s => ApellidoMaterno.Agregar(s))
                .HasMaxLength(512).IsRequired();

            builder.Property(u => u.ApellidoPaterno)
                .HasConversion(ap => ap.Value, s => ApellidoPaterno.Agregar(s))
                .HasMaxLength(512).IsRequired();

            // Value Object Email -> columna única.
            builder.OwnsOne(u => u.Email, eb =>
            {
                eb.Property(e => e.Valor).HasColumnName("Email").HasMaxLength(256).IsRequired();
                eb.HasIndex(e => e.Valor).IsUnique();
            });

            builder.Property(u => u.Contraseña).HasMaxLength(512).IsRequired();
            builder.Property(u => u.Activo).IsRequired();
            builder.Property(u => u.FechaCreacion).IsRequired();
            builder.Property(u => u.FechaModificacion);
        }
    }
}