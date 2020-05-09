using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductionSystem.Web.Migrations
{
    public partial class ArregloTablaEmpleado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Producciones_EmpleadosProducciones_EmpleadoProducciónId",
                table: "Producciones");

            migrationBuilder.DropTable(
                name: "EmpleadosProducciones");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Productos",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Personas",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Direccion",
                table: "Personas",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CI",
                table: "Personas",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ApellidoPaterno",
                table: "Personas",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ApellidoMaterno",
                table: "Personas",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cargo",
                table: "Personas",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Telefono",
                table: "Personas",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Personas",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Producciones_Personas_EmpleadoProducciónId",
                table: "Producciones",
                column: "EmpleadoProducciónId",
                principalTable: "Personas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Producciones_Personas_EmpleadoProducciónId",
                table: "Producciones");

            migrationBuilder.DropColumn(
                name: "Cargo",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "Telefono",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Personas");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Productos",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Personas",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Direccion",
                table: "Personas",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "CI",
                table: "Personas",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "ApellidoPaterno",
                table: "Personas",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "ApellidoMaterno",
                table: "Personas",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.CreateTable(
                name: "EmpleadosProducciones",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdEmpleado = table.Column<int>(nullable: false),
                    PersonaId = table.Column<int>(nullable: true),
                    Telefono = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpleadosProducciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmpleadosProducciones_Personas_PersonaId",
                        column: x => x.PersonaId,
                        principalTable: "Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmpleadosProducciones_PersonaId",
                table: "EmpleadosProducciones",
                column: "PersonaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Producciones_EmpleadosProducciones_EmpleadoProducciónId",
                table: "Producciones",
                column: "EmpleadoProducciónId",
                principalTable: "EmpleadosProducciones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
