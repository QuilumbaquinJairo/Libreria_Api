using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibreriaORM.Migrations
{
    /// <inheritdoc />
    public partial class deleteAdminid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdAdministrador",
                table: "Administrador");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdAdministrador",
                table: "Administrador",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
