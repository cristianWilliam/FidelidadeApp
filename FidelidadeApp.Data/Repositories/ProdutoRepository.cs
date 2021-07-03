using FidelidadeApp.Data.Repositories.Abstractions;
using FidelidadeApp.Domain.Abstractions;
using FidelidadeApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FidelidadeApp.Data.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly IRepositoryBase<Produto> _repositoryBase;

        public ProdutoRepository(IRepositoryBase<Produto> repositoryBase)
        {
            _repositoryBase = repositoryBase;
        }

        public async Task<IEnumerable<Produto>> ObterDisponiveisResgate()
        {
            return await _repositoryBase.Obter()
                            .Where(x => x.ProdutoVenda == null)
                            .ToListAsync();
        }

        public async Task<IEnumerable<Produto>> ObterTodosComStatusVenda()
        {
            return await _repositoryBase.Obter()
                            .Include(x => x.ProdutoVenda)
                            .ToListAsync();
        }

        public async Task<Produto> ObterPorIdComVenda(Guid produtoId)
        {
            return await _repositoryBase.Obter(x => x.Id == produtoId)
                        .Include(x => x.ProdutoVenda)
                        .FirstOrDefaultAsync();
        }
    }
}
