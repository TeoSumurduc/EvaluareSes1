using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvaluareSes.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carti",
                columns: table => new
                {
                    CodCarte = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Denumire = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carti", x => x.CodCarte);
                });

            migrationBuilder.CreateTable(
                name: "Editura",
                columns: table => new
                {
                    CodEditura = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Denumire = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Editura", x => x.CodEditura);
                });

            migrationBuilder.CreateTable(
                name: "Autori",
                columns: table => new
                {
                    CodAutor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prenume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EdituraCodEditura = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autori", x => x.CodAutor);
                    table.ForeignKey(
                        name: "FK_Autori_Editura_EdituraCodEditura",
                        column: x => x.EdituraCodEditura,
                        principalTable: "Editura",
                        principalColumn: "CodEditura",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AutoriCarti",
                columns: table => new
                {
                    CodCarte = table.Column<int>(type: "int", nullable: false),
                    CodAutor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutoriCarti", x => new { x.CodCarte, x.CodAutor });
                    table.ForeignKey(
                        name: "FK_AutoriCarti_Autori_CodAutor",
                        column: x => x.CodAutor,
                        principalTable: "Autori",
                        principalColumn: "CodAutor",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AutoriCarti_Carti_CodCarte",
                        column: x => x.CodCarte,
                        principalTable: "Carti",
                        principalColumn: "CodCarte",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Autori_EdituraCodEditura",
                table: "Autori",
                column: "EdituraCodEditura");

            migrationBuilder.CreateIndex(
                name: "IX_AutoriCarti_CodAutor",
                table: "AutoriCarti",
                column: "CodAutor");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AutoriCarti");

            migrationBuilder.DropTable(
                name: "Autori");

            migrationBuilder.DropTable(
                name: "Carti");

            migrationBuilder.DropTable(
                name: "Editura");
        }
    }
}
