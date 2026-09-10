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
            builder.ToTable("usuario");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).HasColumnName("id");

            // Value Object -> columnas planas con conversores.
            builder.Property(u => u.Nombre)
                .HasColumnName("nombre")
                .HasConversion(n => n.Value, s => Nombre.Agregar(s))
                .HasMaxLength(512).IsRequired();

            builder.Property(u => u.ApellidoMaterno)
                .HasColumnName("apellidomaterno")
                .HasConversion(am => am.Value, s => ApellidoMaterno.Agregar(s))
                .HasMaxLength(512).IsRequired();

            builder.Property(u => u.ApellidoPaterno)
                .HasColumnName("apellidopaterno")
                .HasConversion(ap => ap.Value, s => ApellidoPaterno.Agregar(s))
                .HasMaxLength(512).IsRequired();

            // Value Object Email -> columna única.
            builder.OwnsOne(u => u.Email, eb =>
            {
                eb.Property(e => e.Valor).HasColumnName("email").HasMaxLength(256).IsRequired();
                eb.HasIndex(e => e.Valor).IsUnique();
            });

            builder.Property(u => u.Codigo).HasColumnName("codigo").HasMaxLength(10);

            builder.Property(u => u.Contraseña).HasColumnName("contraseña").HasMaxLength(512).IsRequired();
            builder.Property(u => u.Activo).HasColumnName("activo").IsRequired();
            builder.Property(u => u.FechaCreacion).HasColumnName("fechacreacion").IsRequired();
            builder.Property(u => u.FechaModificacion).HasColumnName("fechamodificacion");
        }
    }
}