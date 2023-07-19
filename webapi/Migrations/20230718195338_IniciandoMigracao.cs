using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapi.Migrations
{
    /// <inheritdoc />
    public partial class IniciandoMigracao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Entradas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantidade = table.Column<int>(type: "int", nullable: true),
                    DataHora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Local = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entradas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Saidas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantidade = table.Column<int>(type: "int", nullable: true),
                    DataHora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Local = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Saidas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mercadorias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroRegistro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fabricante = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EntradaId = table.Column<int>(type: "int", nullable: false),
                    SaidaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mercadorias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mercadorias_Entradas_EntradaId",
                        column: x => x.EntradaId,
                        principalTable: "Entradas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Mercadorias_Saidas_SaidaId",
                        column: x => x.SaidaId,
                        principalTable: "Saidas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Mercadorias_EntradaId",
                table: "Mercadorias",
                column: "EntradaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Mercadorias_SaidaId",
                table: "Mercadorias",
                column: "SaidaId",
                unique: true,
                filter: "[SaidaId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mercadorias");

            migrationBuilder.DropTable(
                name: "Entradas");

            migrationBuilder.DropTable(
                name: "Saidas");
        }
    }
}
