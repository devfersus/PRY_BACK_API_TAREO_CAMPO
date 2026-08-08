using SEGURIDAD.Accion_.Web.Dominio.Entidad;
using SEGURIDAD.Modulo_.Web.Dominio.Entidad;
using SEGURIDAD.Permiso_.Web.Dominio.Entidad;
using SEGURIDAD.SubModulo_.Web.Dominio.Entidad;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SEGURIDAD.Permiso_.Web.Infraestructura.Persistencia
{
    public class PermisoDetalleConfiguration : IEntityTypeConfiguration<PermisoDetalle>
    {
        public void Configure(EntityTypeBuilder<PermisoDetalle> builder)
        {
            builder.ToTable("PERMISO_DETALLE");
            builder.HasKey(pd => pd.Id);
            builder.Property(pd => pd.Id).HasColumnName("permiso_detalle_id");
            builder.Property(pd => pd.PermisoId).HasColumnName("permiso_id").IsRequired();
            builder.Property(pd => pd.ModuloId).HasColumnName("modulo_id").IsRequired();
            builder.Property(pd => pd.SubModuloId).HasColumnName("sub_modulo_id").IsRequired();
            builder.Property(pd => pd.AccionId).HasColumnName("accion_id").IsRequired();
            builder.Property(pd => pd.Activo).HasColumnName("activo").IsRequired();

            builder.HasOne<Permiso>()
                   .WithMany()
                   .HasForeignKey(pd => pd.PermisoId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(pd => pd.Modulo)
                   .WithMany()
                   .HasForeignKey(pd => pd.ModuloId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(pd => pd.SubModulo)
                   .WithMany()
                   .HasForeignKey(pd => pd.SubModuloId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(pd => pd.Accion)
                   .WithMany()
                   .HasForeignKey(pd => pd.AccionId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
