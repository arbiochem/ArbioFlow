using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArbioFlow.Migrations.ArbioFlow
{
    /// <inheritdoc />
    public partial class LivraisonFacture : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LivraisonFacture",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoPiece = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TypeFacture = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TypeRetrait = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Vehicule = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Chauffeur = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateLivraison = table.Column<DateTime>(type: "date", nullable: true),
                    DateDebutPrep = table.Column<DateTime>(type: "date", nullable: true),
                    HeureDebutPrep = table.Column<TimeSpan>(type: "time(0)", nullable: true),
                    StatutPrep = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    CauseNonTransfert = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Observations = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    ModifiePar = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateMaj = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LivraisonFacture", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LivraisonFacture_DoPiece",
                table: "LivraisonFacture",
                column: "DoPiece",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LivraisonFacture");
        }
    }
}
