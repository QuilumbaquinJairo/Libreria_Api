using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibreriaORM.Migrations
{
    /// <inheritdoc />
    public partial class AddLibroStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "status",
                table: "MaterialBibliografico",
                type: "bit",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "status",
                table: "MaterialBibliografico",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");
        }
    }
}
