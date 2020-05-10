using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductionSystem.Web.Migrations
{
    public partial class ArregloTablaEmpresa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Direccion",
                table: "Personas",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Telefono",
                table: "Empresas",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Direccion",
                table: "Empresas",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Direccion",
                table: "Personas",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Telefono",
                table: "Empresas",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Direccion",
                table: "Empresas",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);
        }
    }
}
