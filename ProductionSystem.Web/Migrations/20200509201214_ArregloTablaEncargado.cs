using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductionSystem.Web.Migrations
{
    public partial class ArregloTablaEncargado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EncargadosEmpresas");

            migrationBuilder.AddColumn<int>(
                name: "IdEmpresa",
                table: "Personas",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EncargadoEmpresa_Telefono",
                table: "Personas",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Personas_IdEmpresa",
                table: "Personas",
                column: "IdEmpresa",
                unique: true,
                filter: "[IdEmpresa] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_Empresas_IdEmpresa",
                table: "Personas",
                column: "IdEmpresa",
                principalTable: "Empresas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personas_Empresas_IdEmpresa",
                table: "Personas");

            migrationBuilder.DropIndex(
                name: "IX_Personas_IdEmpresa",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "IdEmpresa",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "EncargadoEmpresa_Telefono",
                table: "Personas");

            migrationBuilder.CreateTable(
                name: "EncargadosEmpresas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    PersonaId = table.Column<int>(nullable: true),
                    Telefono = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EncargadosEmpresas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EncargadosEmpresas_Empresas_Id",
                        column: x => x.Id,
                        principalTable: "Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EncargadosEmpresas_Personas_PersonaId",
                        column: x => x.PersonaId,
                        principalTable: "Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EncargadosEmpresas_PersonaId",
                table: "EncargadosEmpresas",
                column: "PersonaId");
        }
    }
}
