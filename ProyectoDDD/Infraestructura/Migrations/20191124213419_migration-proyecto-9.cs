using Microsoft.EntityFrameworkCore.Migrations;

namespace Infraestructura.Migrations
{
    public partial class migrationproyecto9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TiposDeVenta_Producto_ProductoId",
                table: "TiposDeVenta");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TiposDeVenta",
                table: "TiposDeVenta");

            migrationBuilder.RenameTable(
                name: "TiposDeVenta",
                newName: "TipoDeVenta");

            migrationBuilder.RenameIndex(
                name: "IX_TiposDeVenta_ProductoId",
                table: "TipoDeVenta",
                newName: "IX_TipoDeVenta_ProductoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TipoDeVenta",
                table: "TipoDeVenta",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TipoDeVenta_Producto_ProductoId",
                table: "TipoDeVenta",
                column: "ProductoId",
                principalTable: "Producto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TipoDeVenta_Producto_ProductoId",
                table: "TipoDeVenta");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TipoDeVenta",
                table: "TipoDeVenta");

            migrationBuilder.RenameTable(
                name: "TipoDeVenta",
                newName: "TiposDeVenta");

            migrationBuilder.RenameIndex(
                name: "IX_TipoDeVenta_ProductoId",
                table: "TiposDeVenta",
                newName: "IX_TiposDeVenta_ProductoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TiposDeVenta",
                table: "TiposDeVenta",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TiposDeVenta_Producto_ProductoId",
                table: "TiposDeVenta",
                column: "ProductoId",
                principalTable: "Producto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
