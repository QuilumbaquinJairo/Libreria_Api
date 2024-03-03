using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibreriaORM.Migrations
{
    /// <inheritdoc />
    public partial class RemodelMaterial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdRevista",
                table: "Revista");

            migrationBuilder.DropColumn(
                name: "IdLibro",
                table: "Libro");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdRevista",
                table: "Revista",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdLibro",
                table: "Libro",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
