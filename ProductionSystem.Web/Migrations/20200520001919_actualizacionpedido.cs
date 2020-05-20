using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductionSystem.Web.Migrations
{
    public partial class actualizacionpedido : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "estado",
                table: "Pedidos",
                nullable: true,
                oldClrType: typeof(bool));

            migrationBuilder.AddColumn<int>(
                name: "NumeroFase",
                table: "Pedidos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CargoNumero",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumeroFase",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "CargoNumero",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<bool>(
                name: "estado",
                table: "Pedidos",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
