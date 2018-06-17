using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp.Migrations
{
    public partial class RemovendoTabelaEpisodios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Episodios");

            migrationBuilder.AddColumn<int>(
                name: "TotalEpisodios",
                table: "Series",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalEpisodios",
                table: "Series");

            migrationBuilder.CreateTable(
                name: "Episodios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AssistidoEm = table.Column<DateTime>(nullable: true),
                    SerieId = table.Column<int>(nullable: false),
                    Titulo = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Episodios", x => x.Id);
                });
        }
    }
}
