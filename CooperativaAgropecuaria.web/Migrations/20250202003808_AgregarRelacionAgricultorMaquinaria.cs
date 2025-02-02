using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CooperativaAgropecuaria.web.Migrations
{
    /// <inheritdoc />
    public partial class AgregarRelacionAgricultorMaquinaria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Maquinarias",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CostoHora = table.Column<int>(type: "int", nullable: false),
                    AgricultorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maquinarias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Maquinarias_Agricultores_AgricultorId",
                        column: x => x.AgricultorId,
                        principalTable: "Agricultores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Maquinarias_AgricultorId",
                table: "Maquinarias",
                column: "AgricultorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Maquinarias");
        }
    }
}
