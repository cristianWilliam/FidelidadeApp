using FidelidadeApp.Data.Entities;
using FidelidadeApp.Data.Entities.Seeds;
using FidelidadeApp.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace FidelidadeApp.Data
{
    public class FidelidadeAppContext : IdentityDbContext<AuthUsuario, AuthRole, Guid>
    {
        public FidelidadeAppContext(DbContextOptions<FidelidadeAppContext> options) : base(options)
        {
            
        }

        // Usuario
        public DbSet<AuthUsuario> AuthUsuario { get; set; }
        public DbSet<AuthRole> AuthRole { get; set; }
        public DbSet<UsuarioEndereco> UsuarioEndereco { get; set; }

        // Produto
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<ProdutoCategoria> ProdutoCategoria { get; set; }

        // Empresa
        public DbSet<Empresa> Empresa { get; set; }

        // Compra
        public DbSet<UsuarioSaldo> UsuarioSaldo { get; set; }
        public DbSet<UsuarioExtratoMovimentacao> UsuarioMovimentacao { get; set; }
        public DbSet<ProdutoVenda> ProdutoVenda { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {

            // Definindo default string quando não definido, evitando nvarchar(max)
            foreach (var property in builder.Model.GetEntityTypes().SelectMany(
               e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            builder.ApplyConfigurationsFromAssembly(typeof(FidelidadeAppContext).Assembly);

            // Usado para inicializar Identity
            base.OnModelCreating(builder);
        }
    }
}
