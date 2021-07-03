using FidelidadeApp.Core.Models;
using FidelidadeApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace FidelidadeApp.Data.Entities.Seeds
{
    public static class ModelBuilderExtension
    {
        public static ModelBuilder AddSeeds(this ModelBuilder modelBuilder)
        {

            // Empresa
            modelBuilder.Entity<Empresa>().HasData(new[]
            {
                new Empresa(Guid.Parse("5c4df355-5c1e-4332-9982-6524e8b794a0"), new Cnpj("81.316.698/0001-50"), "Empresa Ficticia 1"),
                new Empresa(Guid.Parse("51b68825-23a2-4e96-baff-f5a48ef2443c"), new Cnpj("22.571.641/0001-39"), "Empresa Ficticia 2")
            });


            // Categoria
            modelBuilder.Entity<Categoria>().HasData(new[]
            {
                new Categoria(Guid.Parse("f264a52e-0b89-4938-b9c6-ff943c2d4e57"), "Computadores"),
                new Categoria(Guid.Parse("6a561299-c349-4fcc-88d4-e731726c98ee"), "Apple Computadores", Guid.Parse("f264a52e-0b89-4938-b9c6-ff943c2d4e57")),
                new Categoria(Guid.Parse("cdc389e8-1136-4c82-8c31-1cdd82269eae"), "Celulares")
            });


            // Produto
            modelBuilder.Entity<Produto>().HasData(new[]
            {
                new Produto(Guid.Parse("6aa0291c-4c77-411e-82b5-12f1d055e48a"), "Macbook Pro", "M1 16GB", 300),
                new Produto(Guid.Parse("c2289712-0990-4062-8494-a7392e5c1cd6"), "Surface", "i9 16GB", 300),
                new Produto(Guid.Parse("83626e06-d717-4c7a-b423-294c10dc34fc"), "IPhone X", "Apple 128GB", 100),
                new Produto(Guid.Parse("63e8a2eb-edc5-48c4-ab63-7e2fed350e93"), "IMac", "Apple i7", 200),
                new Produto(Guid.Parse("fbe0c014-2685-4437-8cd0-2dba17d1276f"), "Galaxy S21", "Samsung 129GB", 100),
                new Produto(Guid.Parse("626f1625-4c07-407b-a5ce-bb3a0fdc68cb"), "Xiaomi MI9", "MI 129GB", 100),
                new Produto(Guid.Parse("fbd85c52-e478-42b8-b01e-4a9e0a43723d"), "Galaxy S20", "Samsung 129GB", 100),
            });

            // Produto Categoria
            modelBuilder.Entity<ProdutoCategoria>().HasData(new[]
            {
                // MacBook Pro -> Computadores
                new ProdutoCategoria(Guid.Parse("6aa0291c-4c77-411e-82b5-12f1d055e48a"), Guid.Parse("f264a52e-0b89-4938-b9c6-ff943c2d4e57")),
                // MacBook Pro -> Apple Computadores
                new ProdutoCategoria(Guid.Parse("6aa0291c-4c77-411e-82b5-12f1d055e48a"), Guid.Parse("6a561299-c349-4fcc-88d4-e731726c98ee")),
                // Surface -> Computadores
                new ProdutoCategoria(Guid.Parse("c2289712-0990-4062-8494-a7392e5c1cd6"), Guid.Parse("f264a52e-0b89-4938-b9c6-ff943c2d4e57")),
                // IPhoneX -> Celulares
                new ProdutoCategoria(Guid.Parse("83626e06-d717-4c7a-b423-294c10dc34fc"), Guid.Parse("cdc389e8-1136-4c82-8c31-1cdd82269eae")),
                // IMac -> Computadores
                new ProdutoCategoria(Guid.Parse("63e8a2eb-edc5-48c4-ab63-7e2fed350e93"), Guid.Parse("f264a52e-0b89-4938-b9c6-ff943c2d4e57")),
                // IMac -> Computadores Apple
                new ProdutoCategoria(Guid.Parse("63e8a2eb-edc5-48c4-ab63-7e2fed350e93"), Guid.Parse("6a561299-c349-4fcc-88d4-e731726c98ee")),
                // Galaxy S21 -> Celulares
                new ProdutoCategoria(Guid.Parse("fbe0c014-2685-4437-8cd0-2dba17d1276f"), Guid.Parse("cdc389e8-1136-4c82-8c31-1cdd82269eae")),
                // Xiaomi MI9 -> Celulares
                new ProdutoCategoria(Guid.Parse("626f1625-4c07-407b-a5ce-bb3a0fdc68cb"), Guid.Parse("cdc389e8-1136-4c82-8c31-1cdd82269eae")),
                // Galaxy S20 -> Celulares
                new ProdutoCategoria(Guid.Parse("fbd85c52-e478-42b8-b01e-4a9e0a43723d"), Guid.Parse("cdc389e8-1136-4c82-8c31-1cdd82269eae")),
            });

            return modelBuilder;
        }
    }
}
