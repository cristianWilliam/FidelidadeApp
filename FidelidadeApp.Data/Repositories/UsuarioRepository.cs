using FidelidadeApp.Core.DomainObjects;
using FidelidadeApp.Core.Models;
using FidelidadeApp.Data.Repositories.Abstractions;
using FidelidadeApp.Domain.Abstractions;
using FidelidadeApp.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FidelidadeApp.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly IRepositoryBase<AuthUsuario> _repositoryBase;
        private readonly UserManager<AuthUsuario> _userManager;

        public UsuarioRepository(IRepositoryBase<AuthUsuario> repositoryBase, UserManager<AuthUsuario> userManager)
        {
            _repositoryBase = repositoryBase;
            _userManager = userManager;
        }

        public async Task AdicionarAsync(AuthUsuario usuario, string password)
        {
            var result = await _userManager.CreateAsync(usuario, password);
            if (!result.Succeeded)
            {
                var erros = string.Join(',', result.Errors.Select(x => x.Description));
                throw new DomainException(erros);
            }
        }

        public async Task<AuthUsuario> ObterSaldoEMovimentacoes(Guid usuarioId)
        {
            return await _repositoryBase.Obter(x => x.Id == usuarioId)
                            .Include(x => x.ExtratoMovimentacoes)
                                .ThenInclude(x => x.Empresa)
                            .Include(x => x.ExtratoMovimentacoes)
                                .ThenInclude(x => x.ProdutoVenda)
                                    .ThenInclude(x => x.Produto)
                            .Include(x => x.Saldo)
                            .AsNoTracking()
                            .FirstOrDefaultAsync();
        }

        public async Task<AuthUsuario> ObterPorEmail(Email email)
        {
            return await _repositoryBase.Obter(x => x.Email == email.Valor).FirstOrDefaultAsync();
        }

        public async Task<bool> ValidarCredenciais(AuthUsuario usuario, string password)
            => await _userManager.CheckPasswordAsync(usuario, password);

        public async Task<AuthUsuario> ObterComEndereco(Guid usuarioId)
        {
            return await _repositoryBase.Obter(x => x.Id == usuarioId)
                        .Include(x => x.EnderecoEntrega)
                        .FirstOrDefaultAsync();
        }

        public async Task<AuthUsuario> ObterSaldo(Guid UsuarioId)
        {
            return await _repositoryBase.Obter(x => x.Id == UsuarioId)
                            .Include(x => x.Saldo)
                            .FirstOrDefaultAsync();
        }

        public void AtualizarUsuario(AuthUsuario usuario)
        {
            _repositoryBase.Atualizar(usuario);
        }
    }
}
