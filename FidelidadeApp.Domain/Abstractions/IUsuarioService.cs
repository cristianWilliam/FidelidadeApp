using FidelidadeApp.Core.DomainObjects;
using FidelidadeApp.Core.Models;
using FidelidadeApp.Domain.Models;
using FidelidadeApp.Domain.Models.Entities;
using System;
using System.Threading.Tasks;

namespace FidelidadeApp.Domain.Abstractions
{
    public interface IUsuarioService
    {
        Task<MessageResponseData<UsuarioVM>> CadastrarNovo(CadastrarUsuarioDto usuario);
        Task<MessageResponseData<UsuarioLoginVM>> Autenticar(Email email, string password);
        Task<UsuarioEnderecoVM> DefinirEnderecoEntrega(Guid usuarioId, Endereco endereco);
        Task<UsuarioExtratoVM> ConsultarExtrato(Guid usuarioId);
        Task<UsuarioEnderecoVM> ObterComEndereco(Guid usuarioId);
    }
}
