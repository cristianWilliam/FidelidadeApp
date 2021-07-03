using FidelidadeApp.Domain.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FidelidadeApp.Infrastructure.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public TokenService(IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        public string GerarTokenUsuarioAsync(Guid usuarioId)
        {
            var chaveToken = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Autenticacao:ChaveToken"]));

            var token = new JwtSecurityToken(
                claims: new Claim[] { new Claim(ClaimTypes.NameIdentifier, usuarioId.ToString()) },
                expires: DateTime.Now.AddHours(double.Parse(_configuration["Autenticacao:HorasExpiracao"])),
                signingCredentials: new SigningCredentials(chaveToken, SecurityAlgorithms.HmacSha256)
                );

            return $"Bearer {new JwtSecurityTokenHandler().WriteToken(token)}";
        }

        public Guid ObterUsuarioIdToken() => Guid.Parse(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
    }
}
