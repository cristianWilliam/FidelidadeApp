using FidelidadeApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace FidelidadeApp.Data.Entities.Configurations
{
    public class UsuarioEnderecoConfiguration : IEntityTypeConfiguration<UsuarioEndereco>
    {
        public void Configure(EntityTypeBuilder<UsuarioEndereco> builder)
        {
            builder.ToTable("Endereco", "Usuario");
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Usuario)
                .WithOne(x => x.EnderecoEntrega)
                .HasForeignKey<UsuarioEndereco>(x => x.UsuarioId);

            builder.OwnsOne(x => x.Endereco, cm =>
            {
                cm.Property(x => x.Bairro)
                    .IsRequired();

                cm.Property(x => x.Cep)
                    .IsRequired();

                cm.Property(x => x.Estado)
                    .HasMaxLength(2)
                    .IsRequired();

                cm.Property(x => x.Pais)
                    .IsRequired();

                cm.Property(x => x.Rua)
                    .IsRequired();

                cm.Property(x => x.Cidade)
                    .IsRequired();
            });
        }
    }
}
