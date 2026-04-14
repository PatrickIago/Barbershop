using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Barbershop.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AdicionandoNovosCampos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CPF",
                table: "Profissionais",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Celular",
                table: "Profissionais",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CPF",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CPF",
                table: "Profissionais");

            migrationBuilder.DropColumn(
                name: "Celular",
                table: "Profissionais");

            migrationBuilder.DropColumn(
                name: "CPF",
                table: "Clientes");
        }
    }
}
