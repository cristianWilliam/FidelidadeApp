using FidelidadeApp.Domain.Entities;
using System.Threading.Tasks;

namespace FidelidadeApp.Domain.Abstractions
{
    public interface IEmpresaRepository
    {
        Task<Empresa> ObterPrimeira();
    }
}
