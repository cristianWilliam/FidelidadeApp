using FidelidadeApp.Core.Models;
using System;

namespace FidelidadeApp.Domain.Entities
{
    public class ProdutoVenda : Entity
    {
        public Guid MovimentacaoId { get; private set; }
        public Guid ProdutoId {get; private set; }
        public Endereco Endereco {get; private set; }
        public StatusEntrega StatusEntrega {get; private set; }

        // Ef Relations
        public UsuarioExtratoMovimentacao Movimentacao { get; private set; }
        public Produto Produto { get; private set; }

        protected ProdutoVenda() { }

        public ProdutoVenda(Guid id, Guid movimentacaoId, Guid produtoId, Endereco endereco)
        {
            Id = id;
            MovimentacaoId = movimentacaoId;
            ProdutoId = produtoId;
            Endereco = endereco;
            StatusEntrega = StatusEntrega.EmTransito;
        }

        public void DefinirComoEntregue()
        {
            StatusEntrega = StatusEntrega.Entregue;
        }
    }
}
