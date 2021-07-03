using FidelidadeApp.Controllers.Abstractions;
using FidelidadeApp.Core.DomainObjects;
using FidelidadeApp.Domain.Abstractions;
using FidelidadeApp.Domain.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FidelidadeApp.Controllers
{
    public class ProdutoController : ApiController
    {
        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IEnumerable<ProdutoStatusEntregaVM>> ObterTodos()
        {
            return await _produtoService.ObterTodosComStatusEntrega();
        }

        [AllowAnonymous]
        [HttpGet("Resgate")]
        public async Task<IEnumerable<ProdutoVM>> ObterDisponiveisResgate()
        {
            return await _produtoService.ObterDisponiveis();
        }

        [HttpPost("Resgate/{produtoId}")]
        public async Task<ActionResult<MessageResponse>> ResgatarProduto([FromRoute] Guid produtoId, [FromServices] ITokenService token)
        {
            try
            {
                var result = await _produtoService.RegatarProduto(token.ObterUsuarioIdToken(), produtoId);
                return Ok(result);
            }
            catch(ProdutoNaoEncontradoException)
            {
                return NotFound("Produto não encontrado!");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
