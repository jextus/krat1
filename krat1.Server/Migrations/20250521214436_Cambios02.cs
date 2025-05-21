using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace krat1.Server.Migrations
{
    /// <inheritdoc />
    public partial class Cambios02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "confirmarContraseña",
                table: "Usuarios",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "confirmarContraseña",
                table: "Empresas",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "contraseña",
                table: "Empresas",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "confirmarContraseña",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "confirmarContraseña",
                table: "Empresas");

            migrationBuilder.DropColumn(
                name: "contraseña",
                table: "Empresas");
        }
    }
}
