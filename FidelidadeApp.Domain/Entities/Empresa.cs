using FidelidadeApp.Core.DomainObjects;
using FidelidadeApp.Core.Models;
using System;
using System.Collections.Generic;
using FidelidadeApp.Core.Interfaces;

namespace FidelidadeApp.Domain.Entities
{

    public class Empresa : Entity, IAggregateRoot
    {
        public string Cnpj { get; private set; }
        public string Nome { get; private set; }

        public IEnumerable<UsuarioExtratoMovimentacao> UsuarioMovimentacoes { get; private set; }

        public Empresa(Guid id, Cnpj cnpj, string nome)
        {
            Id = id;
            Cnpj = cnpj.Valor;
            Nome = nome;
            Validar();
        }

        // Ef precisa de um construtor vazio.
        protected Empresa() { }

        private void Validar()
        {
            Validacoes.SeVazio(Id, "Id não pode ser vazio");
            Validacoes.SeVazio(Nome, "Nome não deve ser vazio");
        }
    }
}
