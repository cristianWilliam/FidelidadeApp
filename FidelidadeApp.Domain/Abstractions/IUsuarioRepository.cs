using FidelidadeApp.Core.Models;
using FidelidadeApp.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace FidelidadeApp.Domain.Abstractions
{
    public interface IUsuarioRepository
    {
        Task AdicionarAsync(AuthUsuario usuario, string password);
        Task<bool> ValidarCredenciais(AuthUsuario usuario, string password);
        void AtualizarUsuario(AuthUsuario usuario);
        Task<AuthUsuario> ObterPorEmail(Email email);
        Task<AuthUsuario> ObterSaldoEMovimentacoes(Guid usuarioId);
        Task<AuthUsuario> ObterComEndereco(Guid usuarioId);
        Task<AuthUsuario> ObterSaldo(Guid UsuarioId);
    }
}
