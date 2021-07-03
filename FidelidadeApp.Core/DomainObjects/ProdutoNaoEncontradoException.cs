using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FidelidadeApp.Core.DomainObjects
{
    public class ProdutoNaoEncontradoException : Exception
    {
        public ProdutoNaoEncontradoException()
        {
        }

        public ProdutoNaoEncontradoException(string message) : base(message)
        {
        }

        public ProdutoNaoEncontradoException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
