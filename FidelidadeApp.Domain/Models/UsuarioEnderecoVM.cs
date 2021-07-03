using FidelidadeApp.Core.Models;
using FidelidadeApp.Domain.Models.Entities;

namespace FidelidadeApp.Domain.Models
{
    public class UsuarioEnderecoVM : UsuarioVM
    {
        public Endereco EnderecoEntrega { get; set; }
    }
}
