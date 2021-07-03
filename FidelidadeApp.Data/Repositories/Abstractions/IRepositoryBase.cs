using FidelidadeApp.Core.Interfaces;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FidelidadeApp.Data.Repositories.Abstractions
{
    public interface IRepositoryBase<TEntity> where TEntity : IAggregateRoot
    {
        IQueryable<TEntity> Obter(Expression<Func<TEntity, bool>> filter = null);
        Task<TEntity> ObterPorIdAsync(Guid Id);
        Task AdicionarAsync(TEntity entity);
        void DeletarAsync(TEntity entity);
        void Atualizar(TEntity entity);
    }
}
