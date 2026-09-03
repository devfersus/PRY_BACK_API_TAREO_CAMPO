using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using SEGURIDAD.Infraestructura;
using SEGURIDAD.LogAuditoria_.Web.Dominio.Entidad;
using System.Reflection;
using System.Security.Claims;
using System.Text.Json;

namespace API_TAREO_CAMPO.Middleware;

public class AuditSaveChangesInterceptor(
    IDbContextFactory<AuditoriaDBContext> auditFactory,
    IHttpContextAccessor httpContextAccessor) : SaveChangesInterceptor
{
    private static readonly JsonSerializerOptions Opciones = new() { WriteIndented = false };

    // Tipos primitivos que NO son Value Objects
    private static readonly HashSet<Type> TiposPrimitivos =
    [
        typeof(string), typeof(Guid), typeof(DateTime), typeof(DateTimeOffset),
        typeof(DateOnly), typeof(TimeOnly), typeof(decimal), typeof(byte[])
    ];

    // Propiedades de auditoría interna que no aportan valor en el diff
    private static readonly HashSet<string> PropiedadesExcluidas =
    [
        "FechaRegistro", "UsuarioRegistro", "Ipv4Registro", "Ipv6Registro",
        "FechaModificacion", "UsuarioModificacion", "Ipv4Modificacion", "Ipv6Modificacion"
    ];

    private List<LogAuditoria> _pendientes = [];

    public override async ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData      eventData,
        InterceptionResult<int> result,
        CancellationToken       ct = default)
    {
        _pendientes = CapturarAuditorias(eventData.Context);
        return await base.SavingChangesAsync(eventData, result, ct);
    }

    public override async ValueTask<int> SavedChangesAsync(
        SaveChangesCompletedEventData eventData,
        int                           result,
        CancellationToken             ct = default)
    {
        if (_pendientes.Count > 0)
        {
            await using var auditCtx = await auditFactory.CreateDbContextAsync(ct);
            auditCtx.LogsAuditoria.AddRange(_pendientes);
            await auditCtx.SaveChangesAsync(ct);
            _pendientes.Clear();
        }
        return await base.SavedChangesAsync(eventData, result, ct);
    }

    private List<LogAuditoria> CapturarAuditorias(DbContext? ctx)
    {
        if (ctx is null) return [];

        var userId = ObtenerUsuarioId();
        if (userId == Guid.Empty) return [];

        return ctx.ChangeTracker.Entries()
            .Where(e => e.State is EntityState.Added or EntityState.Modified
                     && e.Entity is not LogAuditoria
                     && !e.Metadata.IsOwned())
            .Select(e =>
            {
                var nombreTabla = e.Metadata.GetTableName() ?? e.Entity.GetType().Name;
                if (nombreTabla.Length > 25)
                    nombreTabla = nombreTabla[..25];

                var accion = e.State == EntityState.Added ? "INSERTAR" : "ACTUALIZAR";

                string? valorAnterior = null;
                if (e.State == EntityState.Modified)
                    valorAnterior = JsonSerializer.Serialize(ObtenerValoresOriginales(e), Opciones);

                var valorNuevo = JsonSerializer.Serialize(EntidadADiccionario(e.Entity), Opciones);

                return LogAuditoria.Registrar(userId, nombreTabla, accion, valorAnterior, valorNuevo);
            })
            .ToList();
    }

    // valor_nuevo: serializa el entity aplanando Value Objects con una sola propiedad
    private static Dictionary<string, object?> EntidadADiccionario(object entity) =>
        entity.GetType()
            .GetProperties(BindingFlags.Public | BindingFlags.Instance)
            .Where(p => p.CanRead && !PropiedadesExcluidas.Contains(p.Name))
            .ToDictionary(p => p.Name, p => Aplanar(p.GetValue(entity)));

    // valor_anterior: valores originales del ChangeTracker, también aplanando Value Objects
    private static Dictionary<string, object?> ObtenerValoresOriginales(EntityEntry entry)
    {
        var valores = entry.Properties
            .Where(p => !PropiedadesExcluidas.Contains(p.Metadata.Name))
            .ToDictionary(p => p.Metadata.Name, p => Aplanar(p.OriginalValue));

        // Owned entities de tabla separada (ej: Email)
        foreach (var nav in entry.References
            .Where(r => r.Metadata.TargetEntityType.IsOwned() && r.TargetEntry is not null))
        {
            var navProps = nav.TargetEntry!.Properties.ToArray();
            valores[nav.Metadata.Name] = navProps.Length == 1
                ? navProps[0].OriginalValue          // Single-property → valor directo
                : (object?)navProps.ToDictionary(p => p.Metadata.Name, p => (object?)p.OriginalValue);
        }

        return valores;
    }

    // Detecta Value Objects (clase con una sola propiedad pública) y devuelve su valor interno
    private static object? Aplanar(object? value)
    {
        if (value is null) return null;
        var tipo = value.GetType();
        if (tipo.IsPrimitive || tipo.IsEnum || TiposPrimitivos.Contains(tipo))
            return value;

        var props = tipo.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                        .Where(p => p.CanRead)
                        .ToArray();

        return props.Length == 1 ? props[0].GetValue(value) : value;
    }

    private Guid ObtenerUsuarioId()
    {
        var claim = httpContextAccessor.HttpContext?.User
            .FindFirstValue(ClaimTypes.NameIdentifier)
            ?? httpContextAccessor.HttpContext?.User.FindFirstValue("sub");

        return Guid.TryParse(claim, out var id) ? id : Guid.Empty;
    }
}
