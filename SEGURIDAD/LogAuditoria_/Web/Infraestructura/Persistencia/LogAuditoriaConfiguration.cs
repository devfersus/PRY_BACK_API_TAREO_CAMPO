using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SEGURIDAD.LogAuditoria_.Web.Dominio.Entidad;

namespace SEGURIDAD.LogAuditoria_.Web.Infraestructura.Persistencia;

public class LogAuditoriaConfiguration : IEntityTypeConfiguration<LogAuditoria>
{
    public void Configure(EntityTypeBuilder<LogAuditoria> builder)
    {
        builder.ToTable("LOG_AUDITORIA");
        builder.HasKey(l => l.IdLogAuditoria);

        builder.Property(l => l.IdLogAuditoria)
               .HasColumnName("id_log_auditoria");

        builder.Property(l => l.UsuarioRegistro)
               .HasColumnName("usuario_registro")
               .IsRequired();

        builder.Property(l => l.NombreTabla)
               .HasColumnName("nombre_tabla")
               .HasMaxLength(25)
               .IsRequired();

        builder.Property(l => l.Accion)
               .HasColumnName("accion")
               .HasMaxLength(25)
               .IsRequired();

        builder.Property(l => l.FechaRegistro)
               .HasColumnName("fecha_registro");

        builder.Property(l => l.ValorAnterior)
               .HasColumnName("valor_anterior");

        builder.Property(l => l.ValorNuevo)
               .HasColumnName("valor_nuevo");
    }
}
