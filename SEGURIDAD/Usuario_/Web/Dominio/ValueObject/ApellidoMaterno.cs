using SEGURIDAD.Usuario_.Web.Dominio.Exceptions;

namespace SEGURIDAD.Usuario_.Web.Dominio.ValueObject
{
    public class ApellidoMaterno
    {
        public string Value { get; }

        private ApellidoMaterno(string value) => Value = value;

        public static ApellidoMaterno Agregar(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new DominiIoExceptionUsuario("El apellido materno no puede estar vacío.");
            return new ApellidoMaterno(value.Trim());
        }
    }
}
