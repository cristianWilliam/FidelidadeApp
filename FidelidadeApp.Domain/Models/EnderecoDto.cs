using System.ComponentModel.DataAnnotations;

namespace FidelidadeApp.Domain.Models
{
    public class EnderecoDto
    {
        [Required(AllowEmptyStrings = false)]
        public string Rua { get; set; }

        [Required(AllowEmptyStrings = false)]

        public string Bairro { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Cep { get; set; }

        [MaxLength(2, ErrorMessage = "Somente Iniciais do Estado Ex: SP")]
        public string EstadoSigla { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Pais { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Cidade { get; set; }
    }
}
