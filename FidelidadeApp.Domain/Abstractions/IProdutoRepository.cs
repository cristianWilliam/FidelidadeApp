using FidelidadeApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FidelidadeApp.Domain.Abstractions
{
    public interface IProdutoRepository
    {
        Task<IEnumerable<Produto>> ObterDisponiveisResgate();
        Task<Produto> ObterPorIdComVenda(Guid produtoId);
        Task<IEnumerable<Produto>> ObterTodosComStatusVenda();
    }
}
