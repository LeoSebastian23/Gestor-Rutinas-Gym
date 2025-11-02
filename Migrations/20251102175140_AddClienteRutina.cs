using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gestor_de_Rutinas___GYM.Migrations
{
    /// <inheritdoc />
    public partial class AddClienteRutina : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rutinas_Clientes_ClienteIdCliente",
                table: "Rutinas");

            migrationBuilder.DropIndex(
                name: "IX_Rutinas_ClienteIdCliente",
                table: "Rutinas");

            migrationBuilder.DropColumn(
                name: "ClienteIdCliente",
                table: "Rutinas");

            migrationBuilder.CreateTable(
                name: "ClienteRutina",
                columns: table => new
                {
                    IdCliente = table.Column<int>(type: "INTEGER", nullable: false),
                    IdRutina = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClienteRutina", x => new { x.IdCliente, x.IdRutina });
                    table.ForeignKey(
                        name: "FK_ClienteRutina_Clientes_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Clientes",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClienteRutina_Rutinas_IdRutina",
                        column: x => x.IdRutina,
                        principalTable: "Rutinas",
                        principalColumn: "IdRutina",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClienteRutina_IdRutina",
                table: "ClienteRutina",
                column: "IdRutina");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClienteRutina");

            migrationBuilder.AddColumn<int>(
                name: "ClienteIdCliente",
                table: "Rutinas",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rutinas_ClienteIdCliente",
                table: "Rutinas",
                column: "ClienteIdCliente");

            migrationBuilder.AddForeignKey(
                name: "FK_Rutinas_Clientes_ClienteIdCliente",
                table: "Rutinas",
                column: "ClienteIdCliente",
                principalTable: "Clientes",
                principalColumn: "IdCliente",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
