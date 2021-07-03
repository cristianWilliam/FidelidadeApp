using FidelidadeApp.Core.DomainObjects;
using FidelidadeApp.Core.Interfaces;
using FidelidadeApp.Core.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace FidelidadeApp.Domain.Entities
{
    public class AuthUsuario : IdentityUser<Guid>, IAggregateRoot
    {
        public string Nome { get; private set; }
        public UsuarioEndereco EnderecoEntrega { get; private set; }
        public UsuarioSaldo Saldo { get; private set; }

        private List<UsuarioExtratoMovimentacao> _extratoMovimentacoes;
        public IReadOnlyCollection<UsuarioExtratoMovimentacao> ExtratoMovimentacoes => _extratoMovimentacoes;

        
        protected AuthUsuario() {
            _extratoMovimentacoes ??= new List<UsuarioExtratoMovimentacao>();
        }

        public AuthUsuario(Guid id, string nome, Email email, UsuarioEndereco enderecoEntrega = null)
        {
            Id = id;
            Nome = nome;
            EnderecoEntrega = enderecoEntrega;
            Email = email.Valor;
            UserName = email.Valor;
            _extratoMovimentacoes = new List<UsuarioExtratoMovimentacao>();
        }

        public void AlterarEnderecoEntrega(Endereco endereco)
        {
            if (EnderecoEntrega != null)
                EnderecoEntrega.AlterarEndereco(endereco);
            else
                EnderecoEntrega = new UsuarioEndereco(Guid.NewGuid(), this.Id, endereco);
        }

        public void Validar()
        {
            Validacoes.SeVazio(Nome, "Nome não pode ser vazio!");
        }

        public void DefinirSaldoAtual(int pontos)
        {
            Saldo = new UsuarioSaldo(Guid.NewGuid(), this.Id, pontos);
        }

        public void AddExtrato(UsuarioExtratoMovimentacao movimentacao)
        {
            _extratoMovimentacoes ??= new List<UsuarioExtratoMovimentacao>();
            _extratoMovimentacoes.Add(movimentacao);
        }
    }
}
