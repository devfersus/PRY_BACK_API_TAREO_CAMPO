using CORE.TareoCosecha_.Web.Aplicacion.DTOs;
using CORE.TareoCosecha_.Web.Aplicacion.Ports;
using CORE.TareoCosecha_.Web.Dominio.Entidad;
using CORE.TareoCosecha_.Web.Dominio.Interface;

namespace CORE.TareoCosecha_.Web.Aplicacion.CasosUso
{
    public class TareoCosechaServicioAplicacion(ITareoCosechaRepository tareoCosechaRepository)
        : ITareoCosechaCasoUso
    {
        public async Task RegistrarMasivoAsync(
            RegistrarTareoCosechaMasivoDTO request,
            CancellationToken ct = default)
        {
            var registros = request.Items
                .Select(item => TareoCosecha.Registrar(
                    item.EnvaseId,
                    item.FechaCosecha,
                    item.FechaRegistroMovil,
                    item.Latitud,
                    item.Longitud,
                    item.TipoCosechaId,
                    item.TipoEnvaseId,
                    item.DniJabero,
                    item.NivelEnvaseId,
                    item.FundoId,
                    item.VariedadId,
                    item.CalidadId,
                    item.DniCosechador,
                    item.GrupoId,
                    item.SubgrupoId,
                    item.TipoCosechadorId,
                    item.CantidadEnvases,
                    item.Activo,
                    item.Sincronizado,
                    item.UsuarioRegistro,
                    item.Ipv4Registro,
                    item.Ipv6Registro,
                    item.DireccionMacRegistro,
                    item.LocalizacionGpsMovilRegistro,
                    item.TipoRedMovilRegistro,
                    item.VersionAplicativoMovilRegistro,
                    item.InformacionDispositivoMovilRegistro))
                .ToList();

            await tareoCosechaRepository.AgregarMasivoAsync(registros, ct);
        }
    }
}
