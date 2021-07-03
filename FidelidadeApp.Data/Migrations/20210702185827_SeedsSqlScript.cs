using Microsoft.EntityFrameworkCore.Migrations;

namespace FidelidadeApp.Data.Migrations
{
    public partial class SeedsSqlScript : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string empresaSql = @"
               INSERT INTO Empresa (Id, Cnpj, Nome)
                VALUES 	('5c4df355-5c1e-4332-9982-6524e8b794a0', '59010890000165', 'Posto de Gasolina'),
		                ('51b68825-23a2-4e96-baff-f5a48ef2443c', '14782015000163', 'Farmacia');
            ";

            string categoriaSql = @"
                INSERT INTO Categoria (Id, Nome, CategoriaPaiId)
                VALUES 	('f264a52e-0b89-4938-b9c6-ff943c2d4e57', 'Computadores', NULL),
		                ('6a561299-c349-4fcc-88d4-e731726c98ee', 'Computadores Apple', 'f264a52e-0b89-4938-b9c6-ff943c2d4e57'),
		                ('cdc389e8-1136-4c82-8c31-1cdd82269eae', 'Celulares', NULL);
            ";

            string produtoSql = @"
                INSERT INTO Produto (Id, Nome, Descricao, ValorPontos, DataCadastro)
                VALUES 	('6aa0291c-4c77-411e-82b5-12f1d055e48a', 'MacBook Pro', 'M1 16GB', 300, NOW()),
                        ('c2289712-0990-4062-8494-a7392e5c1cd6', 'Surface', 'i9 16GB', 300, NOW()),
                        ('83626e06-d717-4c7a-b423-294c10dc34fc', 'iPhone X', 'Apple 128GB', 100, NOW()),
                        ('63e8a2eb-edc5-48c4-ab63-7e2fed350e93', 'iMAC', 'Apple i7', 200, NOW()),
                        ('fbe0c014-2685-4437-8cd0-2dba17d1276f', 'Galaxy S21', 'Samsung 129GB', 100, NOW()),
                        ('626f1625-4c07-407b-a5ce-bb3a0fdc68cb', 'Xiaomi MI9', 'MI 129GB', 100, NOW()),
                        ('fbd85c52-e478-42b8-b01e-4a9e0a43723d', 'Galaxy S20', 'Samsung 129GB', 100, NOW());
            ";

            string produtoCategoriaSql = @"
                INSERT INTO ProdutoCategoria (ProdutoId, CategoriaId)
                VALUES  ('6aa0291c-4c77-411e-82b5-12f1d055e48a', 'f264a52e-0b89-4938-b9c6-ff943c2d4e57'),
                        ('6aa0291c-4c77-411e-82b5-12f1d055e48a', '6a561299-c349-4fcc-88d4-e731726c98ee'),
                        ('c2289712-0990-4062-8494-a7392e5c1cd6', 'f264a52e-0b89-4938-b9c6-ff943c2d4e57'),
                        ('83626e06-d717-4c7a-b423-294c10dc34fc', 'cdc389e8-1136-4c82-8c31-1cdd82269eae'),
                        ('63e8a2eb-edc5-48c4-ab63-7e2fed350e93', 'f264a52e-0b89-4938-b9c6-ff943c2d4e57'),
                        ('63e8a2eb-edc5-48c4-ab63-7e2fed350e93', '6a561299-c349-4fcc-88d4-e731726c98ee'),
                        ('fbe0c014-2685-4437-8cd0-2dba17d1276f', 'cdc389e8-1136-4c82-8c31-1cdd82269eae'),
                        ('626f1625-4c07-407b-a5ce-bb3a0fdc68cb', 'cdc389e8-1136-4c82-8c31-1cdd82269eae'),
                        ('fbd85c52-e478-42b8-b01e-4a9e0a43723d', 'cdc389e8-1136-4c82-8c31-1cdd82269eae');
            ";

            migrationBuilder.Sql(empresaSql);
            migrationBuilder.Sql(categoriaSql);
            migrationBuilder.Sql(produtoSql);
            migrationBuilder.Sql(produtoCategoriaSql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM ProdutoCategoria;");
            migrationBuilder.Sql("DELETE FROM Produto;");
            migrationBuilder.Sql("DELETE FROM Categoria;");
            migrationBuilder.Sql("DELETE FROM Empresa;");
        }
    }
}
