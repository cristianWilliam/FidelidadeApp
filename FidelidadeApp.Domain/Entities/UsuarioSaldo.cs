using FidelidadeApp.Core.DomainObjects;
using FidelidadeApp.Core.Models;
using System;

namespace FidelidadeApp.Domain.Entities
{
    public class UsuarioSaldo : Entity
    {
        public Guid UsuarioId { get; private set; }
        public int PontosAtuais { get; private set; }

        // Ef Relations
        public AuthUsuario Usuario { get; private set; }

        protected UsuarioSaldo() { }

        public UsuarioSaldo(Guid id, Guid usuarioId, int pontosAtuais)
        {
            Id = id;
            UsuarioId = usuarioId;
            PontosAtuais = pontosAtuais;
            Validar();
        }

        public void Validar()
        {
            Validacoes.SeMenorQue(PontosAtuais, 0, "Valor deve ser no minimo zero");
        }

        public void DebitarSaldo(int saldoDebitar)
        {
            if (saldoDebitar < 0)
                saldoDebitar *= -1;

            PontosAtuais -= saldoDebitar;
            Validar();
        }
    }
}
