using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APINegocio.Migrations
{
    /// <inheritdoc />
    public partial class NuevaNegocioDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Inventory",
                columns: table => new
                {
                    InventoryId = table.Column<int>(type: "int", unicode: false, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InventoryName = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    DescrictionInventory = table.Column<string>(type: "varchar(550)", unicode: false, maxLength: 550, nullable: false),
                    ReferenceInventory = table.Column<string>(type: "varchar(550)", unicode: false, maxLength: 550, nullable: false),
                    NumberInventory = table.Column<int>(type: "int", unicode: false, nullable: false),
                    CodigoInventory = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    DateCread = table.Column<DateTime>(type: "datetime2", unicode: false, nullable: false),
                    //StoreId = table.Column<int>(type: "int", unicode: false, nullable: false),
                    ShoppingId = table.Column<int>(type: "int", unicode: false, nullable: false),
                    ProductoId = table.Column<int>(type: "int", unicode: false, nullable: false),
                    ProveedorId = table.Column<int>(type: "int", unicode: false, nullable: false),
                    IsDateCread = table.Column<DateTime>(type: "datetime2", unicode: false, nullable: false),
                    IsShipped = table.Column<bool>(type: "bit", unicode: false, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", unicode: false, nullable: false),
                    IsDeletedAt = table.Column<DateTime>(type: "datetime2", unicode: false, nullable: false),
                    IsUpdated = table.Column<bool>(type: "bit", unicode: false, nullable: false),
                    IsUpdatedAt = table.Column<DateTime>(type: "datetime2", unicode: false, nullable: false),
                    ProveedoresProveedorId = table.Column<int>(type: "int", nullable: true),
                    ProveedosProductId = table.Column<int>(type: "int", nullable: true),
                    StorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory", x => x.InventoryId);
                    table.ForeignKey(
                        name: "FK_Inventory_Productos_ProveedosProductId",
                        column: x => x.ProveedosProductId,
                        principalTable: "Productos",
                        principalColumn: "ProductId");
                    table.ForeignKey(
                        name: "FK_Inventory_Proveedores_ProveedoresProveedorId",
                        column: x => x.ProveedoresProveedorId,
                        principalTable: "Proveedores",
                        principalColumn: "ProveedorId");
                    table.ForeignKey(
                        name: "FK_Inventory_Shopping_ShoppingId",
                        column: x => x.ShoppingId,
                        principalTable: "Shopping",
                        principalColumn: "ShoppingId",
                        onDelete: ReferentialAction.Cascade);
                    //table.ForeignKey(
                    //    name: "FK_Inventory_Stores_StoresId",
                    //    column: x => x.StorId,
                    //    principalTable: "Stores",
                    //    //principalColumn: "StoresId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_ProveedoresProveedorId",
                table: "Inventory",
                column: "ProveedoresProveedorId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_ProveedosProductId",
                table: "Inventory",
                column: "ProveedosProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_ShoppingId",
                table: "Inventory",
                column: "ShoppingId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_StoresId",
                table: "Inventory",
                column: "StoresId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inventory");
        }
    }
}
