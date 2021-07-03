using AutoMapper;
using FidelidadeApp.Domain.Entities;
using FidelidadeApp.Domain.Models.Entities;

namespace FidelidadeApp.Domain.AutoMapper
{
    public class ProdutoVendaProfile : Profile
    {
        public ProdutoVendaProfile()
        {
            CreateMap<ProdutoVenda, ProdutoVendaVM>();
        }
    }
}
