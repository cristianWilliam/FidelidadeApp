using FidelidadeApp.Core.Models;
using System;

namespace FidelidadeApp.Domain.Models.Entities
{
    public class ProdutoVendaVM
    {
        public Guid Id { get; set; }
        public Guid MovimentacaoId { get; set; }
        public Endereco Endereco { get; set; }
        public StatusEntrega StatusEntrega { get; set; }
    }
}
