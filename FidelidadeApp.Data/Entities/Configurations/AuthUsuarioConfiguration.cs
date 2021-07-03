using FidelidadeApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FidelidadeApp.Data.Entities.Configurations
{
    public class AuthUsuarioConfiguration : IEntityTypeConfiguration<AuthUsuario>
    {
        public void Configure(EntityTypeBuilder<AuthUsuario> builder)
        {
            builder.ToTable("Usuario", "Usuario");
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Email).IsUnique();

            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.Nome).IsRequired();

            builder.HasMany(x => x.ExtratoMovimentacoes)
                .WithOne(x => x.Usuario)
                .HasForeignKey(x => x.UsuarioId);

            builder.HasOne(x => x.EnderecoEntrega)
                .WithOne(x => x.Usuario)
                .HasForeignKey<UsuarioEndereco>(x => x.Id);

            builder.HasOne(x => x.Saldo)
                .WithOne(x => x.Usuario)
                .HasForeignKey<UsuarioSaldo>(x => x.UsuarioId);
        }
    }
}
