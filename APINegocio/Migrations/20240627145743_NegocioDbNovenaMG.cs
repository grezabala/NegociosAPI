﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APINegocio.Migrations
{
    /// <inheritdoc />
    public partial class NegocioDbNovenaMG : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inventory");

            migrationBuilder.AddColumn<string>(
                name: "CodeStore",
                table: "Stores",
                type: "varchar(30)",
                unicode: false,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Stock",
                table: "Stores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Inventorios",
                columns: table => new
                {
                    InventoryId = table.Column<int>(type: "int", unicode: false, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InventoryName = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    Stock = table.Column<int>(type: "int", unicode: false, nullable: false),
                    DescrictionInventory = table.Column<string>(type: "varchar(550)", unicode: false, maxLength: 550, nullable: false),
                    ReferenceInventory = table.Column<string>(type: "varchar(550)", unicode: false, maxLength: 550, nullable: false),
                    NumberInventory = table.Column<int>(type: "int", unicode: false, nullable: false),
                    CodigoInventory = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    DateCread = table.Column<DateTime>(type: "datetime2", unicode: false, nullable: true),
                    //StorId = table.Column<int>(type: "int", unicode: false, nullable: false),
                    ShoppingId = table.Column<int>(type: "int", unicode: false, nullable: false),
                    ProductoId = table.Column<int>(type: "int", unicode: false, nullable: false),
                    ProveedorId = table.Column<int>(type: "int", unicode: false, nullable: false),
                    IsDateCread = table.Column<DateTime>(type: "datetime2", unicode: false, nullable: true),
                    IsShipped = table.Column<bool>(type: "bit", unicode: false, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", unicode: false, nullable: false),
                    IsDeletedAt = table.Column<DateTime>(type: "datetime2", unicode: false, nullable: true),
                    IsUpdated = table.Column<bool>(type: "bit", unicode: false, nullable: false),
                    IsStatus = table.Column<bool>(type: "bit", unicode: false, nullable: false),
                    IsUpdatedAt = table.Column<DateTime>(type: "datetime2", unicode: false, nullable: true),
                    ProveedoresProveedorId = table.Column<int>(type: "int", nullable: true),
                    ProveedosProductId = table.Column<int>(type: "int", nullable: true),
                    StorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventorios", x => x.InventoryId);
                    table.ForeignKey(
                        name: "FK_Inventorios_Productos_ProveedosProductId",
                        column: x => x.ProveedosProductId,
                        principalTable: "Productos",
                        principalColumn: "ProductId");
                    table.ForeignKey(
                        name: "FK_Inventorios_Proveedores_ProveedoresProveedorId",
                        column: x => x.ProveedoresProveedorId,
                        principalTable: "Proveedores",
                        principalColumn: "ProveedorId");
                    table.ForeignKey(
                        name: "FK_Inventorios_Shopping_ShoppingId",
                        column: x => x.ShoppingId,
                        principalTable: "Shopping",
                        principalColumn: "ShoppingId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inventorios_Stores_StoresStorId",
                        column: x => x.StorId,
                        principalTable: "Stores",
                        principalColumn: "StorId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inventorios_ProveedoresProveedorId",
                table: "Inventorios",
                column: "ProveedoresProveedorId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventorios_ProveedosProductId",
                table: "Inventorios",
                column: "ProveedosProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventorios_ShoppingId",
                table: "Inventorios",
                column: "ShoppingId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventorios_StoresStorId",
                table: "Inventorios",
                column: "StorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inventorios");

            migrationBuilder.DropColumn(
                name: "CodeStore",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "Stock",
                table: "Stores");

            migrationBuilder.CreateTable(
                name: "Inventory",
                columns: table => new
                {
                    InventoryId = table.Column<int>(type: "int", unicode: false, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProveedoresProveedorId = table.Column<int>(type: "int", nullable: true),
                    ProveedosProductId = table.Column<int>(type: "int", nullable: true),
                    ShoppingId = table.Column<int>(type: "int", unicode: false, nullable: false),
                    StoresStorId = table.Column<int>(type: "int", nullable: true),
                    CodigoInventory = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    DateCread = table.Column<DateTime>(type: "datetime2", unicode: false, nullable: true),
                    DescrictionInventory = table.Column<string>(type: "varchar(550)", unicode: false, maxLength: 550, nullable: false),
                    InventoryName = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    IsDateCread = table.Column<DateTime>(type: "datetime2", unicode: false, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", unicode: false, nullable: false),
                    IsDeletedAt = table.Column<DateTime>(type: "datetime2", unicode: false, nullable: true),
                    IsShipped = table.Column<bool>(type: "bit", unicode: false, nullable: false),
                    IsStatus = table.Column<bool>(type: "bit", unicode: false, nullable: false),
                    IsUpdated = table.Column<bool>(type: "bit", unicode: false, nullable: false),
                    IsUpdatedAt = table.Column<DateTime>(type: "datetime2", unicode: false, nullable: true),
                    NumberInventory = table.Column<int>(type: "int", unicode: false, nullable: false),
                    ProductoId = table.Column<int>(type: "int", unicode: false, nullable: false),
                    ProveedorId = table.Column<int>(type: "int", unicode: false, nullable: false),
                    ReferenceInventory = table.Column<string>(type: "varchar(550)", unicode: false, maxLength: 550, nullable: false),
                    Stock = table.Column<int>(type: "int", unicode: false, nullable: false),
                    StorId = table.Column<int>(type: "int", unicode: false, nullable: false)
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
                    table.ForeignKey(
                        name: "FK_Inventory_Stores_StoresStorId",
                        column: x => x.StoresStorId,
                        principalTable: "Stores",
                        principalColumn: "StorId");
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
                name: "IX_Inventory_StoresStorId",
                table: "Inventory",
                column: "StoresStorId");
        }
    }
}
