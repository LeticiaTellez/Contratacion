using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Contratacion.Datos.Migrations
{
    public partial class AddingParametrosConfiguracionTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ParametrosConfiguracion",
                schema: "seguridad",
                columns: table => new
                {
                    IdParametro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreParametro = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    Alias = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    ValorNumerico = table.Column<float>(type: "real", nullable: true),
                    ValorFecha = table.Column<DateTime>(type: "datetime", nullable: true),
                    ValorTexto = table.Column<string>(type: "nvarchar(800)", nullable: true),
                    NombreCategoria = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParametrosConfiguracion", x => x.IdParametro);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParametrosConfiguracion",
                schema: "seguridad");
        }
    }
}
