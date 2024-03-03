using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibreriaORM.Migrations
{
    /// <inheritdoc />
    public partial class AddPrestamo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Prestamo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fechaSalida = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fechaRegreso = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdPersona = table.Column<int>(type: "int", nullable: false),
                    IdMaterialBibliografico = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prestamo", x => x.id);
                    table.ForeignKey(
                        name: "FK_Prestamo_MaterialBibliografico_IdMaterialBibliografico",
                        column: x => x.IdMaterialBibliografico,
                        principalTable: "MaterialBibliografico",
                        principalColumn: "IdMaterialBibliografico",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prestamo_Persona_IdPersona",
                        column: x => x.IdPersona,
                        principalTable: "Persona",
                        principalColumn: "IdPersona",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prestamo_IdMaterialBibliografico",
                table: "Prestamo",
                column: "IdMaterialBibliografico",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Prestamo_IdPersona",
                table: "Prestamo",
                column: "IdPersona",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prestamo");
        }
    }
}
