using AutoMapper;
using FidelidadeApp.Core.DomainObjects;
using FidelidadeApp.Core.Models;
using FidelidadeApp.Domain.Abstractions;
using FidelidadeApp.Domain.Entities;
using FidelidadeApp.Domain.Models;
using FidelidadeApp.Domain.Models.Entities;
using System;
using System.Threading.Tasks;

namespace FidelidadeApp.Domain.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IEmpresaRepository _empresaRepository;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;
        private readonly IUnitOfWork _unitOfWork;

        public UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper, ITokenService tokenService, IUnitOfWork unitOfWork, IEmpresaRepository empresaRepository)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
            _tokenService = tokenService;
            _unitOfWork = unitOfWork;
            _empresaRepository = empresaRepository;
        }

        public async Task<MessageResponseData<UsuarioLoginVM>> Autenticar(Email email, string password)
        {
            try
            {
                var user = await _usuarioRepository.ObterPorEmail(email);

                if (user == null)
                    return MessageResponseData<UsuarioLoginVM>.Erro("Usuario não encontrado!");

                var autenticacaoResult = await _usuarioRepository.ValidarCredenciais(user, password);

                if (!autenticacaoResult)
                    return MessageResponseData<UsuarioLoginVM>.Erro("Credenciais invalidas!");

                var loginResult = _mapper.Map<UsuarioLoginVM>(user);
                loginResult.Token = _tokenService.GerarTokenUsuarioAsync(user.Id);

                return MessageResponseData<UsuarioLoginVM>.Ok(loginResult, "Autenticacao bem sucedida");
            }
            catch (DomainException ex)
            {
                return MessageResponseData<UsuarioLoginVM>.Erro(ex.Message);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<MessageResponseData<UsuarioVM>> CadastrarNovo(CadastrarUsuarioDto usuario)
        {
            try
            {
                var userRegistro = new AuthUsuario(Guid.NewGuid(), usuario.Nome, new Email(usuario.Email));
                userRegistro.DefinirSaldoAtual(500);

                var empresa = await _empresaRepository.ObterPrimeira();

                var movimentacao = UsuarioExtratoMovimentacao.ExtratoMovimentacaoFactory.AdicionarPontos(userRegistro.Id, empresa.Id, 500);
                userRegistro.AddExtrato(movimentacao);

                await _usuarioRepository.AdicionarAsync(userRegistro, usuario.Senha);
                var usuarioRegistrado = await _usuarioRepository.ObterPorEmail(new Email(usuario.Email));

                return MessageResponseData<UsuarioVM>.Ok(_mapper.Map<UsuarioVM>(usuarioRegistrado));
            }
            catch (DomainException ex)
            {
                return MessageResponseData<UsuarioVM>.Erro(ex.Message);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<UsuarioExtratoVM> ConsultarExtrato(Guid usuarioId)
        {
            return _mapper.Map<UsuarioExtratoVM>(await _usuarioRepository.ObterSaldoEMovimentacoes(usuarioId));
        }

        public async Task<UsuarioEnderecoVM> DefinirEnderecoEntrega(Guid usuarioId, Endereco endereco)
        {
            var usuario = await _usuarioRepository.ObterComEndereco(usuarioId);
            usuario.AlterarEnderecoEntrega(endereco);
            _usuarioRepository.AtualizarUsuario(usuario);
            await _unitOfWork.Commit();
            return _mapper.Map<UsuarioEnderecoVM>(usuario);
        }

        public async Task<UsuarioEnderecoVM> ObterComEndereco(Guid usuarioId)
        {
            return _mapper.Map<UsuarioEnderecoVM>(await _usuarioRepository.ObterComEndereco(usuarioId));
        }
    }
}
