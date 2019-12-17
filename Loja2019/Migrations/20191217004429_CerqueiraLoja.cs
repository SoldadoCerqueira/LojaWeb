using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Loja2019.Migrations
{
    public partial class CerqueiraLoja : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roupa",
                columns: table => new
                {
                    RoupaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: true),
                    Quantidade = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roupa", x => x.RoupaId);
                });

            migrationBuilder.CreateTable(
                name: "Confeccao",
                columns: table => new
                {
                    ConfeccaoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoupaId = table.Column<int>(nullable: false),
                    Data = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Confeccao", x => x.ConfeccaoId);
                    table.ForeignKey(
                        name: "FK_Confeccao_Roupa_RoupaId",
                        column: x => x.RoupaId,
                        principalTable: "Roupa",
                        principalColumn: "RoupaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Confeccao_RoupaId",
                table: "Confeccao",
                column: "RoupaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Confeccao");

            migrationBuilder.DropTable(
                name: "Roupa");
        }
    }
}
