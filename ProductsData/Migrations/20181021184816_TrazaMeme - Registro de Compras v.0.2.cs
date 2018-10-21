using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TiendaData.Migrations
{
    public partial class TrazaMemeRegistrodeComprasv02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_IdentificadorComprador_IdentificadorCompradorId",
                table: "Clientes");

            migrationBuilder.DropTable(
                name: "IdentificadorComprador");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_IdentificadorCompradorId",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "IdentificadorCompradorId",
                table: "Clientes");

            migrationBuilder.AddColumn<int>(
                name: "Cedula",
                table: "Clientes",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cedula",
                table: "Clientes");

            migrationBuilder.AddColumn<int>(
                name: "IdentificadorCompradorId",
                table: "Clientes",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "IdentificadorComprador",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PendientePorPagar = table.Column<int>(nullable: false),
                    TotalPagado = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentificadorComprador", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_IdentificadorCompradorId",
                table: "Clientes",
                column: "IdentificadorCompradorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_IdentificadorComprador_IdentificadorCompradorId",
                table: "Clientes",
                column: "IdentificadorCompradorId",
                principalTable: "IdentificadorComprador",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
