using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductionSystem.Web.Migrations
{
    public partial class InitialDb3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(maxLength: 50, nullable: false),
                    ApellidoPaterno = table.Column<string>(maxLength: 50, nullable: false),
                    ApellidoMaterno = table.Column<string>(maxLength: 50, nullable: false),
                    Ci = table.Column<int>(nullable: false),
                    Direccion = table.Column<string>(maxLength: 50, nullable: false),
                    Telefono = table.Column<string>(nullable: false),
                    EmpresaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EncargadosEmpresas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EncargadosEmpresas_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EncargadosEmpresas_EmpresaId",
                table: "EncargadosEmpresas",
                column: "EmpresaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
