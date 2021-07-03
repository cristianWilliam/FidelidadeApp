using FidelidadeApp.Core.DomainObjects;
using FidelidadeApp.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FidelidadeApp.Domain.Abstractions
{
    public interface IProdutoService
    {
        Task<IEnumerable<ProdutoVM>> ObterDisponiveis();
        Task<MessageResponse> RegatarProduto(Guid usuarioId, Guid produtoId);
        Task<IEnumerable<ProdutoStatusEntregaVM>> ObterTodosComStatusEntrega();
    }
}
