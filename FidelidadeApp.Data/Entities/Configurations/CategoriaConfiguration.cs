using FidelidadeApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FidelidadeApp.Data.Entities.Configurations
{
    public class CategoriaConfiguration : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.ToTable("Categoria", "Produto");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .IsRequired();

            builder.HasOne(x => x.CategoriaPai)
                .WithMany(x => x.CategoriasFilhas)
                .HasForeignKey(x => x.CategoriaPaiId);

            builder.HasMany(x => x.CategoriasFilhas)
                .WithOne(x => x.CategoriaPai);

            builder.HasMany(x => x.ProdutoCategorias)
                .WithOne(x => x.Categoria);
        }
    }
}
