using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibreriaORM.Migrations
{
    /// <inheritdoc />
    public partial class ModifyEstructure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Persona_IdPersona",
                table: "Usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios");

            migrationBuilder.RenameTable(
                name: "Usuarios",
                newName: "Usuario");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario",
                column: "IdPersona");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Persona_IdPersona",
                table: "Usuario",
                column: "IdPersona",
                principalTable: "Persona",
                principalColumn: "IdPersona",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Persona_IdPersona",
                table: "Usuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario");

            migrationBuilder.RenameTable(
                name: "Usuario",
                newName: "Usuarios");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios",
                column: "IdPersona");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Persona_IdPersona",
                table: "Usuarios",
                column: "IdPersona",
                principalTable: "Persona",
                principalColumn: "IdPersona",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
