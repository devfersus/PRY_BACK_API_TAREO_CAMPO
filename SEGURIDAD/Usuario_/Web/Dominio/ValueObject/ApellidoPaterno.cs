using SEGURIDAD.Usuario_.Web.Dominio.Exceptions;

namespace SEGURIDAD.Usuario_.Web.Dominio.ValueObject
{
    public class ApellidoPaterno
    {
        public string Value { get; }

        private ApellidoPaterno(string value) => Value = value;

        public static ApellidoPaterno Agregar(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new DominiIoExceptionUsuario("El apellido paterno no puede estar vacío.");
            return new ApellidoPaterno(value.Trim());
        }
    }
}
