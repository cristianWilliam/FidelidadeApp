using FidelidadeApp.Domain.Models.Entities;
using System.Collections.Generic;

namespace FidelidadeApp.Domain.Models
{
    public class UsuarioExtratoVM : UsuarioVM
    {
        public IEnumerable<UsuarioExtratoMovimentacaoVM> ExtratoMovimentacoes { get; set; }
        public SaldoVM Saldo { get; set; }
    }
}
