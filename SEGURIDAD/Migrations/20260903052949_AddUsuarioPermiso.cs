using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SEGURIDAD.Migrations
{
    /// <inheritdoc />
    public partial class AddUsuarioPermiso : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "USUARIO_CONACTO_ID",
                table: "PROVEEDOR");

            migrationBuilder.RenameColumn(
                name: "USUARIO_REGISTRO",
                table: "PROVEEDOR",
                newName: "usuario_registro");

            migrationBuilder.RenameColumn(
                name: "USUARIO_MODIFICACION",
                table: "PROVEEDOR",
                newName: "usuario_modificacion");

            migrationBuilder.RenameColumn(
                name: "IPV6_REGISTRO",
                table: "PROVEEDOR",
                newName: "ipv6_registro");

            migrationBuilder.RenameColumn(
                name: "IPV6_MODIFICACION",
                table: "PROVEEDOR",
                newName: "ipv6_modificacion");

            migrationBuilder.RenameColumn(
                name: "IPV4_REGISTRO",
                table: "PROVEEDOR",
                newName: "ipv4_registro");

            migrationBuilder.RenameColumn(
                name: "IPV4_MODIFICACION",
                table: "PROVEEDOR",
                newName: "ipv4_modificacion");

            migrationBuilder.RenameColumn(
                name: "FECHA_REGISTRO",
                table: "PROVEEDOR",
                newName: "fecha_registro");

            migrationBuilder.RenameColumn(
                name: "FECHA_MODIFICACION",
                table: "PROVEEDOR",
                newName: "fecha_modificacion");

            migrationBuilder.RenameColumn(
                name: "ESTADO",
                table: "PROVEEDOR",
                newName: "estado");

            migrationBuilder.RenameColumn(
                name: "DESCRIPCION",
                table: "PROVEEDOR",
                newName: "descripcion");

            migrationBuilder.RenameColumn(
                name: "COMENTARIO",
                table: "PROVEEDOR",
                newName: "comentario");

            migrationBuilder.RenameColumn(
                name: "CODIGO",
                table: "PROVEEDOR",
                newName: "codigo");

            migrationBuilder.RenameColumn(
                name: "ID_PROVEEDOR",
                table: "PROVEEDOR",
                newName: "id_proveedor");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaModificacion",
                table: "USUARIO",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaCreacion",
                table: "USUARIO",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddColumn<string>(
                name: "codigo_usuario",
                table: "PROVEEDOR",
                type: "character varying(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "USUARIO_PERMISO",
                columns: table => new
                {
                    usuario_permiso_id = table.Column<Guid>(type: "uuid", nullable: false),
                    usuario_id = table.Column<Guid>(type: "uuid", nullable: false),
                    permiso_id = table.Column<Guid>(type: "uuid", nullable: false),
                    activo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USUARIO_PERMISO", x => x.usuario_permiso_id);
                    table.ForeignKey(
                        name: "FK_USUARIO_PERMISO_PERMISO_permiso_id",
                        column: x => x.permiso_id,
                        principalTable: "PERMISO",
                        principalColumn: "permiso_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_USUARIO_PERMISO_USUARIO_usuario_id",
                        column: x => x.usuario_id,
                        principalTable: "USUARIO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_USUARIO_PERMISO_permiso_id",
                table: "USUARIO_PERMISO",
                column: "permiso_id");

            migrationBuilder.CreateIndex(
                name: "UX_USUARIO_PERMISO_usuario_permiso",
                table: "USUARIO_PERMISO",
                columns: new[] { "usuario_id", "permiso_id" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "USUARIO_PERMISO");

            migrationBuilder.DropColumn(
                name: "codigo_usuario",
                table: "PROVEEDOR");

            migrationBuilder.RenameColumn(
                name: "usuario_registro",
                table: "PROVEEDOR",
                newName: "USUARIO_REGISTRO");

            migrationBuilder.RenameColumn(
                name: "usuario_modificacion",
                table: "PROVEEDOR",
                newName: "USUARIO_MODIFICACION");

            migrationBuilder.RenameColumn(
                name: "ipv6_registro",
                table: "PROVEEDOR",
                newName: "IPV6_REGISTRO");

            migrationBuilder.RenameColumn(
                name: "ipv6_modificacion",
                table: "PROVEEDOR",
                newName: "IPV6_MODIFICACION");

            migrationBuilder.RenameColumn(
                name: "ipv4_registro",
                table: "PROVEEDOR",
                newName: "IPV4_REGISTRO");

            migrationBuilder.RenameColumn(
                name: "ipv4_modificacion",
                table: "PROVEEDOR",
                newName: "IPV4_MODIFICACION");

            migrationBuilder.RenameColumn(
                name: "fecha_registro",
                table: "PROVEEDOR",
                newName: "FECHA_REGISTRO");

            migrationBuilder.RenameColumn(
                name: "fecha_modificacion",
                table: "PROVEEDOR",
                newName: "FECHA_MODIFICACION");

            migrationBuilder.RenameColumn(
                name: "estado",
                table: "PROVEEDOR",
                newName: "ESTADO");

            migrationBuilder.RenameColumn(
                name: "descripcion",
                table: "PROVEEDOR",
                newName: "DESCRIPCION");

            migrationBuilder.RenameColumn(
                name: "comentario",
                table: "PROVEEDOR",
                newName: "COMENTARIO");

            migrationBuilder.RenameColumn(
                name: "codigo",
                table: "PROVEEDOR",
                newName: "CODIGO");

            migrationBuilder.RenameColumn(
                name: "id_proveedor",
                table: "PROVEEDOR",
                newName: "ID_PROVEEDOR");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaModificacion",
                table: "USUARIO",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaCreacion",
                table: "USUARIO",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AddColumn<Guid>(
                name: "USUARIO_CONACTO_ID",
                table: "PROVEEDOR",
                type: "uuid",
                nullable: true);
        }
    }
}
