using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StageConnect.Migrations
{
    /// <inheritdoc />
    public partial class Profil : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Profils",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ville = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Biographie = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NiveauEtudes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Domain = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ecole = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnneObtion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Competances = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CvPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profils", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Profils");
        }
    }
}
