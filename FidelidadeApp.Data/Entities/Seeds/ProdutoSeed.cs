using FidelidadeApp.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace FidelidadeApp.Data.Entities.Seeds
{
    public static class ProdutoSeed
    {
        public static EntityTypeBuilder<Produto> AddSeeds(this EntityTypeBuilder<Produto> builder)
        {
            // Categorias
            var computadores = new Categoria(Guid.Parse("f264a52e-0b89-4938-b9c6-ff943c2d4e57"), "Computadores");
            var appleComputadores = new Categoria(Guid.Parse("6a561299-c349-4fcc-88d4-e731726c98ee"), "Apple Computadores", computadores.Id);
            var celulares = new Categoria(Guid.Parse("cdc389e8-1136-4c82-8c31-1cdd82269eae"), "Celulares");

            // Produtos
            var macbook = new Produto(Guid.Parse("6aa0291c-4c77-411e-82b5-12f1d055e48a"), "Macbook Pro", "M1 16GB", 300);
            macbook.AddCategoria(computadores.Id);
            macbook.AddCategoria(appleComputadores.Id);

            var surface = new Produto(Guid.Parse("c2289712-0990-4062-8494-a7392e5c1cd6"), "Surface", "i9 16GB", 300);
            surface.AddCategoria(computadores.Id);
            
            var iPhone = new Produto(Guid.Parse("83626e06-d717-4c7a-b423-294c10dc34fc"), "IPhone X", "Apple 128GB", 100);
            iPhone.AddCategoria(celulares.Id);
            
            var IMac = new Produto(Guid.Parse("63e8a2eb-edc5-48c4-ab63-7e2fed350e93"), "IMac", "Apple i7", 200);
            IMac.AddCategoria(computadores.Id);
            IMac.AddCategoria(appleComputadores.Id);
            
            var galaxy21 = new Produto(Guid.Parse("fbe0c014-2685-4437-8cd0-2dba17d1276f"), "Galaxy S21", "Samsung 129GB", 100);
            galaxy21.AddCategoria(celulares.Id);
            
            var xiaomi9 = new Produto(Guid.Parse("626f1625-4c07-407b-a5ce-bb3a0fdc68cb"), "Xiaomi MI9", "MI 129GB", 100);
            xiaomi9.AddCategoria(celulares.Id);
            
            var galaxy20 = new Produto(Guid.Parse("fbd85c52-e478-42b8-b01e-4a9e0a43723d"), "Galaxy S20", "Samsung 129GB", 100);
            galaxy20.AddCategoria(celulares.Id);

            builder.HasData(new Produto[]
            {
                macbook, surface, iPhone, IMac, galaxy21, xiaomi9, galaxy20
            });

            return builder;
        }
    }
}
