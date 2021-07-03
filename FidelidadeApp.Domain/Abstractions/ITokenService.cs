using System;

namespace FidelidadeApp.Domain.Abstractions
{
    public interface ITokenService
    {
        public string GerarTokenUsuarioAsync(Guid usuarioId);
        public Guid ObterUsuarioIdToken();
    }
}
