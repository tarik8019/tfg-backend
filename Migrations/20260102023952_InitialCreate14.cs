using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiRest.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate14 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departamentos_Empresas_EmpresaId",
                table: "Departamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_Departamentos_ResponsableEmpleados_ResponsableEmpleadoId",
                table: "Departamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_ResponsableEmpleados_Empleados_EmpleadoId",
                table: "ResponsableEmpleados");

            migrationBuilder.DropForeignKey(
                name: "FK_ResponsableEmpleados_Empresas_EmpresaId",
                table: "ResponsableEmpleados");

            migrationBuilder.DropForeignKey(
                name: "FK_ResponsableEmpleados_Responsables_ResponsableId",
                table: "ResponsableEmpleados");

            migrationBuilder.DropForeignKey(
                name: "FK_Responsables_Empleados_EmpleadoId",
                table: "Responsables");

            migrationBuilder.DropForeignKey(
                name: "FK_Responsables_Empresas_EmpresaId",
                table: "Responsables");

            migrationBuilder.RenameColumn(
                name: "EmpresaId",
                table: "Responsables",
                newName: "IdEmpresa");

            migrationBuilder.RenameColumn(
                name: "EmpleadoId",
                table: "Responsables",
                newName: "IdEmpleado");

            migrationBuilder.RenameIndex(
                name: "IX_Responsables_EmpresaId",
                table: "Responsables",
                newName: "IX_Responsables_IdEmpresa");

            migrationBuilder.RenameIndex(
                name: "IX_Responsables_EmpleadoId",
                table: "Responsables",
                newName: "IX_Responsables_IdEmpleado");

            migrationBuilder.RenameColumn(
                name: "ResponsableId",
                table: "ResponsableEmpleados",
                newName: "IdResponsable");

            migrationBuilder.RenameColumn(
                name: "EmpresaId",
                table: "ResponsableEmpleados",
                newName: "IdEmpresa");

            migrationBuilder.RenameColumn(
                name: "EmpleadoId",
                table: "ResponsableEmpleados",
                newName: "IdEmpleado");

            migrationBuilder.RenameIndex(
                name: "IX_ResponsableEmpleados_ResponsableId",
                table: "ResponsableEmpleados",
                newName: "IX_ResponsableEmpleados_IdResponsable");

            migrationBuilder.RenameIndex(
                name: "IX_ResponsableEmpleados_EmpresaId",
                table: "ResponsableEmpleados",
                newName: "IX_ResponsableEmpleados_IdEmpresa");

            migrationBuilder.RenameIndex(
                name: "IX_ResponsableEmpleados_EmpleadoId",
                table: "ResponsableEmpleados",
                newName: "IX_ResponsableEmpleados_IdEmpleado");

            migrationBuilder.RenameColumn(
                name: "ResponsableEmpleadoId",
                table: "Departamentos",
                newName: "IdResponsableEmpleado");

            migrationBuilder.RenameColumn(
                name: "EmpresaId",
                table: "Departamentos",
                newName: "IdEmpresa");

            migrationBuilder.RenameIndex(
                name: "IX_Departamentos_ResponsableEmpleadoId",
                table: "Departamentos",
                newName: "IX_Departamentos_IdResponsableEmpleado");

            migrationBuilder.RenameIndex(
                name: "IX_Departamentos_EmpresaId",
                table: "Departamentos",
                newName: "IX_Departamentos_IdEmpresa");

            migrationBuilder.AddForeignKey(
                name: "FK_Departamentos_Empresas_IdEmpresa",
                table: "Departamentos",
                column: "IdEmpresa",
                principalTable: "Empresas",
                principalColumn: "IdEmpresa",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Departamentos_ResponsableEmpleados_IdResponsableEmpleado",
                table: "Departamentos",
                column: "IdResponsableEmpleado",
                principalTable: "ResponsableEmpleados",
                principalColumn: "IdResponsableEmpleado");

            migrationBuilder.AddForeignKey(
                name: "FK_ResponsableEmpleados_Empleados_IdEmpleado",
                table: "ResponsableEmpleados",
                column: "IdEmpleado",
                principalTable: "Empleados",
                principalColumn: "IdEmpleado",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ResponsableEmpleados_Empresas_IdEmpresa",
                table: "ResponsableEmpleados",
                column: "IdEmpresa",
                principalTable: "Empresas",
                principalColumn: "IdEmpresa",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ResponsableEmpleados_Responsables_IdResponsable",
                table: "ResponsableEmpleados",
                column: "IdResponsable",
                principalTable: "Responsables",
                principalColumn: "IdResponsable",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Responsables_Empleados_IdEmpleado",
                table: "Responsables",
                column: "IdEmpleado",
                principalTable: "Empleados",
                principalColumn: "IdEmpleado",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Responsables_Empresas_IdEmpresa",
                table: "Responsables",
                column: "IdEmpresa",
                principalTable: "Empresas",
                principalColumn: "IdEmpresa",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departamentos_Empresas_IdEmpresa",
                table: "Departamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_Departamentos_ResponsableEmpleados_IdResponsableEmpleado",
                table: "Departamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_ResponsableEmpleados_Empleados_IdEmpleado",
                table: "ResponsableEmpleados");

            migrationBuilder.DropForeignKey(
                name: "FK_ResponsableEmpleados_Empresas_IdEmpresa",
                table: "ResponsableEmpleados");

            migrationBuilder.DropForeignKey(
                name: "FK_ResponsableEmpleados_Responsables_IdResponsable",
                table: "ResponsableEmpleados");

            migrationBuilder.DropForeignKey(
                name: "FK_Responsables_Empleados_IdEmpleado",
                table: "Responsables");

            migrationBuilder.DropForeignKey(
                name: "FK_Responsables_Empresas_IdEmpresa",
                table: "Responsables");

            migrationBuilder.RenameColumn(
                name: "IdEmpresa",
                table: "Responsables",
                newName: "EmpresaId");

            migrationBuilder.RenameColumn(
                name: "IdEmpleado",
                table: "Responsables",
                newName: "EmpleadoId");

            migrationBuilder.RenameIndex(
                name: "IX_Responsables_IdEmpresa",
                table: "Responsables",
                newName: "IX_Responsables_EmpresaId");

            migrationBuilder.RenameIndex(
                name: "IX_Responsables_IdEmpleado",
                table: "Responsables",
                newName: "IX_Responsables_EmpleadoId");

            migrationBuilder.RenameColumn(
                name: "IdResponsable",
                table: "ResponsableEmpleados",
                newName: "ResponsableId");

            migrationBuilder.RenameColumn(
                name: "IdEmpresa",
                table: "ResponsableEmpleados",
                newName: "EmpresaId");

            migrationBuilder.RenameColumn(
                name: "IdEmpleado",
                table: "ResponsableEmpleados",
                newName: "EmpleadoId");

            migrationBuilder.RenameIndex(
                name: "IX_ResponsableEmpleados_IdResponsable",
                table: "ResponsableEmpleados",
                newName: "IX_ResponsableEmpleados_ResponsableId");

            migrationBuilder.RenameIndex(
                name: "IX_ResponsableEmpleados_IdEmpresa",
                table: "ResponsableEmpleados",
                newName: "IX_ResponsableEmpleados_EmpresaId");

            migrationBuilder.RenameIndex(
                name: "IX_ResponsableEmpleados_IdEmpleado",
                table: "ResponsableEmpleados",
                newName: "IX_ResponsableEmpleados_EmpleadoId");

            migrationBuilder.RenameColumn(
                name: "IdResponsableEmpleado",
                table: "Departamentos",
                newName: "ResponsableEmpleadoId");

            migrationBuilder.RenameColumn(
                name: "IdEmpresa",
                table: "Departamentos",
                newName: "EmpresaId");

            migrationBuilder.RenameIndex(
                name: "IX_Departamentos_IdResponsableEmpleado",
                table: "Departamentos",
                newName: "IX_Departamentos_ResponsableEmpleadoId");

            migrationBuilder.RenameIndex(
                name: "IX_Departamentos_IdEmpresa",
                table: "Departamentos",
                newName: "IX_Departamentos_EmpresaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Departamentos_Empresas_EmpresaId",
                table: "Departamentos",
                column: "EmpresaId",
                principalTable: "Empresas",
                principalColumn: "IdEmpresa",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Departamentos_ResponsableEmpleados_ResponsableEmpleadoId",
                table: "Departamentos",
                column: "ResponsableEmpleadoId",
                principalTable: "ResponsableEmpleados",
                principalColumn: "IdResponsableEmpleado");

            migrationBuilder.AddForeignKey(
                name: "FK_ResponsableEmpleados_Empleados_EmpleadoId",
                table: "ResponsableEmpleados",
                column: "EmpleadoId",
                principalTable: "Empleados",
                principalColumn: "IdEmpleado",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ResponsableEmpleados_Empresas_EmpresaId",
                table: "ResponsableEmpleados",
                column: "EmpresaId",
                principalTable: "Empresas",
                principalColumn: "IdEmpresa",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ResponsableEmpleados_Responsables_ResponsableId",
                table: "ResponsableEmpleados",
                column: "ResponsableId",
                principalTable: "Responsables",
                principalColumn: "IdResponsable",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Responsables_Empleados_EmpleadoId",
                table: "Responsables",
                column: "EmpleadoId",
                principalTable: "Empleados",
                principalColumn: "IdEmpleado",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Responsables_Empresas_EmpresaId",
                table: "Responsables",
                column: "EmpresaId",
                principalTable: "Empresas",
                principalColumn: "IdEmpresa",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
