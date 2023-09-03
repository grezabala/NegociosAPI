using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APINegocio.Migrations
{
    /// <inheritdoc />
    public partial class InitialMNegocioDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", unicode: false, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    Description = table.Column<string>(type: "varchar(550)", unicode: false, maxLength: 550, nullable: false),
                    Referencia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "Decimal(18,2)", unicode: false, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", unicode: false, nullable: false),
                    IsAsset = table.Column<bool>(type: "bit", unicode: false, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", unicode: false, nullable: false),
                    IsApproved = table.Column<bool>(type: "bit", unicode: false, nullable: false),
                    IsDateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsModified = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "Proveedores",
                columns: table => new
                {
                    ProveedorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProveedorName = table.Column<string>(type: "varchar(550)", unicode: false, maxLength: 550, nullable: false),
                    ProveedorDescription = table.Column<string>(type: "varchar(550)", unicode: false, maxLength: 550, nullable: false),
                    ProveedorDirection = table.Column<string>(type: "varchar(550)", unicode: false, maxLength: 550, nullable: false),
                    ProveedorReference = table.Column<string>(type: "varchar(550)", unicode: false, maxLength: 550, nullable: false),
                    ProveedorCode = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", unicode: false, nullable: false),
                    CreadProveedor = table.Column<DateTime>(type: "datetime2", unicode: false, nullable: false),
                    IsModified = table.Column<bool>(type: "bit", unicode: false, nullable: false),
                    IsDateModified = table.Column<DateTime>(type: "datetime2", unicode: false, nullable: false),
                    IsAsset = table.Column<bool>(type: "bit", unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedores", x => x.ProveedorId);
                });

            migrationBuilder.CreateTable(
                name: "Shopping",
                columns: table => new
                {
                    ShoppingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ShoppingName = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    ShoppingDescription = table.Column<string>(type: "varchar(550)", unicode: false, maxLength: 550, nullable: false),
                    ShoppingStatus = table.Column<int>(type: "INT", unicode: false, nullable: false),
                    ShoppingCount = table.Column<int>(type: "INT", unicode: false, nullable: false),
                    ShoppingTitle = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    ShoppingCode = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    NumberShopping = table.Column<int>(type: "INT", unicode: false, nullable: false),
                    IsShoppingDate = table.Column<DateTime>(type: "datetime2", unicode: false, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", unicode: false, nullable: false),
                    IsAsset = table.Column<bool>(type: "bit", unicode: false, nullable: false),
                    IsModifedShopping = table.Column<DateTime>(type: "datetime2", unicode: false, nullable: false),
                    IsModified = table.Column<bool>(type: "bit", unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shopping", x => x.ShoppingId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    Email = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", unicode: false, nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", unicode: false, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", unicode: false, nullable: false),
                    IsAsset = table.Column<bool>(type: "bit", unicode: false, nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", unicode: false, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    SenderId = table.Column<int>(type: "int", unicode: false, nullable: false),
                    DateOrder = table.Column<DateTime>(type: "datetime2", unicode: false, nullable: false),
                    OrderCode = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    OrderName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsCreadOrderDate = table.Column<DateTime>(type: "datetime2", unicode: false, nullable: false),
                    IsCread = table.Column<bool>(type: "bit", unicode: false, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", unicode: false, nullable: false),
                    IsAsset = table.Column<bool>(type: "bit", unicode: false, nullable: false),
                    IsModified = table.Column<bool>(type: "bit", unicode: false, nullable: false),
                    IsModifiedOrderDate = table.Column<DateTime>(type: "datetime2", unicode: false, nullable: false),
                    ShoppingId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_Shopping_ShoppingId",
                        column: x => x.ShoppingId,
                        principalTable: "Shopping",
                        principalColumn: "ShoppingId");
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", unicode: false, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    CustomerEmail = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false),
                    CustomerPhone = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false),
                    Direction = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    City = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false),
                    PostalCode = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: false),
                    Country = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", unicode: false, nullable: false),
                    IsUpdatedDate = table.Column<DateTime>(type: "datetime2", unicode: false, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", unicode: false, nullable: false),
                    IsStatu = table.Column<bool>(type: "bit", unicode: false, nullable: false),
                    IsModified = table.Column<bool>(type: "bit", unicode: false, nullable: false),
                    OrdersOrderId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                    table.ForeignKey(
                        name: "FK_Customers_Orders_OrdersOrderId",
                        column: x => x.OrdersOrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId");
                });

            migrationBuilder.CreateTable(
                name: "Senders",
                columns: table => new
                {
                    SenderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SenderName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    SenderDirection = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    SenderPhone = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    SenderPostalCode = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    SenderEmail = table.Column<string>(type: "varchar(180)", unicode: false, maxLength: 180, nullable: false),
                    SenderCode = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    IsCreadSender = table.Column<DateTime>(type: "datetime2", unicode: false, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", unicode: false, nullable: false),
                    IsModifiedSenderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsModifiedPostalCode = table.Column<bool>(type: "bit", unicode: false, nullable: false),
                    IsModifiedSender = table.Column<bool>(type: "bit", unicode: false, nullable: false),
                    IsAsset = table.Column<bool>(type: "bit", unicode: false, nullable: false),
                    OrdersOrderId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Senders", x => x.SenderId);
                    table.ForeignKey(
                        name: "FK_Senders_Orders_OrdersOrderId",
                        column: x => x.OrdersOrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId");
                });

            migrationBuilder.CreateTable(
                name: "Tickers",
                columns: table => new
                {
                    TickerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", unicode: false, nullable: false),
                    TickerTitulo = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    Pago = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    CashierName = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    Direction = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    RNC = table.Column<int>(type: "int", unicode: false, nullable: false),
                    NIF = table.Column<int>(type: "int", unicode: false, nullable: false),
                    TotalAmountItbis = table.Column<decimal>(type: "decimal(18,2)", unicode: false, nullable: false),
                    TotalAmountPay = table.Column<decimal>(type: "decimal(18,2)", unicode: false, nullable: false),
                    TotalProduct = table.Column<int>(type: "int", unicode: false, nullable: false),
                    Description = table.Column<string>(type: "varchar(550)", unicode: false, maxLength: 550, nullable: false),
                    TransactionNumber = table.Column<int>(type: "int", unicode: false, nullable: false),
                    CodeTicker = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", unicode: false, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", unicode: false, nullable: false),
                    IsLocked = table.Column<bool>(type: "bit", unicode: false, nullable: false),
                    IsModified = table.Column<bool>(type: "bit", unicode: false, nullable: false),
                    IsImprection = table.Column<bool>(type: "bit", unicode: false, nullable: false),
                    DateImprect = table.Column<DateTime>(type: "datetime2", unicode: false, nullable: false),
                    IsModifiedDate = table.Column<DateTime>(type: "datetime2", unicode: false, nullable: false),
                    CustomersCustomerId = table.Column<int>(type: "int", nullable: false),
                    ProductosProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickers", x => x.TickerId);
                    table.ForeignKey(
                        name: "FK_Tickers_Customers_CustomersCustomerId",
                        column: x => x.CustomersCustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickers_Productos_ProductosProductId",
                        column: x => x.ProductosProductId,
                        principalTable: "Productos",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetalleTickers",
                columns: table => new
                {
                    DetalleId = table.Column<int>(type: "int", unicode: false, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TickerId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", unicode: false, nullable: false),
                    ProductId = table.Column<int>(type: "int", unicode: false, nullable: false),
                    Itbis = table.Column<decimal>(type: "decimal(18,2)", unicode: false, nullable: false),
                    Descounts = table.Column<decimal>(type: "decimal(18,2)", unicode: false, nullable: false),
                    TotalItbis = table.Column<decimal>(type: "decimal(18,2)", unicode: false, nullable: false),
                    TotalPagar = table.Column<decimal>(type: "decimal(18,2)", unicode: false, nullable: false),
                    TotalDescout = table.Column<decimal>(type: "decimal(18,2)", unicode: false, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", unicode: false, nullable: false),
                    IsModified = table.Column<bool>(type: "bit", unicode: false, nullable: false),
                    IsModifiedDate = table.Column<DateTime>(type: "datetime2", unicode: false, nullable: false),
                    TickersTickerId = table.Column<int>(type: "int", nullable: false),
                    ProductosProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleTickers", x => x.DetalleId);
                    table.ForeignKey(
                        name: "FK_DetalleTickers_Productos_ProductosProductId",
                        column: x => x.ProductosProductId,
                        principalTable: "Productos",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetalleTickers_Tickers_TickersTickerId",
                        column: x => x.TickersTickerId,
                        principalTable: "Tickers",
                        principalColumn: "TickerId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_OrdersOrderId",
                table: "Customers",
                column: "OrdersOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleTickers_ProductosProductId",
                table: "DetalleTickers",
                column: "ProductosProductId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleTickers_TickersTickerId",
                table: "DetalleTickers",
                column: "TickersTickerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ShoppingId",
                table: "Orders",
                column: "ShoppingId");

            migrationBuilder.CreateIndex(
                name: "IX_Senders_OrdersOrderId",
                table: "Senders",
                column: "OrdersOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickers_CustomersCustomerId",
                table: "Tickers",
                column: "CustomersCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickers_ProductosProductId",
                table: "Tickers",
                column: "ProductosProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetalleTickers");

            migrationBuilder.DropTable(
                name: "Proveedores");

            migrationBuilder.DropTable(
                name: "Senders");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Tickers");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Shopping");
        }
    }
}
