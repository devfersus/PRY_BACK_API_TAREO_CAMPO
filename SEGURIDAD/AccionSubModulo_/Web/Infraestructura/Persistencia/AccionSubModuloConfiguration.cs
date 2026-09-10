using SEGURIDAD.Accion_.Web.Dominio.Entidad;
using SEGURIDAD.AccionSubModulo_.Web.Dominio.Entidad;
using SEGURIDAD.SubModulo_.Web.Dominio.Entidad;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SEGURIDAD.AccionSubModulo_.Web.Infraestructura.Persistencia
{
    public class AccionSubModuloConfiguration : IEntityTypeConfiguration<AccionSubModulo>
    {
        public void Configure(EntityTypeBuilder<AccionSubModulo> builder)
        {
            builder.ToTable("accion_sub_modulo");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).HasColumnName("id");
            builder.Property(a => a.SubModuloId).HasColumnName("submoduloid").IsRequired();
            builder.Property(a => a.AccionId).HasColumnName("accionid").IsRequired();
            builder.Property(a => a.Activo).HasColumnName("activo").IsRequired();

            builder.HasOne<SubModulo>()
                   .WithMany()
                   .HasForeignKey(a => a.SubModuloId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<Accion>()
                   .WithMany()
                   .HasForeignKey(a => a.AccionId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
