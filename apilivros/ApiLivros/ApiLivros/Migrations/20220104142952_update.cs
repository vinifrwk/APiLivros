using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiLivros.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Autores",
                columns: new[] { "AutorId", "Nome" },
                values: new object[] { 2, "vinicius" });

            migrationBuilder.InsertData(
                table: "Autores",
                columns: new[] { "AutorId", "Nome" },
                values: new object[] { 1, "Henrique" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Autores",
                keyColumn: "AutorId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Autores",
                keyColumn: "AutorId",
                keyValue: 2);
        }
    }
}
