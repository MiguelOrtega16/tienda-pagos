using Microsoft.EntityFrameworkCore.Migrations;

namespace TiendaData.Migrations
{
    public partial class RegistrodeComprasv05 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RegistroPedidos_Clientes_ClienteId",
                table: "RegistroPedidos");

            migrationBuilder.DropIndex(
                name: "IX_RegistroPedidos_ClienteId",
                table: "RegistroPedidos");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "RegistroPedidos");

            migrationBuilder.AddColumn<int>(
                name: "Cedula",
                table: "RegistroPedidos",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cedula",
                table: "RegistroPedidos");

            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "RegistroPedidos",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RegistroPedidos_ClienteId",
                table: "RegistroPedidos",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_RegistroPedidos_Clientes_ClienteId",
                table: "RegistroPedidos",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
