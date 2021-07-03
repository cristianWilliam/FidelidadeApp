using FidelidadeApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FidelidadeApp.Data.Entities.Configurations
{
    public class ProdutoVendaConfiguration : IEntityTypeConfiguration<ProdutoVenda>
    {
        public void Configure(EntityTypeBuilder<ProdutoVenda> builder)
        {
            builder.ToTable("ProdutoVenda", "Compra");
            
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Movimentacao)
                .WithOne(x => x.ProdutoVenda)
                .HasForeignKey<UsuarioExtratoMovimentacao>(x => x.Id);

            builder.HasOne(x => x.Produto)
                .WithOne(x => x.ProdutoVenda)
                .HasForeignKey<ProdutoVenda>(x => x.ProdutoId);

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
