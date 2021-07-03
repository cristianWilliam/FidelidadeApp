using FidelidadeApp.Data.Repositories.Abstractions;
using FidelidadeApp.Domain.Abstractions;
using FidelidadeApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FidelidadeApp.Data.Repositories
{
    public class EmpresaRepository : IEmpresaRepository
    {
        private readonly IRepositoryBase<Empresa> _repositoryBase;

        public EmpresaRepository(IRepositoryBase<Empresa> repositoryBase)
        {
            _repositoryBase = repositoryBase;
        }

        public async Task<Empresa> ObterPrimeira()
        {
            return await _repositoryBase.Obter().FirstOrDefaultAsync();
        }
    }
}
