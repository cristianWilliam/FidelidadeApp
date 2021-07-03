using AutoMapper;
using FidelidadeApp.Controllers.Abstractions;
using FidelidadeApp.Core.DomainObjects;
using FidelidadeApp.Core.Models;
using FidelidadeApp.Domain.Abstractions;
using FidelidadeApp.Domain.Models;
using FidelidadeApp.Domain.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FidelidadeApp.Controllers
{
    public class UsuarioController : ApiController
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IMapper _mapper;

        public UsuarioController(IUsuarioService usuarioService, IMapper mapper)
        {
            _usuarioService = usuarioService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<MessageResponseData<UsuarioVM>> CriarUsuario([FromBody] CadastrarUsuarioDto request)
            => await _usuarioService.CadastrarNovo(request);

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<MessageResponseData<UsuarioLoginVM>> AutenticarUsuario([FromBody] UsuarioLoginDto request)
            => await _usuarioService.Autenticar(new Email(request.Email), request.Password);

        [HttpPut("EnderecoEntrega")]
        public async Task<UsuarioEnderecoVM> UsuarioEnderecoEntrega([FromBody] EnderecoDto enderecoDto, [FromServices] ITokenService tokenService)
        {
            var endereco = _mapper.Map<Endereco>(enderecoDto);
            return await _usuarioService.DefinirEnderecoEntrega(tokenService.ObterUsuarioIdToken(), endereco);
        }

        [HttpGet("EnderecoEntrega")]
        public async Task<UsuarioEnderecoVM> ObterUsuarioComEndereco([FromServices] ITokenService tokenService)
            => await _usuarioService.ObterComEndereco(tokenService.ObterUsuarioIdToken());

        [HttpGet("Extrato")]
        public async Task<UsuarioExtratoVM> ConsultarExtrato([FromServices] ITokenService tokenService)
            => await _usuarioService.ConsultarExtrato(tokenService.ObterUsuarioIdToken());
    }
}
