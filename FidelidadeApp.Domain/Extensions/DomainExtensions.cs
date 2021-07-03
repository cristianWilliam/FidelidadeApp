using FidelidadeApp.Domain.Abstractions;
using FidelidadeApp.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace FidelidadeApp.Domain.Extensions
{
    public static class DomainExtensions
    {
        public static IServiceCollection AddDomainAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(DomainExtensions).Assembly);
            return services;
        }

        public static IServiceCollection AddDomainDependencias(this IServiceCollection services)
        {
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IProdutoService, ProdutoService>();

            return services;
        }
    }
}
