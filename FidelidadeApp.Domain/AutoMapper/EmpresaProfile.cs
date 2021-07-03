using AutoMapper;
using FidelidadeApp.Domain.Entities;
using FidelidadeApp.Domain.Models.Entities;

namespace FidelidadeApp.Domain.AutoMapper
{
    public class EmpresaProfile : Profile
    {
        public EmpresaProfile()
        {
            CreateMap<Empresa, EmpresaVM>();
        }
    }
}
