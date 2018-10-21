using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TiendaData.Migrations
{
    public partial class TrazaMemeRegistrodeCompras : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EstadosPedidosId",
                table: "RegistroPedidos",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RegistroPedidosDetalleId",
                table: "RegistroPedidos",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ValorTotalCompra",
                table: "RegistroPedidos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "EstadosPedidos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadosPedidos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RegistroPedidosDetalle",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdRegistroPedido = table.Column<int>(nullable: false),
                    TotalPagado = table.Column<double>(nullable: false),
                    PendientePorPagar = table.Column<double>(nullable: false),
                    FechaNovedad = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistroPedidosDetalle", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RegistroPedidos_EstadosPedidosId",
                table: "RegistroPedidos",
                column: "EstadosPedidosId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistroPedidos_RegistroPedidosDetalleId",
                table: "RegistroPedidos",
                column: "RegistroPedidosDetalleId");

            migrationBuilder.AddForeignKey(
                name: "FK_RegistroPedidos_EstadosPedidos_EstadosPedidosId",
                table: "RegistroPedidos",
                column: "EstadosPedidosId",
                principalTable: "EstadosPedidos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RegistroPedidos_RegistroPedidosDetalle_RegistroPedidosDetalleId",
                table: "RegistroPedidos",
                column: "RegistroPedidosDetalleId",
                principalTable: "RegistroPedidosDetalle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RegistroPedidos_EstadosPedidos_EstadosPedidosId",
                table: "RegistroPedidos");

            migrationBuilder.DropForeignKey(
                name: "FK_RegistroPedidos_RegistroPedidosDetalle_RegistroPedidosDetalleId",
                table: "RegistroPedidos");

            migrationBuilder.DropTable(
                name: "EstadosPedidos");

            migrationBuilder.DropTable(
                name: "RegistroPedidosDetalle");

            migrationBuilder.DropIndex(
                name: "IX_RegistroPedidos_EstadosPedidosId",
                table: "RegistroPedidos");

            migrationBuilder.DropIndex(
                name: "IX_RegistroPedidos_RegistroPedidosDetalleId",
                table: "RegistroPedidos");

            migrationBuilder.DropColumn(
                name: "EstadosPedidosId",
                table: "RegistroPedidos");

            migrationBuilder.DropColumn(
                name: "RegistroPedidosDetalleId",
                table: "RegistroPedidos");

            migrationBuilder.DropColumn(
                name: "ValorTotalCompra",
                table: "RegistroPedidos");
        }
    }
}
