using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiRest.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate22 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TipoTurno",
                table: "Turnos",
                newName: "Nombre");

            migrationBuilder.AddColumn<bool>(
                name: "esNocturno",
                table: "Turnos",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "esNocturno",
                table: "Turnos");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Turnos",
                newName: "TipoTurno");
        }
    }
}
