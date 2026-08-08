using SEGURIDAD.Usuario_.Web.Dominio.Exceptions;

namespace SEGURIDAD.Usuario_.Web.Dominio.ValueObject
{
    public class Nombre
    {
        public string Value { get; }

        private Nombre(string value)
        {
            Value = value;
        }

        public static Nombre Agregar(string nombres)
        {
            if (string.IsNullOrWhiteSpace(nombres))
                throw new DominiIoExceptionUsuario("Los nombres no pueden estar vacíos.");

            return new Nombre(nombres.Trim());
        }

    }
}
