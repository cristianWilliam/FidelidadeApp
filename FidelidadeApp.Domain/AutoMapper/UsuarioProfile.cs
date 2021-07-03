using AutoMapper;
using FidelidadeApp.Domain.Entities;
using FidelidadeApp.Domain.Models;
using FidelidadeApp.Domain.Models.Entities;

namespace FidelidadeApp.Domain.AutoMapper
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<AuthUsuario, UsuarioVM>();

            CreateMap<AuthUsuario, UsuarioLoginVM>();

            CreateMap<AuthUsuario, UsuarioEnderecoVM>()
                .ForMember(dest => dest.EnderecoEntrega, src => src.MapFrom(x => x.EnderecoEntrega.Endereco));

            CreateMap<AuthUsuario, UsuarioExtratoVM>()
                .ForMember(dest => dest.ExtratoMovimentacoes, src => src.MapFrom(x => x.ExtratoMovimentacoes))
                .ForMember(dest => dest.Saldo, src => src.MapFrom(x => x.Saldo));

        }
    }
}
