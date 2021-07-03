using FidelidadeApp.Core.Models;
using FidelidadeApp.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace FidelidadeApp.Data.Entities.Seeds
{
    public static class EmpresaSeed
    {
        public static EntityTypeBuilder<Empresa> AddSeeds(this EntityTypeBuilder<Empresa> builder)
        {
            builder.HasData(new Empresa[]
            {
                new Empresa(Guid.Parse("5c4df355-5c1e-4332-9982-6524e8b794a0"), new Cnpj("81.316.698/0001-50"), "Empresa Ficticia 1"),
                new Empresa(Guid.Parse("51b68825-23a2-4e96-baff-f5a48ef2443c"), new Cnpj("22.571.641/0001-39"), "Empresa Ficticia 2")
            });

            return builder;
        }
    }
}
