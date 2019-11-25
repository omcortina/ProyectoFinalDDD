using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infraestructura.Migrations
{
    public partial class migration5proyecto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrecioBulto",
                table: "Producto");

            migrationBuilder.DropColumn(
                name: "PrecioKilo",
                table: "Producto");

            migrationBuilder.AddColumn<double>(
                name: "PrecioCompra",
                table: "Producto",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "PrecioVenta",
                table: "Producto",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "TiposDeVentaPorProducto",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    ProductoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposDeVentaPorProducto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TiposDeVentaPorProducto_Producto_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Producto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Venta",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(nullable: true),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Total = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venta", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductosVendidosPorCantidad",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductoId = table.Column<int>(nullable: true),
                    CantidadVendida = table.Column<double>(nullable: false),
                    VentaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductosVendidosPorCantidad", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductosVendidosPorCantidad_Producto_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Producto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductosVendidosPorCantidad_Venta_VentaId",
                        column: x => x.VentaId,
                        principalTable: "Venta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductosVendidosPorDinero",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductoId = table.Column<int>(nullable: true),
                    Dinero = table.Column<double>(nullable: false),
                    VentaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductosVendidosPorDinero", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductosVendidosPorDinero_Producto_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Producto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductosVendidosPorDinero_Venta_VentaId",
                        column: x => x.VentaId,
                        principalTable: "Venta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductosVendidosPorCantidad_ProductoId",
                table: "ProductosVendidosPorCantidad",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductosVendidosPorCantidad_VentaId",
                table: "ProductosVendidosPorCantidad",
                column: "VentaId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductosVendidosPorDinero_ProductoId",
                table: "ProductosVendidosPorDinero",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductosVendidosPorDinero_VentaId",
                table: "ProductosVendidosPorDinero",
                column: "VentaId");

            migrationBuilder.CreateIndex(
                name: "IX_TiposDeVentaPorProducto_ProductoId",
                table: "TiposDeVentaPorProducto",
                column: "ProductoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductosVendidosPorCantidad");

            migrationBuilder.DropTable(
                name: "ProductosVendidosPorDinero");

            migrationBuilder.DropTable(
                name: "TiposDeVentaPorProducto");

            migrationBuilder.DropTable(
                name: "Venta");

            migrationBuilder.DropColumn(
                name: "PrecioCompra",
                table: "Producto");

            migrationBuilder.DropColumn(
                name: "PrecioVenta",
                table: "Producto");

            migrationBuilder.AddColumn<double>(
                name: "PrecioBulto",
                table: "Producto",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "PrecioKilo",
                table: "Producto",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
