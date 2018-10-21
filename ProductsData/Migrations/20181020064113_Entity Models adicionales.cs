using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TiendaData.Migrations
{
    public partial class EntityModelsadicionales : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdentificadorCompradorId",
                table: "Clientes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RegistroPedidosId",
                table: "Clientes",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Estados",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estados", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IdentificadorComprador",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TotalPagado = table.Column<int>(nullable: false),
                    PendientePorPagar = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentificadorComprador", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RegistroPedidos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdProducto = table.Column<int>(nullable: false),
                    CantidadProducto = table.Column<int>(nullable: false),
                    TotalPagado = table.Column<int>(nullable: false),
                    PendientePorPagar = table.Column<int>(nullable: false),
                    FechaNovedad = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistroPedidos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NombreProducto = table.Column<string>(nullable: false),
                    EstadosId = table.Column<int>(nullable: false),
                    Costo = table.Column<double>(nullable: false),
                    Capacidad = table.Column<decimal>(nullable: false),
                    CantidadProducto = table.Column<int>(nullable: false),
                    UrlImagen = table.Column<string>(nullable: true),
                    DescripcionProducto = table.Column<string>(nullable: false),
                    Color = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Productos_Estados_EstadosId",
                        column: x => x.EstadosId,
                        principalTable: "Estados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_IdentificadorCompradorId",
                table: "Clientes",
                column: "IdentificadorCompradorId");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_RegistroPedidosId",
                table: "Clientes",
                column: "RegistroPedidosId");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_EstadosId",
                table: "Productos",
                column: "EstadosId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_IdentificadorComprador_IdentificadorCompradorId",
                table: "Clientes",
                column: "IdentificadorCompradorId",
                principalTable: "IdentificadorComprador",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_RegistroPedidos_RegistroPedidosId",
                table: "Clientes",
                column: "RegistroPedidosId",
                principalTable: "RegistroPedidos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_IdentificadorComprador_IdentificadorCompradorId",
                table: "Clientes");

            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_RegistroPedidos_RegistroPedidosId",
                table: "Clientes");

            migrationBuilder.DropTable(
                name: "IdentificadorComprador");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "RegistroPedidos");

            migrationBuilder.DropTable(
                name: "Estados");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_IdentificadorCompradorId",
                table: "Clientes");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_RegistroPedidosId",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "IdentificadorCompradorId",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "RegistroPedidosId",
                table: "Clientes");
        }
    }
}
