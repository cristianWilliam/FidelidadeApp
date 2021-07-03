using System;
using System.Text.RegularExpressions;

namespace FidelidadeApp.Core.DomainObjects
{
    public class Validacoes
    {
        public static void SeIgual(object object1, object object2, string mensagem)
        {
            if (object1.Equals(object2))
            {
                throw new DomainException(mensagem);
            }
        }

        public static void SeDiferente(object object1, object object2, string mensagem)
        {
            if (!object1.Equals(object2))
            {
                throw new DomainException(mensagem);
            }
        }

        public static void SeDiferente(string pattern, string valor, string mensagem)
        {
            var regex = new Regex(pattern);

            if (!regex.IsMatch(valor))
            {
                throw new DomainException(mensagem);
            }
        }

        public static void Tamanho(string valor, int maximo, string mensagem)
        {
            var length = valor.Trim().Length;
            if (length > maximo)
            {
                throw new DomainException(mensagem);
            }
        }

        public static void Tamanho(string valor, int minimo, int maximo, string mensagem)
        {
            var length = valor.Trim().Length;
            if (length < minimo || length > maximo)
            {
                throw new DomainException(mensagem);
            }
        }

        public static void SeVazio(string valor, string mensagem)
        {
            if (valor == null || valor.Trim().Length == 0)
            {
                throw new DomainException(mensagem);
            }
        }

        public static void SeVazio(Guid valor, string mensagem)
        {
            if(valor.ToString().Equals(Guid.Empty))
                throw new DomainException(mensagem);
        }

        public static void SeNulo(object object1, string mensagem)
        {
            if (object1 == null)
            {
                throw new DomainException(mensagem);
            }
        }

        public static void MinimoMaximo(double valor, double minimo, double maximo, string mensagem)
        {
            if (valor < minimo || valor > maximo)
            {
                throw new DomainException(mensagem);
            }
        }

        public static void MinimoMaximo(float valor, float minimo, float maximo, string mensagem)
        {
            if (valor < minimo || valor > maximo)
            {
                throw new DomainException(mensagem);
            }
        }

        public static void MinimoMaximo(int valor, int minimo, int maximo, string mensagem)
        {
            if (valor < minimo || valor > maximo)
            {
                throw new DomainException(mensagem);
            }
        }

        public static void MinimoMaximo(long valor, long minimo, long maximo, string mensagem)
        {
            if (valor < minimo || valor > maximo)
            {
                throw new DomainException(mensagem);
            }
        }

        public static void MinimoMaximo(decimal valor, decimal minimo, decimal maximo, string mensagem)
        {
            if (valor < minimo || valor > maximo)
            {
                throw new DomainException(mensagem);
            }
        }

        public static void SeMenorQue(long valor, long minimo, string mensagem)
        {
            if (valor < minimo)
            {
                throw new DomainException(mensagem);
            }
        }

        public static void SeMenorQue(double valor, double minimo, string mensagem)
        {
            if (valor < minimo)
            {
                throw new DomainException(mensagem);
            }
        }

        public static void SeMenorQue(decimal valor, decimal minimo, string mensagem)
        {
            if (valor < minimo)
            {
                throw new DomainException(mensagem);
            }
        }

        public static void SeMenorQue(int valor, int minimo, string mensagem)
        {
            if (valor < minimo)
            {
                throw new DomainException(mensagem);
            }
        }

        public static void SeFalso(bool boolvalor, string mensagem)
        {
            if (!boolvalor)
            {
                throw new DomainException(mensagem);
            }
        }

        public static void SeVerdadeiro(bool boolvalor, string mensagem)
        {
            if (boolvalor)
            {
                throw new DomainException(mensagem);
            }
        }
    }
}
