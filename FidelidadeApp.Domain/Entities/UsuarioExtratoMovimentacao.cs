using FidelidadeApp.Core.DomainObjects;
using FidelidadeApp.Core.Models;
using System;

namespace FidelidadeApp.Domain.Entities
{
    public class UsuarioExtratoMovimentacao : Entity
    {
        public Guid UsuarioId { get; private set; }
        public decimal Valor { get; private set; }
        public TipoMovimentacao TipoMovimentacao { get; private set; }
        public Guid? ProdutoVendaId { get; private set; }
        public Guid? EmpresaId { get; private set; }
        public DateTime DataMovimentacao { get; private set; }

        // Ef Relations
        public AuthUsuario Usuario { get; private set; }
        public ProdutoVenda ProdutoVenda { get; private set; }
        public Empresa Empresa { get; private set; }

        protected UsuarioExtratoMovimentacao() { }

        public void Validar()
        {
            Validacoes.SeVazio(UsuarioId, "UsuarioId não deve ser vazio");
            Validacoes.SeVerdadeiro(Valor == 0, "Valor deve ser diferente de zero");

            switch (TipoMovimentacao)
            {
                case TipoMovimentacao.VendaProduto:
                    Validacoes.SeVazio(ProdutoVendaId.Value, "Produto Venda deve ser valido");
                    break;

                case TipoMovimentacao.AdicaoPontos:
                    Validacoes.SeVazio(EmpresaId.Value, "Empresa deve ser valida");
                    break;
            }
        }

        public static class ExtratoMovimentacaoFactory
        {
            public static UsuarioExtratoMovimentacao AdicionarPontos(Guid usuarioId, Guid empresaId, int pontos)
            {
                var movimentacao = new UsuarioExtratoMovimentacao
                {
                    Id = Guid.NewGuid(),
                    UsuarioId = usuarioId,
                    Valor = pontos,
                    EmpresaId = empresaId,
                    DataMovimentacao = DateTime.Now,
                    TipoMovimentacao = TipoMovimentacao.AdicaoPontos
                };

                movimentacao.Validar();
                return movimentacao;
            }

            public static UsuarioExtratoMovimentacao VenderProduto(Guid usuarioId, Produto produto, Endereco enderecoEntrega)
            {
                var movimentacao = new UsuarioExtratoMovimentacao
                {
                    Id = Guid.NewGuid(),
                    UsuarioId = usuarioId,
                    Valor = produto.ValorPontos,
                    DataMovimentacao = DateTime.Now,
                    TipoMovimentacao = TipoMovimentacao.VendaProduto,
                };

                movimentacao.ProdutoVenda = new ProdutoVenda(Guid.NewGuid(), movimentacao.Id, produto.Id, enderecoEntrega);
                movimentacao.ProdutoVendaId = movimentacao.ProdutoVenda.Id;
                movimentacao.Validar();
                return movimentacao;
            }
        }
    }
}
