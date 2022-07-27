using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PUC_Final_Project.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Evento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Inicio = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Gol = table.Column<int>(type: "int", nullable: true),
                    Intervalo = table.Column<int>(type: "int", nullable: true),
                    Acrescimo = table.Column<int>(type: "int", nullable: true),
                    Substituicao = table.Column<int>(type: "int", nullable: true),
                    Advertencia = table.Column<int>(type: "int", nullable: true),
                    Fim = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Time",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Localidade = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Time", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Jogador",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Pais = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimeDonoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jogador", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jogador_Time_TimeDonoId",
                        column: x => x.TimeDonoId,
                        principalTable: "Time",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Partida",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeCasaId = table.Column<int>(type: "int", nullable: false),
                    TimeVisitanteId = table.Column<int>(type: "int", nullable: false),
                    EventoOcorridoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partida", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Partida_Evento_EventoOcorridoId",
                        column: x => x.EventoOcorridoId,
                        principalTable: "Evento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Partida_Time_TimeCasaId",
                        column: x => x.TimeCasaId,
                        principalTable: "Time",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Partida_Time_TimeVisitanteId",
                        column: x => x.TimeVisitanteId,
                        principalTable: "Time",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Transferencia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeOrigemId = table.Column<int>(type: "int", nullable: false),
                    TimeDestinoId = table.Column<int>(type: "int", nullable: false),
                    JogadorTransferidoId = table.Column<int>(type: "int", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Valor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transferencia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transferencia_Jogador_JogadorTransferidoId",
                        column: x => x.JogadorTransferidoId,
                        principalTable: "Jogador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transferencia_Time_TimeDestinoId",
                        column: x => x.TimeDestinoId,
                        principalTable: "Time",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Transferencia_Time_TimeOrigemId",
                        column: x => x.TimeOrigemId,
                        principalTable: "Time",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Torneio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeParticipanteId = table.Column<int>(type: "int", nullable: false),
                    PartidaJogadaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Torneio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Torneio_Partida_PartidaJogadaId",
                        column: x => x.PartidaJogadaId,
                        principalTable: "Partida",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Torneio_Time_TimeParticipanteId",
                        column: x => x.TimeParticipanteId,
                        principalTable: "Time",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Jogador_TimeDonoId",
                table: "Jogador",
                column: "TimeDonoId");

            migrationBuilder.CreateIndex(
                name: "IX_Partida_EventoOcorridoId",
                table: "Partida",
                column: "EventoOcorridoId");

            migrationBuilder.CreateIndex(
                name: "IX_Partida_TimeCasaId",
                table: "Partida",
                column: "TimeCasaId");

            migrationBuilder.CreateIndex(
                name: "IX_Partida_TimeVisitanteId",
                table: "Partida",
                column: "TimeVisitanteId");

            migrationBuilder.CreateIndex(
                name: "IX_Torneio_PartidaJogadaId",
                table: "Torneio",
                column: "PartidaJogadaId");

            migrationBuilder.CreateIndex(
                name: "IX_Torneio_TimeParticipanteId",
                table: "Torneio",
                column: "TimeParticipanteId");

            migrationBuilder.CreateIndex(
                name: "IX_Transferencia_JogadorTransferidoId",
                table: "Transferencia",
                column: "JogadorTransferidoId");

            migrationBuilder.CreateIndex(
                name: "IX_Transferencia_TimeDestinoId",
                table: "Transferencia",
                column: "TimeDestinoId");

            migrationBuilder.CreateIndex(
                name: "IX_Transferencia_TimeOrigemId",
                table: "Transferencia",
                column: "TimeOrigemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Torneio");

            migrationBuilder.DropTable(
                name: "Transferencia");

            migrationBuilder.DropTable(
                name: "Partida");

            migrationBuilder.DropTable(
                name: "Jogador");

            migrationBuilder.DropTable(
                name: "Evento");

            migrationBuilder.DropTable(
                name: "Time");
        }
    }
}
