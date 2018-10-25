using Microsoft.EntityFrameworkCore.Migrations;

namespace TiendaData.Migrations
{
    public partial class RegistrodeComprasv03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RegistroPedidos_RegistroPedidosDetalle_RegistroPedidosDetalleId",
                table: "RegistroPedidos");

            migrationBuilder.DropIndex(
                name: "IX_RegistroPedidos_RegistroPedidosDetalleId",
                table: "RegistroPedidos");

            migrationBuilder.DropColumn(
                name: "RegistroPedidosDetalleId",
                table: "RegistroPedidos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RegistroPedidosDetalleId",
                table: "RegistroPedidos",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RegistroPedidos_RegistroPedidosDetalleId",
                table: "RegistroPedidos",
                column: "RegistroPedidosDetalleId");

            migrationBuilder.AddForeignKey(
                name: "FK_RegistroPedidos_RegistroPedidosDetalle_RegistroPedidosDetalleId",
                table: "RegistroPedidos",
                column: "RegistroPedidosDetalleId",
                principalTable: "RegistroPedidosDetalle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
