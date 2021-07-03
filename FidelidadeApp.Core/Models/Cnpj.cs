using FidelidadeApp.Core.DomainObjects;
using System.Text.RegularExpressions;

namespace FidelidadeApp.Core.Models
{
    public class Cnpj
    {
        public string Valor { get; private set; }
		public string Formatado { get => string.Format(@"00\.000\.000\/0000\-00", Valor); }

        public Cnpj(string valor)
        {
            Valor = Sanitizar(valor);
			Validar();
        }

        public override string ToString() => Valor;

        private void Validar()
        {
			if (!CnpjEhValido(Valor))
				throw new DomainException("Cnpj invalido");
        }

		private bool CnpjEhValido(string cnpj)
		{
			int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
			int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
			int soma;
			int resto;
			string digito;
			string tempCnpj;
			cnpj = cnpj.Trim();
			cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");
			if (cnpj.Length != 14)
				return false;
			tempCnpj = cnpj.Substring(0, 12);
			soma = 0;
			for (int i = 0; i < 12; i++)
				soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
			resto = (soma % 11);
			if (resto < 2)
				resto = 0;
			else
				resto = 11 - resto;
			digito = resto.ToString();
			tempCnpj = tempCnpj + digito;
			soma = 0;
			for (int i = 0; i < 13; i++)
				soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
			resto = (soma % 11);
			if (resto < 2)
				resto = 0;
			else
				resto = 11 - resto;
			digito = digito + resto.ToString();
			return cnpj.EndsWith(digito);
		}

		private string Sanitizar(string cnpj)
        {
			var regexExp = new Regex(@"[^\d]");
			return regexExp.Replace(cnpj, string.Empty);
        }
	}
}
