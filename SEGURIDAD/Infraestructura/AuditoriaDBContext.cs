using Microsoft.EntityFrameworkCore;
using SEGURIDAD.LogAuditoria_.Web.Dominio.Entidad;
using SEGURIDAD.LogAuditoria_.Web.Infraestructura.Persistencia;

namespace SEGURIDAD.Infraestructura;

public class AuditoriaDBContext(DbContextOptions<AuditoriaDBContext> options) : DbContext(options)
{
    public DbSet<LogAuditoria> LogsAuditoria => Set<LogAuditoria>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new LogAuditoriaConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}
