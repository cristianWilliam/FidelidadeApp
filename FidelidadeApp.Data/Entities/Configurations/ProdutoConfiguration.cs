using FidelidadeApp.Data.Entities.Seeds;
using FidelidadeApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FidelidadeApp.Data.Entities.Configurations
{
    public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produto", "Produto");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome).IsRequired();
            builder.Property(x => x.ValorPontos).IsRequired();

            builder.HasMany(x => x.ProdutoCategorias)
                .WithOne(x => x.Produto);

            builder.HasOne(x => x.ProdutoVenda)
                .WithOne(x => x.Produto)
                .HasForeignKey<ProdutoVenda>(x => x.ProdutoId);

        }
    }
}
