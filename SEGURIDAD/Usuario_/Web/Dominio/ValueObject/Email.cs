using SEGURIDAD.Usuario_.Web.Dominio.Exceptions;
using System.Text.RegularExpressions;

namespace SEGURIDAD.Usuario_.Web.Dominio.ValueObject
{
    public class Email
    {
        private static readonly Regex Patron = new(
        @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
        RegexOptions.Compiled | RegexOptions.IgnoreCase);

        public string Valor { get; }

        private Email(string valor) => Valor = valor;

        public static Email Agregar(string valor)
        {
            if (string.IsNullOrWhiteSpace(valor))
                throw new DominiIoExceptionUsuario("El email no puede estar vacío.");

            valor = valor.Trim().ToLowerInvariant();

            if (!Patron.IsMatch(valor))
                throw new DominiIoExceptionUsuario($"El email '{valor}' no tiene un formato válido.");

            return new Email(valor);
        }

        public override string ToString() => Valor;
    }
}
