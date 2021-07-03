using FidelidadeApp.Core.Models;
using System;

namespace FidelidadeApp.Domain.Models.Entities
{
    public class UsuarioExtratoMovimentacaoVM
    {
        public int Valor { get; set; }
        public TipoMovimentacao TipoMovimentacao { get;set; }
        public string TipoMovimentacaoDescricao { get =>
                this.TipoMovimentacao == TipoMovimentacao.AdicaoPontos ? "Adicao Pontos" : "Resgate de Produto"; }

        public DateTime DataMovimentacao { get; set; }

        public EmpresaVM Empresa { get; set; }
        public ProdutoVM Produto { get; set; }
    }
}
