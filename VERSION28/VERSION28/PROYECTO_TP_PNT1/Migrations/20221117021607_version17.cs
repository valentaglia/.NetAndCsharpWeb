using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PROYECTO_TP_PNT1.Migrations
{
    public partial class version17 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alojamientos",
                columns: table => new
                {
                    idAlojamiento = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(nullable: false),
                    direccion = table.Column<string>(nullable: false),
                    cantHabitacionesDisponibles = table.Column<int>(nullable: false),
                    tipo = table.Column<int>(nullable: false),
                    precio = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alojamientos", x => x.idAlojamiento);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    idCliente = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(nullable: false),
                    apellido = table.Column<string>(nullable: false),
                    dni = table.Column<string>(maxLength: 10, nullable: false),
                    edad = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.idCliente);
                });

            migrationBuilder.CreateTable(
                name: "Reservas",
                columns: table => new
                {
                    idReserva = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    entrada = table.Column<DateTime>(nullable: false),
                    salida = table.Column<DateTime>(nullable: false),
                    confirmado = table.Column<bool>(nullable: false),
                    desayuno = table.Column<bool>(nullable: false),
                    cantPersonas = table.Column<int>(nullable: false),
                    CantHabitaciones = table.Column<int>(nullable: false),
                    idAlojamiento = table.Column<int>(nullable: true),
                    alojamientoidAlojamiento = table.Column<int>(nullable: true),
                    idCliente = table.Column<int>(nullable: true),
                    clienteidCliente = table.Column<int>(nullable: true),
                    precioTotal = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservas", x => x.idReserva);
                    table.ForeignKey(
                        name: "FK_Reservas_Alojamientos_alojamientoidAlojamiento",
                        column: x => x.alojamientoidAlojamiento,
                        principalTable: "Alojamientos",
                        principalColumn: "idAlojamiento",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reservas_Clientes_clienteidCliente",
                        column: x => x.clienteidCliente,
                        principalTable: "Clientes",
                        principalColumn: "idCliente",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_alojamientoidAlojamiento",
                table: "Reservas",
                column: "alojamientoidAlojamiento");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_clienteidCliente",
                table: "Reservas",
                column: "clienteidCliente");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservas");

            migrationBuilder.DropTable(
                name: "Alojamientos");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
