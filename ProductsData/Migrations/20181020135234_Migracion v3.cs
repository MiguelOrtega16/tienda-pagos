using Microsoft.EntityFrameworkCore.Migrations;

namespace TiendaData.Migrations
{
    public partial class Migracionv3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_RegistroPedidos_RegistroPedidosId",
                table: "Clientes");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_RegistroPedidosId",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "RegistroPedidosId",
                table: "Clientes");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "RegistroPedidosId",
                table: "Clientes",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_RegistroPedidosId",
                table: "Clientes",
                column: "RegistroPedidosId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_RegistroPedidos_RegistroPedidosId",
                table: "Clientes",
                column: "RegistroPedidosId",
                principalTable: "RegistroPedidos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
