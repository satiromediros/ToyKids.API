using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIToyKids.Migrations
{
    /// <inheritdoc />
    public partial class AjustaReservas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "HoraReserva",
                table: "Reservas",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time(6)")
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeSpan>(
                name: "HoraReserva",
                table: "Reservas",
                type: "time(6)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
