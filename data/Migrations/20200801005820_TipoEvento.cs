using Microsoft.EntityFrameworkCore.Migrations;

namespace data.Migrations
{
    public partial class TipoEvento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TipoEventoId",
                table: "Eventos",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TipoEventos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descriçao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoEventos", x => x.Id);
                });

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

            migrationBuilder.DropTable(
                name: "TipoEventos");

            migrationBuilder.DropIndex(
                name: "IX_Eventos_TipoEventoId",
                table: "Eventos");

            migrationBuilder.DropColumn(
                name: "TipoEventoId",
                table: "Eventos");
        }
    }
}
