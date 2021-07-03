using FidelidadeApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace FidelidadeApp.Data.Entities.Configurations
{
    public class ProdutoCategoriaConfiguration : IEntityTypeConfiguration<ProdutoCategoria>
    {
        public void Configure(EntityTypeBuilder<ProdutoCategoria> builder)
        {
            builder.ToTable("ProdutoCategoria", "Produto");

            builder.HasKey(x => new { x.ProdutoId, x.CategoriaId });

            builder.HasOne(x => x.Produto)
                .WithMany(x => x.ProdutoCategorias)
                .HasForeignKey(x => x.ProdutoId);

            builder.HasOne(x => x.Categoria)
                .WithMany(x => x.ProdutoCategorias)
                .HasForeignKey(x => x.CategoriaId);
        }
    }
}
