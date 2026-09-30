using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArbioFlow.Migrations.Arbio
{
    /// <inheritdoc />
    public partial class UtilisateurArbio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UtilisateurArbio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Actif = table.Column<bool>(type: "bit", nullable: false),
                    PendingHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateDemande = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UtilisateurArbio", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UtilisateurArbio_Login",
                table: "UtilisateurArbio",
                column: "Login",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UtilisateurArbio");
        }
    }
}
