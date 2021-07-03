using System;

namespace FidelidadeApp.Domain.Models.Entities
{
    public class ProdutoVM
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int ValorPontos { get; set; }
    }
}
