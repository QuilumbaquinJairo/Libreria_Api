using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibreriaORM.Migrations
{
    /// <inheritdoc />
    public partial class FixingKeysPersonaPrestamo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Prestamo_IdMaterialBibliografico",
                table: "Prestamo");

            migrationBuilder.DropIndex(
                name: "IX_Prestamo_IdPersona",
                table: "Prestamo");

            migrationBuilder.DropColumn(
                name: "PersonaTempId",
                table: "Administrador");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Prestamo",
                newName: "IdPrestamo");

            migrationBuilder.CreateIndex(
                name: "IX_Prestamo_IdMaterialBibliografico",
                table: "Prestamo",
                column: "IdMaterialBibliografico");

            migrationBuilder.CreateIndex(
                name: "IX_Prestamo_IdPersona",
                table: "Prestamo",
                column: "IdPersona");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Prestamo_IdMaterialBibliografico",
                table: "Prestamo");

            migrationBuilder.DropIndex(
                name: "IX_Prestamo_IdPersona",
                table: "Prestamo");

            migrationBuilder.RenameColumn(
                name: "IdPrestamo",
                table: "Prestamo",
                newName: "id");

            migrationBuilder.AddColumn<int>(
                name: "PersonaTempId",
                table: "Administrador",
                type: "int",
                nullable: true);

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
    }
}
