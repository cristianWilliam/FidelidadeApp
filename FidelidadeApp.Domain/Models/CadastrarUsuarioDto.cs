using FidelidadeApp.Core.Models;
using System.ComponentModel.DataAnnotations;

namespace FidelidadeApp.Domain.Models
{
    public class CadastrarUsuarioDto
    {
        [Required(AllowEmptyStrings = false)]
        public string Nome { get; set; }

        [EmailAddress, Required(AllowEmptyStrings = false)]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Senha { get; set; }
    }
}
