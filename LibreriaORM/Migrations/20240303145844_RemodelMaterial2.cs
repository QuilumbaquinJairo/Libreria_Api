using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibreriaORM.Migrations
{
    /// <inheritdoc />
    public partial class RemodelMaterial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaterialBibliograficoTempId1",
                table: "Libro",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaterialBibliograficoTempId1",
                table: "Libro");
        }
    }
}
