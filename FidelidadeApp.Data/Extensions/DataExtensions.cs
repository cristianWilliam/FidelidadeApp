using FidelidadeApp.Data.Repositories;
using FidelidadeApp.Data.Repositories.Abstractions;
using FidelidadeApp.Domain.Abstractions;
using FidelidadeApp.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace FidelidadeApp.Data.Extensions
{
    public static class DataExtensions
    {
        public static IServiceCollection ConfigurarORM(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<FidelidadeAppContext>(options =>
            {
                options.UseMySql(
                    configuration.GetConnectionString("FidelidadeAppDb"),
                    ServerVersion.AutoDetect(configuration.GetConnectionString("FidelidadeAppDb")),
                    mySqlOptions => {
                        mySqlOptions.SchemaBehavior(MySqlSchemaBehavior.Ignore);
                    });
            });

            return services;
        }

        public static IServiceCollection ConfigurarIdentity(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddIdentityCore<AuthUsuario>(options =>
            {
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.User.RequireUniqueEmail = true;
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+ ";
            })
                .AddEntityFrameworkStores<FidelidadeAppContext>()
                .AddDefaultTokenProviders();

            return services;
        }
   
        public static IServiceCollection AddPatterns(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            services.AddTransient<IProdutoRepository, ProdutoRepository>();
            services.AddTransient<IEmpresaRepository, EmpresaRepository>();

            return services;
        }
    }
}
