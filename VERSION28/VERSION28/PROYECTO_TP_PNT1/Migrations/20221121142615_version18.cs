using Microsoft.EntityFrameworkCore.Migrations;

namespace PROYECTO_TP_PNT1.Migrations
{
    public partial class version18 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "capacidadHabitaciones",
                table: "Alojamientos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "precioDesayuno",
                table: "Alojamientos",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "capacidadHabitaciones",
                table: "Alojamientos");

            migrationBuilder.DropColumn(
                name: "precioDesayuno",
                table: "Alojamientos");
        }
    }
}
