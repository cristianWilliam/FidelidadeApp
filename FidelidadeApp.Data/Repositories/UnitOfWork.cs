using FidelidadeApp.Domain.Abstractions;
using System.Threading.Tasks;

namespace FidelidadeApp.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FidelidadeAppContext _dbContext;

        public UnitOfWork(FidelidadeAppContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Commit()
        {
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public Task Rollback()
        {
            // EF usa Garbage Collector para limpar memória.
            return Task.CompletedTask;
        }
    }
}
