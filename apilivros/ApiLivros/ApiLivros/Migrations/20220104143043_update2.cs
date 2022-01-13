using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiLivros.Migrations
{
    public partial class update2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Autores",
                keyColumn: "AutorId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Autores",
                keyColumn: "AutorId",
                keyValue: 2);

            migrationBuilder.InsertData(
                table: "Livros",
                columns: new[] { "LivroId", "Ano", "AutorId", "Nome", "Tema" },
                values: new object[] { 1, 2020, 1, "Livro 1 lero lero", "Comedia" });

            migrationBuilder.InsertData(
                table: "Livros",
                columns: new[] { "LivroId", "Ano", "AutorId", "Nome", "Tema" },
                values: new object[] { 2, 2021, 2, "Roubaram meu celular", "Drama" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Livros",
                keyColumn: "LivroId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Livros",
                keyColumn: "LivroId",
                keyValue: 2);

            migrationBuilder.InsertData(
                table: "Autores",
                columns: new[] { "AutorId", "Nome" },
                values: new object[] { 2, "vinicius" });

            migrationBuilder.InsertData(
                table: "Autores",
                columns: new[] { "AutorId", "Nome" },
                values: new object[] { 1, "Henrique" });
        }
    }
}
