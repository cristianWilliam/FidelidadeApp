using AutoMapper;
using FidelidadeApp.Domain.Entities;
using FidelidadeApp.Domain.Models.Entities;

namespace FidelidadeApp.Domain.AutoMapper
{
    public class MovimentacoesProfile : Profile
    {
        public MovimentacoesProfile()
        {
            CreateMap<UsuarioExtratoMovimentacao, UsuarioExtratoMovimentacaoVM>()
                .ForMember(dest => dest.Valor, src => src.MapFrom(x => x.Valor))
                .ForMember(dest => dest.TipoMovimentacao, src => src.MapFrom(x => x.TipoMovimentacao))
                .ForMember(dest => dest.DataMovimentacao, src => src.MapFrom(x => x.DataMovimentacao))
                .ForMember(dest => dest.Empresa, src => src.MapFrom(x => x.Empresa))
                .ForMember(dest => dest.Produto, src => src.MapFrom(x => x.ProdutoVenda.Produto));
        }
    }
}
