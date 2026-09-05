using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SEGURIDAD.Permiso_.Web.Dominio.Entidad;
using SEGURIDAD.Usuario_.Web.Dominio.Entidad;
using SEGURIDAD.UsuarioPermiso_.Web.Dominio.Entidad;

namespace SEGURIDAD.UsuarioPermiso_.Web.Infraestructura.Persistencia
{
    public class UsuarioPermisoConfiguration : IEntityTypeConfiguration<UsuarioPermiso>
    {
        public void Configure(EntityTypeBuilder<UsuarioPermiso> builder)
        {
            builder.ToTable("USUARIO_PERMISO");

            builder.HasKey(up => up.Id);
            builder.Property(up => up.Id)
                   .HasColumnName("usuario_permiso_id");

            builder.Property(up => up.UsuarioId)
                   .HasColumnName("usuario_id")
                   .IsRequired();

            builder.Property(up => up.PermisoId)
                   .HasColumnName("permiso_id")
                   .IsRequired();

            builder.Property(up => up.Activo)
                   .HasColumnName("activo")
                   .IsRequired();

            builder.HasIndex(up => new { up.UsuarioId, up.PermisoId })
                   .IsUnique()
                   .HasDatabaseName("UX_USUARIO_PERMISO_usuario_permiso");

            builder.HasOne<Usuario>()
                   .WithMany()
                   .HasForeignKey(up => up.UsuarioId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne<Permiso>()
                   .WithMany()
                   .HasForeignKey(up => up.PermisoId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
