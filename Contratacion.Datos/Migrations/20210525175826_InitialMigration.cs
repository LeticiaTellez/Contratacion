using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Contratacion.Datos.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "seguridad");

            migrationBuilder.CreateTable(
                name: "Roles",
                schema: "seguridad",
                columns: table => new
                {
                    IdRol = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreRol = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    NombreRolNormalizado = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    MomentoConcurrencia = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.IdRol);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                schema: "seguridad",
                columns: table => new
                {
                    IdUsuario = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCompleto = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    UltimaActualizacionClave = table.Column<DateTime>(type: "datetime", nullable: false),
                    Usuario = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    UsuarioNormalizado = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Correo = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    CorreoNormalizado = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    CorreoConfirmado = table.Column<bool>(type: "bit", nullable: false),
                    ClaveHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SelloSeguridad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelefonoConfirmado = table.Column<bool>(type: "bit", nullable: false),
                    DosFactores = table.Column<bool>(type: "bit", nullable: false),
                    BloquearHasta = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    HabilitarBloquedo = table.Column<bool>(type: "bit", nullable: false),
                    CantidadErroresAcceso = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.IdUsuario);
                });

            migrationBuilder.CreateTable(
                name: "ReclamacionRoles",
                schema: "seguridad",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdRol = table.Column<long>(type: "bigint", nullable: false),
                    TipoReclamacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValorReclamacion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReclamacionRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReclamacionRoles_Roles_IdRol",
                        column: x => x.IdRol,
                        principalSchema: "seguridad",
                        principalTable: "Roles",
                        principalColumn: "IdRol",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InicioSesionUsuarios",
                schema: "seguridad",
                columns: table => new
                {
                    InicioSesionProvedor = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaveProveedor = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NombreProveedor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdUsuario = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InicioSesionUsuarios", x => new { x.InicioSesionProvedor, x.ClaveProveedor });
                    table.ForeignKey(
                        name: "FK_InicioSesionUsuarios_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalSchema: "seguridad",
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReclamacionesUsuario",
                schema: "seguridad",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUsuario = table.Column<long>(type: "bigint", nullable: false),
                    TipoReclamacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValorReclamacion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReclamacionesUsuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReclamacionesUsuario_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalSchema: "seguridad",
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RolesUsuarios",
                schema: "seguridad",
                columns: table => new
                {
                    IdUsuario = table.Column<long>(type: "bigint", nullable: false),
                    IdRol = table.Column<long>(type: "bigint", nullable: false),
                    IdEmpresa = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolesUsuarios", x => new { x.IdUsuario, x.IdRol });
                    table.ForeignKey(
                        name: "FK_RolesUsuarios_Roles_IdRol",
                        column: x => x.IdRol,
                        principalSchema: "seguridad",
                        principalTable: "Roles",
                        principalColumn: "IdRol",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolesUsuarios_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalSchema: "seguridad",
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TokenUsuario",
                schema: "seguridad",
                columns: table => new
                {
                    IdUsuario = table.Column<long>(type: "bigint", nullable: false),
                    InicioSesionProveedor = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Valor = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TokenUsuario", x => new { x.IdUsuario, x.InicioSesionProveedor, x.Nombre });
                    table.ForeignKey(
                        name: "FK_TokenUsuario_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalSchema: "seguridad",
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InicioSesionUsuarios_IdUsuario",
                schema: "seguridad",
                table: "InicioSesionUsuarios",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_ReclamacionesUsuario_IdUsuario",
                schema: "seguridad",
                table: "ReclamacionesUsuario",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_ReclamacionRoles_IdRol",
                schema: "seguridad",
                table: "ReclamacionRoles",
                column: "IdRol");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "seguridad",
                table: "Roles",
                column: "NombreRolNormalizado",
                unique: true,
                filter: "[NombreRolNormalizado] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RolesUsuarios_IdRol",
                schema: "seguridad",
                table: "RolesUsuarios",
                column: "IdRol");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "seguridad",
                table: "Usuarios",
                column: "CorreoNormalizado");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "seguridad",
                table: "Usuarios",
                column: "UsuarioNormalizado",
                unique: true,
                filter: "[UsuarioNormalizado] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InicioSesionUsuarios",
                schema: "seguridad");

            migrationBuilder.DropTable(
                name: "ReclamacionesUsuario",
                schema: "seguridad");

            migrationBuilder.DropTable(
                name: "ReclamacionRoles",
                schema: "seguridad");

            migrationBuilder.DropTable(
                name: "RolesUsuarios",
                schema: "seguridad");

            migrationBuilder.DropTable(
                name: "TokenUsuario",
                schema: "seguridad");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "seguridad");

            migrationBuilder.DropTable(
                name: "Usuarios",
                schema: "seguridad");
        }
    }
}
