using AutoMapper;
using FidelidadeApp.Core.Models;
using FidelidadeApp.Domain.Models;

namespace FidelidadeApp.Domain.AutoMapper
{
    public class EnderecoProfile : Profile
    {
        public EnderecoProfile()
        {
            CreateMap<EnderecoDto, Endereco>()
                .ConstructUsing(x => new Endereco(x.Rua, x.Bairro, x.Cep, x.EstadoSigla, x.Pais, x.Cidade))
                .ReverseMap();

            CreateMap<Endereco, Endereco>()
                .ConstructUsing(x => new Endereco(x.Rua, x.Bairro, x.Cep, x.Estado, x.Pais, x.Cidade));
        }
    }
}
