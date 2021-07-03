using System;

namespace FidelidadeApp.Domain.Entities
{
    public class ProdutoCategoria
    {
        public ProdutoCategoria(Guid produtoId, Guid categoriaId)
        {
            ProdutoId = produtoId;
            CategoriaId = categoriaId;
        }

        public ProdutoCategoria(Guid produtoId, Categoria categoria)
        {
            ProdutoId = produtoId;
            CategoriaId = categoria.Id;
            Categoria = categoria;
        }

        public Guid ProdutoId { get; private set; }
        public Guid CategoriaId {get; private set; }

        // Ef navigation properties
        public Produto Produto { get; private set; }
        public Categoria Categoria {get; private set; }
    }
}
