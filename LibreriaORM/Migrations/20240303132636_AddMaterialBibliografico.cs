using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibreriaORM.Migrations
{
    /// <inheritdoc />
    public partial class AddMaterialBibliografico : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MaterialBibliografico",
                columns: table => new
                {
                    IdMaterialBibliografico = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tipoMaterial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    autor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    anio = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialBibliografico", x => x.IdMaterialBibliografico);
                });

            migrationBuilder.CreateTable(
                name: "Libro",
                columns: table => new
                {
                    IdMaterialBibliografico = table.Column<int>(type: "int", nullable: false),
                    IdLibro = table.Column<int>(type: "int", nullable: false),
                    editorialLibro = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Libro", x => x.IdMaterialBibliografico);
                    table.ForeignKey(
                        name: "FK_Libro_MaterialBibliografico_IdMaterialBibliografico",
                        column: x => x.IdMaterialBibliografico,
                        principalTable: "MaterialBibliografico",
                        principalColumn: "IdMaterialBibliografico",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Revista",
                columns: table => new
                {
                    IdMaterialBibliografico = table.Column<int>(type: "int", nullable: false),
                    IdRevista = table.Column<int>(type: "int", nullable: false),
                    EditorialRevista = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Revista", x => x.IdMaterialBibliografico);
                    table.ForeignKey(
                        name: "FK_Revista_MaterialBibliografico_IdMaterialBibliografico",
                        column: x => x.IdMaterialBibliografico,
                        principalTable: "MaterialBibliografico",
                        principalColumn: "IdMaterialBibliografico",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tesis",
                columns: table => new
                {
                    IdMaterialBibliografico = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tesis", x => x.IdMaterialBibliografico);
                    table.ForeignKey(
                        name: "FK_Tesis_MaterialBibliografico_IdMaterialBibliografico",
                        column: x => x.IdMaterialBibliografico,
                        principalTable: "MaterialBibliografico",
                        principalColumn: "IdMaterialBibliografico",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Libro");

            migrationBuilder.DropTable(
                name: "Revista");

            migrationBuilder.DropTable(
                name: "Tesis");

            migrationBuilder.DropTable(
                name: "MaterialBibliografico");
        }
    }
}
