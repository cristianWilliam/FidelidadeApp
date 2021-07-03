using FidelidadeApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace FidelidadeApp.Data.Entities.Configurations
{
    class UsuarioSaldoConfiguration : IEntityTypeConfiguration<UsuarioSaldo>
    {
        public void Configure(EntityTypeBuilder<UsuarioSaldo> builder)
        {
            builder.ToTable("UsuarioSaldo", "Compra");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.PontosAtuais).IsRequired();

            builder.HasOne(x => x.Usuario)
                .WithOne(x => x.Saldo)
                .HasForeignKey<UsuarioSaldo>(x => x.UsuarioId);
        }
    }
}
