using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIToyKids.Migrations
{
    /// <inheritdoc />
    public partial class PopulaUsuarios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("Insert into Usuarios(Nome, CPF, Email, Senha) Values('Rafael Villaça', '19914461794', 'rafaelvillaca2020@gmail.com', 'qafecv12345')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("Delete from Usuarios");
        }
    }
}
