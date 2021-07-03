using System.ComponentModel.DataAnnotations;

namespace FidelidadeApp.Domain.Models
{
    public class UsuarioLoginDto
    {
        [EmailAddress, Required(AllowEmptyStrings = false)]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Password { get; set; }
    }
}
