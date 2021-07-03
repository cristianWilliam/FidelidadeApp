using System.Threading.Tasks;

namespace FidelidadeApp.Domain.Abstractions
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
        Task Rollback();
    }
}
