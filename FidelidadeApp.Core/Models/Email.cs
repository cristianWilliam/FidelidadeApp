using FidelidadeApp.Core.DomainObjects;
using System.Net.Mail;

namespace FidelidadeApp.Core.Models
{
    public class Email
    {
        public string Valor { get; private set; }

        public Email(string valor)
        {
            if (!MailAddress.TryCreate(valor, out var valorResult))
                throw new DomainException("Email Inválido");

            Valor = valorResult.Address;
        }
    }
}
