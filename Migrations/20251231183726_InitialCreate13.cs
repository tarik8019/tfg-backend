using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiRest.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate13 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departamentos_ResponsableEmpleados_ResponsableEmpleadoId",
                table: "Departamentos");

            migrationBuilder.AlterColumn<int>(
                name: "ResponsableEmpleadoId",
                table: "Departamentos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Departamentos_ResponsableEmpleados_ResponsableEmpleadoId",
                table: "Departamentos",
                column: "ResponsableEmpleadoId",
                principalTable: "ResponsableEmpleados",
                principalColumn: "IdResponsableEmpleado");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departamentos_ResponsableEmpleados_ResponsableEmpleadoId",
                table: "Departamentos");

            migrationBuilder.AlterColumn<int>(
                name: "ResponsableEmpleadoId",
                table: "Departamentos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Departamentos_ResponsableEmpleados_ResponsableEmpleadoId",
                table: "Departamentos",
                column: "ResponsableEmpleadoId",
                principalTable: "ResponsableEmpleados",
                principalColumn: "IdResponsableEmpleado",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
