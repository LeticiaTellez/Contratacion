using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Contratacion.Datos.Migrations
{
    public partial class AddUserColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CodigoConfirmacionCorreo",
                schema: "seguridad",
                table: "Usuarios",
                type: "nvarchar(20)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaEnvioCodigo",
                schema: "seguridad",
                table: "Usuarios",
                type: "datetime",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CodigoConfirmacionCorreo",
                schema: "seguridad",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "FechaEnvioCodigo",
                schema: "seguridad",
                table: "Usuarios");
        }
    }
}
