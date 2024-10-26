using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Desafio_Marlin.Migrations
{
    /// <inheritdoc />
    public partial class NovasColunas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Genero",
                table: "Alunos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Idade",
                table: "Alunos",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Genero",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "Idade",
                table: "Alunos");
        }
    }
}
