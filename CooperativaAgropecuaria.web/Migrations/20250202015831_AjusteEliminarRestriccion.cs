using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CooperativaAgropecuaria.web.Migrations
{
    /// <inheritdoc />
    public partial class AjusteEliminarRestriccion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UsosMaquinaria",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaquinariaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AgricultorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HorasUso = table.Column<double>(type: "float", nullable: false),
                    CostoTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsosMaquinaria", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsosMaquinaria_Agricultores_AgricultorId",
                        column: x => x.AgricultorId,
                        principalTable: "Agricultores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsosMaquinaria_Maquinarias_MaquinariaId",
                        column: x => x.MaquinariaId,
                        principalTable: "Maquinarias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsosMaquinaria_AgricultorId",
                table: "UsosMaquinaria",
                column: "AgricultorId");

            migrationBuilder.CreateIndex(
                name: "IX_UsosMaquinaria_MaquinariaId",
                table: "UsosMaquinaria",
                column: "MaquinariaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsosMaquinaria");
        }
    }
}
