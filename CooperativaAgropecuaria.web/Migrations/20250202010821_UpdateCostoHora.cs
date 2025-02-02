using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CooperativaAgropecuaria.web.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCostoHora : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "CostoHora",
                table: "Maquinarias",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CostoHora",
                table: "Maquinarias",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }
    }
}
