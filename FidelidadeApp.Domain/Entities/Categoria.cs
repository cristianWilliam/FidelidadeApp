using FidelidadeApp.Core.DomainObjects;
using FidelidadeApp.Core.Models;
using System;
using System.Collections.Generic;

namespace FidelidadeApp.Domain.Entities
{
    public class Categoria : Entity
    {
        public string Nome { get; private set; }
        public Guid? CategoriaPaiId { get; private set; } = null;
        
        // Ef Navigation Property
        public Categoria CategoriaPai { get; private set; }
        public IEnumerable<Categoria> CategoriasFilhas { get; private set; }
        public IEnumerable<ProdutoCategoria> ProdutoCategorias { get; private set; }

        protected Categoria() {
            Id = Guid.NewGuid();
        }

        public Categoria(Guid id, string nome, Guid? categoriaPaiId = null)
        {
            Id = Id;
            Nome = nome;
            CategoriaPaiId = categoriaPaiId;
            Validar();
        }

        private void Validar()
        {
            Validacoes.SeVazio(Nome, "Nome Categoria deve ser preenchido!");
        }
    }
}
