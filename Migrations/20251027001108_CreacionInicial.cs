using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gestor_de_Rutinas___GYM.Migrations
{
    /// <inheritdoc />
    public partial class CreacionInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    IdCliente = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Apellido = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Peso = table.Column<decimal>(type: "TEXT", nullable: false),
                    Altura = table.Column<decimal>(type: "TEXT", nullable: false),
                    Objetivo = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.IdCliente);
                });

            migrationBuilder.CreateTable(
                name: "EjerciciosBase",
                columns: table => new
                {
                    IdEjercicioBase = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    GrupoMuscular = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EjerciciosBase", x => x.IdEjercicioBase);
                });

            migrationBuilder.CreateTable(
                name: "Rutinas",
                columns: table => new
                {
                    IdRutina = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    DuracionSemana = table.Column<int>(type: "INTEGER", nullable: false),
                    Descripcion = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    ClienteIdCliente = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rutinas", x => x.IdRutina);
                    table.ForeignKey(
                        name: "FK_Rutinas_Clientes_ClienteIdCliente",
                        column: x => x.ClienteIdCliente,
                        principalTable: "Clientes",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DiasEntrenamiento",
                columns: table => new
                {
                    IdDia = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DiaSemana = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    GrupoMuscular = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    RutinaIdRutina = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiasEntrenamiento", x => x.IdDia);
                    table.ForeignKey(
                        name: "FK_DiasEntrenamiento_Rutinas_RutinaIdRutina",
                        column: x => x.RutinaIdRutina,
                        principalTable: "Rutinas",
                        principalColumn: "IdRutina",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ejercicios",
                columns: table => new
                {
                    IdEjercicio = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EjercicioBaseIdEjercicioBase = table.Column<int>(type: "INTEGER", nullable: false),
                    Series = table.Column<int>(type: "INTEGER", maxLength: 10, nullable: false),
                    Repeticiones = table.Column<int>(type: "INTEGER", nullable: false),
                    Descanso = table.Column<decimal>(type: "TEXT", nullable: false),
                    Notas = table.Column<string>(type: "TEXT", nullable: false),
                    DiaEntrenamientoIdDia = table.Column<int>(type: "INTEGER", nullable: true),
                    EjercicioBaseId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ejercicios", x => x.IdEjercicio);
                    table.ForeignKey(
                        name: "FK_Ejercicios_DiasEntrenamiento_DiaEntrenamientoIdDia",
                        column: x => x.DiaEntrenamientoIdDia,
                        principalTable: "DiasEntrenamiento",
                        principalColumn: "IdDia",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ejercicios_EjerciciosBase_EjercicioBaseId",
                        column: x => x.EjercicioBaseId,
                        principalTable: "EjerciciosBase",
                        principalColumn: "IdEjercicioBase");
                    table.ForeignKey(
                        name: "FK_Ejercicios_EjerciciosBase_EjercicioBaseIdEjercicioBase",
                        column: x => x.EjercicioBaseIdEjercicioBase,
                        principalTable: "EjerciciosBase",
                        principalColumn: "IdEjercicioBase",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetallesAvanzados",
                columns: table => new
                {
                    IdDetalle = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EjercicioId = table.Column<int>(type: "INTEGER", nullable: false),
                    PorcentajeRM = table.Column<double>(type: "REAL", precision: 5, scale: 2, nullable: false),
                    RM = table.Column<double>(type: "REAL", precision: 6, scale: 2, nullable: false),
                    Objetivo = table.Column<string>(type: "TEXT", nullable: false),
                    Nota = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetallesAvanzados", x => x.IdDetalle);
                    table.ForeignKey(
                        name: "FK_DetallesAvanzados_Ejercicios_EjercicioId",
                        column: x => x.EjercicioId,
                        principalTable: "Ejercicios",
                        principalColumn: "IdEjercicio",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetallesAvanzados_EjercicioId",
                table: "DetallesAvanzados",
                column: "EjercicioId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DiasEntrenamiento_RutinaIdRutina",
                table: "DiasEntrenamiento",
                column: "RutinaIdRutina");

            migrationBuilder.CreateIndex(
                name: "IX_Ejercicios_DiaEntrenamientoIdDia",
                table: "Ejercicios",
                column: "DiaEntrenamientoIdDia");

            migrationBuilder.CreateIndex(
                name: "IX_Ejercicios_EjercicioBaseId",
                table: "Ejercicios",
                column: "EjercicioBaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Ejercicios_EjercicioBaseIdEjercicioBase",
                table: "Ejercicios",
                column: "EjercicioBaseIdEjercicioBase");

            migrationBuilder.CreateIndex(
                name: "IX_Rutinas_ClienteIdCliente",
                table: "Rutinas",
                column: "ClienteIdCliente");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetallesAvanzados");

            migrationBuilder.DropTable(
                name: "Ejercicios");

            migrationBuilder.DropTable(
                name: "DiasEntrenamiento");

            migrationBuilder.DropTable(
                name: "EjerciciosBase");

            migrationBuilder.DropTable(
                name: "Rutinas");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
