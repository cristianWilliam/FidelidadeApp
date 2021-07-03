using FidelidadeApp.Core.Models;

namespace FidelidadeApp.Domain.Models.Entities
{
    public class ProdutoStatusEntregaVM : ProdutoVM
    {
        public StatusEntrega StatusEntrega { get; set; }
        public string StatusEntregaDescricao
        {
            get => StatusEntrega switch
            {
                StatusEntrega.EmEstoque => "Em Estoque",
                StatusEntrega.EmTransito => "Em Transito",
                StatusEntrega.Entregue => "Entregue",
                _ => "Não mapeado!"
            };
        }
    }
}
