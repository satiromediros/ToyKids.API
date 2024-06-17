using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIToyKids.Migrations
{
    /// <inheritdoc />
    public partial class InclusaoTabelaReservas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reserva_Usuarios_UsuarioId",
                table: "Reserva");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reserva",
                table: "Reserva");

            migrationBuilder.RenameTable(
                name: "Reserva",
                newName: "Reservas");

            migrationBuilder.RenameIndex(
                name: "IX_Reserva_UsuarioId",
                table: "Reservas",
                newName: "IX_Reservas_UsuarioId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reservas",
                table: "Reservas",
                column: "ReservaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservas_Usuarios_UsuarioId",
                table: "Reservas",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservas_Usuarios_UsuarioId",
                table: "Reservas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reservas",
                table: "Reservas");

            migrationBuilder.RenameTable(
                name: "Reservas",
                newName: "Reserva");

            migrationBuilder.RenameIndex(
                name: "IX_Reservas_UsuarioId",
                table: "Reserva",
                newName: "IX_Reserva_UsuarioId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reserva",
                table: "Reserva",
                column: "ReservaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reserva_Usuarios_UsuarioId",
                table: "Reserva",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
