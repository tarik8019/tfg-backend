using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiRest.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Ciudad",
                table: "Empleados",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CodigoEmpleado",
                table: "Empleados",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CodigoPostal",
                table: "Empleados",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Direccion",
                table: "Empleados",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaNacimiento",
                table: "Empleados",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "IdDepartamento",
                table: "Empleados",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Jornada",
                table: "Empleados",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Observaciones",
                table: "Empleados",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Provincia",
                table: "Empleados",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "SalarioBase",
                table: "Empleados",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "TipoContrato",
                table: "Empleados",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_IdDepartamento",
                table: "Empleados",
                column: "IdDepartamento");

            migrationBuilder.AddForeignKey(
                name: "FK_Empleados_Departamentos_IdDepartamento",
                table: "Empleados",
                column: "IdDepartamento",
                principalTable: "Departamentos",
                principalColumn: "IdDepartamento",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empleados_Departamentos_IdDepartamento",
                table: "Empleados");

            migrationBuilder.DropIndex(
                name: "IX_Empleados_IdDepartamento",
                table: "Empleados");

            migrationBuilder.DropColumn(
                name: "Ciudad",
                table: "Empleados");

            migrationBuilder.DropColumn(
                name: "CodigoEmpleado",
                table: "Empleados");

            migrationBuilder.DropColumn(
                name: "CodigoPostal",
                table: "Empleados");

            migrationBuilder.DropColumn(
                name: "Direccion",
                table: "Empleados");

            migrationBuilder.DropColumn(
                name: "FechaNacimiento",
                table: "Empleados");

            migrationBuilder.DropColumn(
                name: "IdDepartamento",
                table: "Empleados");

            migrationBuilder.DropColumn(
                name: "Jornada",
                table: "Empleados");

            migrationBuilder.DropColumn(
                name: "Observaciones",
                table: "Empleados");

            migrationBuilder.DropColumn(
                name: "Provincia",
                table: "Empleados");

            migrationBuilder.DropColumn(
                name: "SalarioBase",
                table: "Empleados");

            migrationBuilder.DropColumn(
                name: "TipoContrato",
                table: "Empleados");
        }
    }
}
