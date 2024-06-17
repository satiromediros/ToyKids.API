using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIToyKids.Migrations
{
    /// <inheritdoc />
    public partial class NullableProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "NomeEspacoFesta",
                table: "Reservas",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Reservas",
                keyColumn: "NomeEspacoFesta",
                keyValue: null,
                column: "NomeEspacoFesta",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "NomeEspacoFesta",
                table: "Reservas",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
