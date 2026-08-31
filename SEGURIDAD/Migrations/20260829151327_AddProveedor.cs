using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SEGURIDAD.Migrations
{
    /// <inheritdoc />
    public partial class AddProveedor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PROVEEDOR",
                columns: table => new
                {
                    ID_PROVEEDOR = table.Column<Guid>(type: "uuid", nullable: false),
                    CODIGO = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    DESCRIPCION = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    COMENTARIO = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    USUARIO_CONACTO_ID = table.Column<Guid>(type: "uuid", nullable: true),
                    ESTADO = table.Column<bool>(type: "boolean", nullable: false),
                    FECHA_REGISTRO = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    USUARIO_REGISTRO = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    IPV4_REGISTRO = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: true),
                    IPV6_REGISTRO = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: true),
                    FECHA_MODIFICACION = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    USUARIO_MODIFICACION = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    IPV4_MODIFICACION = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: true),
                    IPV6_MODIFICACION = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PROVEEDOR", x => x.ID_PROVEEDOR);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PROVEEDOR");
        }
    }
}
