using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiRest.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate25 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AsignacionTurnos_IdTurno",
                table: "AsignacionTurnos");

            migrationBuilder.CreateIndex(
                name: "IX_AsignacionTurnos_IdTurno_IdEmpleado",
                table: "AsignacionTurnos",
                columns: new[] { "IdTurno", "IdEmpleado" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AsignacionTurnos_IdTurno_IdEmpleado",
                table: "AsignacionTurnos");

            migrationBuilder.CreateIndex(
                name: "IX_AsignacionTurnos_IdTurno",
                table: "AsignacionTurnos",
                column: "IdTurno");
        }
    }
}
