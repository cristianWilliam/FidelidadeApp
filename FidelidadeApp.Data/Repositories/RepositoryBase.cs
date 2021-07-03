using FidelidadeApp.Core.Interfaces;
using FidelidadeApp.Data.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FidelidadeApp.Data.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class, IAggregateRoot
    {
        private readonly DbSet<TEntity> _dbSet;

        public RepositoryBase(FidelidadeAppContext dbContext)
        {
            _dbSet = dbContext.Set<TEntity>();
        }

        public async Task AdicionarAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void DeletarAsync(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task<TEntity> ObterPorIdAsync(Guid Id)
        {
            return await _dbSet.FindAsync(Id);
        }

        public IQueryable<TEntity> Obter(Expression<Func<TEntity, bool>> filter = null)
        {
            var query = _dbSet.AsQueryable();

            if (filter != null)
                query = query.Where(filter);

            return query;
        }

        public void Atualizar(TEntity entity)
        {
            _dbSet.Update(entity);
        }
    }
}
