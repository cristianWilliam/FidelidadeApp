using FidelidadeApp.Core.DomainObjects;
using FidelidadeApp.Core.Interfaces;
using FidelidadeApp.Core.Models;
using System;
using System.Collections.Generic;

namespace FidelidadeApp.Domain.Entities
{
    public class Produto : Entity, IAggregateRoot
    {
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public int ValorPontos { get; private set; }
        public DateTime DataCadastro { get; private set; }

        private readonly List<ProdutoCategoria> _produtoCategorias;
        public IReadOnlyCollection<ProdutoCategoria> ProdutoCategorias { get => _produtoCategorias; }
        public ProdutoVenda ProdutoVenda { get; private set; }

        protected Produto() { }

        public Produto(Guid id, string nome, string descricao, int valorPontos)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
            ValorPontos = valorPontos;
            DataCadastro = DateTime.Now;

            _produtoCategorias = new List<ProdutoCategoria>();

            Validar();
        }

        public void Validar()
        {
            Validacoes.SeVazio(Nome, "Nome deve ser preenchido");
        }

        public void AddCategoria(Guid categoriaId)
        {
            _produtoCategorias.Add(new ProdutoCategoria(this.Id, categoriaId));
        }

        public void AddCategoria(Categoria categoria)
        {
            _produtoCategorias.Add(new ProdutoCategoria(this.Id, categoria));
        }

        public void Vender(Guid movimentacaoId, Endereco endereco)
        {
            if (ProdutoVenda != null)
                throw new DomainException("Produto nao esta mais disponivel");

            ProdutoVenda = new ProdutoVenda(Guid.NewGuid(), movimentacaoId, this.Id, endereco);
        }
    }
}
