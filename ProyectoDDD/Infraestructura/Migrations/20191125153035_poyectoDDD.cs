using Microsoft.EntityFrameworkCore.Migrations;

namespace Infraestructura.Migrations
{
    public partial class poyectoDDD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductosVendidosPorCantidad");

            migrationBuilder.DropTable(
                name: "ProductosVendidosPorDinero");

            migrationBuilder.CreateTable(
                name: "ProductosVendidos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductoId = table.Column<int>(nullable: true),
                    CantidadVendida = table.Column<double>(nullable: false),
                    Dinero = table.Column<double>(nullable: false),
                    VentaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductosVendidos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductosVendidos_Producto_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Producto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductosVendidos_Venta_VentaId",
                        column: x => x.VentaId,
                        principalTable: "Venta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductosVendidos_ProductoId",
                table: "ProductosVendidos",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductosVendidos_VentaId",
                table: "ProductosVendidos",
                column: "VentaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductosVendidos");

            migrationBuilder.CreateTable(
                name: "ProductosVendidosPorCantidad",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CantidadVendida = table.Column<double>(type: "float", nullable: false),
                    ProductoId = table.Column<int>(type: "int", nullable: true),
                    VentaId = table.Column<int>(type: "int", nullable: true)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dinero = table.Column<double>(type: "float", nullable: false),
                    ProductoId = table.Column<int>(type: "int", nullable: true),
                    VentaId = table.Column<int>(type: "int", nullable: true)
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
        }
    }
}
