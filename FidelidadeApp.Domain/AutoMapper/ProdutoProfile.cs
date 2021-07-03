using AutoMapper;
using FidelidadeApp.Domain.Entities;
using FidelidadeApp.Domain.Models.Entities;

namespace FidelidadeApp.Domain.AutoMapper
{
    public class ProdutoProfile : Profile
    {
        public ProdutoProfile()
        {
            CreateMap<Produto, ProdutoVM>();
            CreateMap<Produto, ProdutoStatusEntregaVM>()
                .ForMember(dest => dest.StatusEntrega, src => src.MapFrom(x => x.ProdutoVenda.StatusEntrega));
        }
    }
}
