using Microsoft.EntityFrameworkCore.Migrations;

namespace TiendaData.Migrations
{
    public partial class RegistrodeComprasv04 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RegistroPedidos_EstadosPedidos_EstadosPedidosId",
                table: "RegistroPedidos");

            migrationBuilder.DropIndex(
                name: "IX_RegistroPedidos_EstadosPedidosId",
                table: "RegistroPedidos");

            migrationBuilder.DropColumn(
                name: "EstadosPedidosId",
                table: "RegistroPedidos");

            migrationBuilder.AddColumn<int>(
                name: "IdEstado",
                table: "RegistroPedidos",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdEstado",
                table: "RegistroPedidos");

            migrationBuilder.AddColumn<int>(
                name: "EstadosPedidosId",
                table: "RegistroPedidos",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RegistroPedidos_EstadosPedidosId",
                table: "RegistroPedidos",
                column: "EstadosPedidosId");

            migrationBuilder.AddForeignKey(
                name: "FK_RegistroPedidos_EstadosPedidos_EstadosPedidosId",
                table: "RegistroPedidos",
                column: "EstadosPedidosId",
                principalTable: "EstadosPedidos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
