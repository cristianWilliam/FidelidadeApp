using System.ComponentModel.DataAnnotations;

namespace FidelidadeApp.Core.Models
{
    public class Endereco
    {
        public string Rua { get; private set; }
        public string Bairro { get; private set; }
        public string Cep { get; private set; }

        [StringLength(2)]
        public string Estado { get; private set; }
        public string Pais { get; private set; }
        public string Cidade { get; private set; }

        protected Endereco() { }

        public Endereco(string rua, string bairro, string cep, string estado, string pais, string cidade)
        {
            Rua = rua;
            Bairro = bairro;
            Cep = cep;
            Estado = estado;
            Pais = pais;
            Cidade = cidade;
        }
    }
}
