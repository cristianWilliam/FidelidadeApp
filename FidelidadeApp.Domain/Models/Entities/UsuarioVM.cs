using System;

namespace FidelidadeApp.Domain.Models.Entities
{
    public class UsuarioVM
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }
    }
}
