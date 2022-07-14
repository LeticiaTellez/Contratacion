using Microsoft.EntityFrameworkCore.Migrations;

namespace Contratacion.Datos.Migrations
{
    public partial class ChangeTypeFloatParametrosConfiguracion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "ValorNumerico",
                schema: "seguridad",
                table: "ParametrosConfiguracion",
                type: "float",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "ValorNumerico",
                schema: "seguridad",
                table: "ParametrosConfiguracion",
                type: "real",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);
        }
    }
}
