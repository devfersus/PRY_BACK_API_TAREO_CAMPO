using Microsoft.EntityFrameworkCore;
using SEGURIDAD.Infraestructura;
using SEGURIDAD.UsuarioPermiso_.Web.Aplicacion.Ports;

namespace SEGURIDAD.UsuarioPermiso_.Web.Aplicacion.CasosUso
{
    public class PermisoUsuarioConsultaServicio(SeguridadDBContext ctx) : IPermisoUsuarioConsultaServicio
    {
        public async Task<List<string>> ObtenerClavesPermisoAsync(Guid usuarioId, CancellationToken ct = default) =>
            await (
                from up in ctx.UsuarioPermisos
                join pd in ctx.PermisoDetalles on up.PermisoId equals pd.PermisoId
                join m  in ctx.Modulos         on pd.ModuloId    equals m.Id
                join sm in ctx.SubModulos       on pd.SubModuloId equals sm.Id
                join a  in ctx.Acciones         on pd.AccionId    equals a.Id
                where up.UsuarioId == usuarioId
                   && up.Activo
                   && pd.Activo
                   && m.Activo
                   && sm.Activo
                   && a.Activo
                select $"{m.Descripcion.ToUpper()}|{sm.Descripcion.ToUpper()}|{a.Descripcion.ToUpper()}"
            ).Distinct().ToListAsync(ct);
    }
}
