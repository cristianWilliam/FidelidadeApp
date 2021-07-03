using AutoMapper;
using FidelidadeApp.Domain.Entities;
using FidelidadeApp.Domain.Models.Entities;

namespace FidelidadeApp.Domain.AutoMapper
{
    public class SaldoProfile : Profile
    {
        public SaldoProfile()
        {
            CreateMap<UsuarioSaldo, SaldoVM>();
        }
    }
}
