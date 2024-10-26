using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Desafio_Marlin.Migrations
{
    /// <inheritdoc />
    public partial class NovasPropsTurmas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Turmas",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "Periodo",
                table: "Turmas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Turmas");

            migrationBuilder.DropColumn(
                name: "Periodo",
                table: "Turmas");
        }
    }
}
