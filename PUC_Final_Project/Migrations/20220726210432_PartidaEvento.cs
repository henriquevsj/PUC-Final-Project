using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PUC_Final_Project.Migrations
{
    public partial class PartidaEvento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Partida_Evento_EventoOcorridoId",
                table: "Partida");

            migrationBuilder.DropIndex(
                name: "IX_Partida_EventoOcorridoId",
                table: "Partida");

            migrationBuilder.DropColumn(
                name: "EventoOcorridoId",
                table: "Partida");

            migrationBuilder.AddColumn<int>(
                name: "PartidaId",
                table: "Evento",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Evento_PartidaId",
                table: "Evento",
                column: "PartidaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Evento_Partida_PartidaId",
                table: "Evento",
                column: "PartidaId",
                principalTable: "Partida",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Evento_Partida_PartidaId",
                table: "Evento");

            migrationBuilder.DropIndex(
                name: "IX_Evento_PartidaId",
                table: "Evento");

            migrationBuilder.DropColumn(
                name: "PartidaId",
                table: "Evento");

            migrationBuilder.AddColumn<int>(
                name: "EventoOcorridoId",
                table: "Partida",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Partida_EventoOcorridoId",
                table: "Partida",
                column: "EventoOcorridoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Partida_Evento_EventoOcorridoId",
                table: "Partida",
                column: "EventoOcorridoId",
                principalTable: "Evento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
