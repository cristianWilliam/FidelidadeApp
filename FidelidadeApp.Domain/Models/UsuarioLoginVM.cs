using FidelidadeApp.Domain.Models.Entities;

namespace FidelidadeApp.Domain.Models
{
    public class UsuarioLoginVM : UsuarioVM
    {
        public string Token { get; set; }
    }
}
