using Microsoft.EntityFrameworkCore.Migrations;

namespace data.Migrations
{
    public partial class TipoEventoFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TipoEventoId",
                table: "Eventos",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_TipoEventoId",
                table: "Eventos",
                column: "TipoEventoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Eventos_TipoEventos_TipoEventoId",
                table: "Eventos",
                column: "TipoEventoId",
                principalTable: "TipoEventos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Eventos_TipoEventos_TipoEventoId",
                table: "Eventos");

            migrationBuilder.DropIndex(
                name: "IX_Eventos_TipoEventoId",
                table: "Eventos");

            migrationBuilder.DropColumn(
                name: "TipoEventoId",
                table: "Eventos");
        }
    }
}
