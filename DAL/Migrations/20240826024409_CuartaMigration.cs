using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class CuartaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehiculos_Personas_personaId",
                table: "Vehiculos");

            migrationBuilder.DropIndex(
                name: "IX_Vehiculos_personaId",
                table: "Vehiculos");

            migrationBuilder.RenameColumn(
                name: "personaId",
                table: "Vehiculos",
                newName: "PersonaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PersonaId",
                table: "Vehiculos",
                newName: "personaId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculos_personaId",
                table: "Vehiculos",
                column: "personaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehiculos_Personas_personaId",
                table: "Vehiculos",
                column: "personaId",
                principalTable: "Personas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
