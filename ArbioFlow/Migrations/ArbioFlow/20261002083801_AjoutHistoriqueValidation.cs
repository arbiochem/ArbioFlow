using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArbioFlow.Migrations.ArbioFlow
{
    /// <inheritdoc />
    public partial class AjoutHistoriqueValidation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HistoriqueValidation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoPiece = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ArRef = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DateValidation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Validateur = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Designation = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    QteValidee = table.Column<decimal>(type: "decimal(18,3)", precision: 18, scale: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoriqueValidation", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HistoriqueValidation_DoPiece",
                table: "HistoriqueValidation",
                column: "DoPiece");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HistoriqueValidation");
        }
    }
}
