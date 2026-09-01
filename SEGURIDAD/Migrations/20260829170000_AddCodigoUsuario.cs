using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SEGURIDAD.Migrations
{
    /// <inheritdoc />
    public partial class AddCodigoUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Codigo",
                table: "USUARIO",
                type: "character varying(10)",
                maxLength: 10,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Codigo",
                table: "USUARIO");
        }
    }
}
