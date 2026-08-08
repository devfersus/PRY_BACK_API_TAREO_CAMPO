using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SEGURIDAD.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ACCION",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Descripcion = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Activo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ACCION", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MODULO",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Descripcion = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Activo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MODULO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PERMISO",
                columns: table => new
                {
                    permiso_id = table.Column<Guid>(type: "uuid", nullable: false),
                    descripcion = table.Column<string>(type: "text", nullable: false),
                    activo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PERMISO", x => x.permiso_id);
                });

            migrationBuilder.CreateTable(
                name: "SUB_MODULO",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Descripcion = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Activo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SUB_MODULO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "USUARIO",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nombre = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: false),
                    ApellidoMaterno = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: false),
                    ApellidoPaterno = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: false),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    Contraseña = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: false),
                    Activo = table.Column<bool>(type: "boolean", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USUARIO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ACCION_SUB_MODULO",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SubModuloId = table.Column<Guid>(type: "uuid", nullable: false),
                    AccionId = table.Column<Guid>(type: "uuid", nullable: false),
                    Activo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ACCION_SUB_MODULO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ACCION_SUB_MODULO_ACCION_AccionId",
                        column: x => x.AccionId,
                        principalTable: "ACCION",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ACCION_SUB_MODULO_SUB_MODULO_SubModuloId",
                        column: x => x.SubModuloId,
                        principalTable: "SUB_MODULO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PERMISO_DETALLE",
                columns: table => new
                {
                    permiso_detalle_id = table.Column<Guid>(type: "uuid", nullable: false),
                    permiso_id = table.Column<Guid>(type: "uuid", nullable: false),
                    modulo_id = table.Column<Guid>(type: "uuid", nullable: false),
                    sub_modulo_id = table.Column<Guid>(type: "uuid", nullable: false),
                    accion_id = table.Column<Guid>(type: "uuid", nullable: false),
                    activo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PERMISO_DETALLE", x => x.permiso_detalle_id);
                    table.ForeignKey(
                        name: "FK_PERMISO_DETALLE_ACCION_accion_id",
                        column: x => x.accion_id,
                        principalTable: "ACCION",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PERMISO_DETALLE_MODULO_modulo_id",
                        column: x => x.modulo_id,
                        principalTable: "MODULO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PERMISO_DETALLE_PERMISO_permiso_id",
                        column: x => x.permiso_id,
                        principalTable: "PERMISO",
                        principalColumn: "permiso_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PERMISO_DETALLE_SUB_MODULO_sub_modulo_id",
                        column: x => x.sub_modulo_id,
                        principalTable: "SUB_MODULO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ACCION_SUB_MODULO_AccionId",
                table: "ACCION_SUB_MODULO",
                column: "AccionId");

            migrationBuilder.CreateIndex(
                name: "IX_ACCION_SUB_MODULO_SubModuloId",
                table: "ACCION_SUB_MODULO",
                column: "SubModuloId");

            migrationBuilder.CreateIndex(
                name: "IX_PERMISO_DETALLE_accion_id",
                table: "PERMISO_DETALLE",
                column: "accion_id");

            migrationBuilder.CreateIndex(
                name: "IX_PERMISO_DETALLE_modulo_id",
                table: "PERMISO_DETALLE",
                column: "modulo_id");

            migrationBuilder.CreateIndex(
                name: "IX_PERMISO_DETALLE_permiso_id",
                table: "PERMISO_DETALLE",
                column: "permiso_id");

            migrationBuilder.CreateIndex(
                name: "IX_PERMISO_DETALLE_sub_modulo_id",
                table: "PERMISO_DETALLE",
                column: "sub_modulo_id");

            migrationBuilder.CreateIndex(
                name: "IX_USUARIO_Email",
                table: "USUARIO",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ACCION_SUB_MODULO");

            migrationBuilder.DropTable(
                name: "PERMISO_DETALLE");

            migrationBuilder.DropTable(
                name: "USUARIO");

            migrationBuilder.DropTable(
                name: "ACCION");

            migrationBuilder.DropTable(
                name: "MODULO");

            migrationBuilder.DropTable(
                name: "PERMISO");

            migrationBuilder.DropTable(
                name: "SUB_MODULO");
        }
    }
}
