using FidelidadeApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FidelidadeApp.Data.Entities.Configurations
{
    public class UsuarioExtratoMovimentacaoConfiguration : IEntityTypeConfiguration<UsuarioExtratoMovimentacao>
    {
        public void Configure(EntityTypeBuilder<UsuarioExtratoMovimentacao> builder)
        {
            builder.ToTable("UsuarioMovimentacoes", "Compra");
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.ProdutoVenda)
                .WithOne(x => x.Movimentacao)
                .HasForeignKey<UsuarioExtratoMovimentacao>(x => x.ProdutoVendaId);

            builder.HasOne(x => x.Empresa)
                .WithMany(x => x.UsuarioMovimentacoes)
                .HasForeignKey(x => x.EmpresaId);

            builder.HasOne(x => x.Usuario)
                .WithMany(x => x.ExtratoMovimentacoes)
                .HasForeignKey(x => x.UsuarioId);
        }
    }
}
