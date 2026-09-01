using SEGURIDAD.Usuario_.Web.Dominio.ValueObject;

namespace SEGURIDAD.Usuario_.Web.Dominio.Entidad
{
    public class Usuario
    {
        public Guid Id { get; private set; }
        public string? Codigo { get; private set; }
        public Nombre Nombre { get; private set; }
        public ApellidoMaterno ApellidoMaterno { get; private set; }
        public ApellidoPaterno ApellidoPaterno { get; private set; }
        public Email Email { get; private set; }
        public string Contraseña { get; private set; }
        public bool Activo { get; private set; }
        public DateTime FechaCreacion { get; private set; }
        public DateTime? FechaModificacion { get; private set; }
        private Usuario() { }
        private Usuario(Guid id,
              string?          codigo
            , Nombre           nombre
            , ApellidoMaterno  apellidoMaterno
            , ApellidoPaterno  apellidoPaterno
            , Email            email
            , string           contraseña)
        {
            Id              = id;
            Codigo          = codigo?.Trim();
            Nombre          = nombre;
            ApellidoMaterno = apellidoMaterno;
            ApellidoPaterno = apellidoPaterno;
            Email           = email;
            Contraseña      = contraseña;
            Activo          = true;
            FechaCreacion   = DateTime.UtcNow;
        }
        public static Usuario Registrar(
             string?          codigo
            , Nombre           nombre
            , ApellidoMaterno  apellidoMaterno
            , ApellidoPaterno  apellidoPaterno
            , Email            email
            , string           contraseña
            )
        {
            return new Usuario(Guid.NewGuid()
                ,codigo
                ,nombre
                ,apellidoMaterno
                ,apellidoPaterno
                ,email
                ,contraseña
                );
        }

        public void Actualizar(
             string?          codigo
            , Nombre           nombre
            , ApellidoMaterno  apellidoMaterno
            , ApellidoPaterno  apellidoPaterno
            , Email            email
            , string?          contraseña
            , bool             activo
            )
        {
            Codigo            = codigo?.Trim();
            Nombre            = nombre;
            ApellidoMaterno   = apellidoMaterno;
            ApellidoPaterno   = apellidoPaterno;
            Email             = email;
            Activo            = activo;
            if (!string.IsNullOrWhiteSpace(contraseña))
                Contraseña    = contraseña;
            FechaModificacion = DateTime.UtcNow;
        }

        public void EliminarLogico() => Activo = false;
    }
}
