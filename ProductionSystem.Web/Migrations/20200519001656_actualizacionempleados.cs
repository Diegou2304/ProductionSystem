using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductionSystem.Web.Migrations
{
    public partial class actualizacionempleados : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FaseId",
                table: "Personas",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Personas_FaseId",
                table: "Personas",
                column: "FaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_Fases_FaseId",
                table: "Personas",
                column: "FaseId",
                principalTable: "Fases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personas_Fases_FaseId",
                table: "Personas");

            migrationBuilder.DropIndex(
                name: "IX_Personas_FaseId",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "FaseId",
                table: "Personas");
        }
    }
}
