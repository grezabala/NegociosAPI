using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APINegocio.Migrations
{
    /// <inheritdoc />
    public partial class MGIniciarNegocioDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "AspNetRoles",
            //    columns: table => new
            //    {
            //        Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
            //        NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
            //        ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetRoles", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetUsers",
            //    columns: table => new
            //    {
            //        Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
            //        NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
            //        Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
            //        NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
            //        EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
            //        PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
            //        TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
            //        LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
            //        LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
            //        AccessFailedCount = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetUsers", x => x.Id);
            //    });

            migrationBuilder.CreateTable(
                name: "BranchOffices",
                columns: table => new
                {
                    BranchId = table.Column<int>(type: "int", unicode: false, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchOfficesName = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    Description = table.Column<string>(type: "varchar(550)", unicode: false, maxLength: 550, nullable: false),
                    BranchOfficesCode = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    Direccion = table.Column<string>(type: "varchar(350)", unicode: false, maxLength: 350, nullable: false),
                    Contacts = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: false),
                    Referencia = table.Column<string>(type: "varchar(550)", unicode: false, maxLength: 550, nullable: false),
                    WebSite = table.Column<string>(type: "varchar(350)", unicode: false, maxLength: 350, nullable: false),
                    FacebookAccount = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    InstagramAccount = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    WhatsAppNumber = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    PhoneNumber = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: false),
                    OtherNumber = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: false),
                    Latitud = table.Column<float>(type: "real", unicode: false, nullable: false),
                    Longitud = table.Column<float>(type: "real", unicode: false, nullable: false),
                    IsDeletedBy = table.Column<bool>(type: "bit", unicode: false, nullable: false),
                    IsCreadBy = table.Column<bool>(type: "bit", unicode: false, nullable: false),
                    IsDeletedAt = table.Column<DateTime>(type: "datetime2", unicode: false, nullable: true),
                    IsCreadAt = table.Column<DateTime>(type: "datetime2", unicode: false, nullable: false),
                    IsUpdatedBy = table.Column<bool>(type: "bit", unicode: false, nullable: false),
                    IsUpdatedAt = table.Column<DateTime>(type: "datetime2", unicode: false, nullable: false),
                    IsStatud = table.Column<bool>(type: "bit", unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchOffices", x => x.BranchId);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    CityId = table.Column<int>(type: "int", unicode: false, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    CityName = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    Code = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", unicode: false, nullable: false),
                    IsDeletedAt = table.Column<DateTime>(type: "datetime2", unicode: false, nullable: false),
                    IsUpdated = table.Column<bool>(type: "bit", unicode: false, nullable: false),
                    IsUpdateAt = table.Column<DateTime>(type: "datetime2", unicode: false, nullable: false),
                    IsStatus = table.Column<bool>(type: "bit", unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.CityId);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryId = table.Column<int>(type: "int", unicode: false, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryName = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    StorId = table.Column<int>(type: "int", unicode: false, nullable: false),
                    ProveedorId = table.Column<int>(type: "int", unicode: false, nullable: false),
                    CodeCountries = table.Column<string>(type: "varchar(30)", unicode: false, nullable: true),
                    Note = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    IsRecurring = table.Column<bool>(type: "bit", unicode: false, nullable: false),
                    WhenDate = table.Column<DateTime>(type: "datetime2", unicode: false, nullable: false),
                    IsDateCreadCountry = table.Column<DateTime>(type: "datetime2", unicode: false, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", unicode: false, nullable: false),
                    IsDeletedAt = table.Column<DateTime>(type: "datetime2", unicode: false, nullable: false),
                    IsStatud = table.Column<bool>(type: "bit", nullable: false),
                    IsUpdated = table.Column<bool>(type: "bit", nullable: true),
                    IsUpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    PaymentId = table.Column<int>(type: "int", unicode: false, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", unicode: false, nullable: false),
                    Toquen = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    Monto = table.Column<decimal>(type: "decimal(18,2)", unicode: false, nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", unicode: false, nullable: false),
                    Reservado = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    Aplicado = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    IsCreadtPayment = table.Column<DateTime>(type: "datetime2", unicode: false, nullable: false),
                    IsCreadtRefund = table.Column<bool>(type: "bit", unicode: false, nullable: false),
                    Creditado = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    IsRefund = table.Column<bool>(type: "bit", unicode: false, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", unicode: false, nullable: false),
                    IsDeletedAt = table.Column<DateTime>(type: "datetime2", unicode: false, nullable: false),
                    IsUpdated = table.Column<bool>(type: "bit", unicode: false, nullable: false),
                    IsUpdatedAt = table.Column<DateTime>(type: "datetime2", unicode: false, nullable: false),
                    IsStatud = table.Column<bool>(type: "bit", nullable: false),
                    PaymentCode = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.PaymentId);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", unicode: false, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    Description = table.Column<string>(type: "varchar(550)", unicode: false, maxLength: 550, nullable: false),
                    Referencia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "Decimal(18,2)", unicode: false, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", unicode: false, nullable: false),
                    IsAsset = table.Column<bool>(type: "bit", unicode: false, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", unicode: false, nullable: false),
                    IsDeletedAt = table.Column<DateTime>(type: "datetime2", unicode: false, nullable: false),
                    IsApproved = table.Column<bool>(type: "bit", unicode: false, nullable: false),
                    IsDateModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsModified = table.Column<bool>(type: "bit", nullable: false),
                    IsApprovedAt = table.Column<DateTime>(type: "datetime2", unicode: false, nullable: false),
                    ProductCode = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
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
                    IsDeletedAt = table.Column<DateTime>(type: "datetime2", unicode: false, nullable: false),
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
                    IsDeletedAt = table.Column<DateTime>(type: "datetime2", unicode: false, nullable: false),
                    IsAsset = table.Column<bool>(type: "bit", unicode: false, nullable: false),
                    IsModifedShopping = table.Column<DateTime>(type: "datetime2", unicode: false, nullable: false),
                    IsModified = table.Column<bool>(type: "bit", unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shopping", x => x.ShoppingId);
                });

            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    StorId = table.Column<int>(type: "int", unicode: false, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoresName = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    CodeStore = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    StoresDescription = table.Column<string>(type: "varchar(550)", unicode: false, maxLength: 550, nullable: false),
                    StoresCount = table.Column<int>(type: "int", unicode: false, nullable: false),
                    StoresTotal = table.Column<int>(type: "int", unicode: false, nullable: false),
                    Biography = table.Column<string>(type: "varchar(550)", unicode: false, maxLength: 550, nullable: false),
                    WebSite = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    FacebookAccount = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    InstagramAccount = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    Address = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    AceptPyments = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Latitud = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    Longitud = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    WhatsAppNumber = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    PhoneNumber = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    OtherNumber = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", unicode: false, nullable: false),
                    IsCreadDateStore = table.Column<DateTime>(type: "datetime2", unicode: false, nullable: false),
                    IsModified = table.Column<DateTime>(type: "datetime2", unicode: false, nullable: false),
                    IsDeletedAt = table.Column<DateTime>(type: "datetime2", unicode: false, nullable: false),
                    IsStatud = table.Column<bool>(type: "bit", unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.StorId);
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
                    IsDeletedAt = table.Column<DateTime>(type: "datetime2", unicode: false, nullable: false),
                    LastModifiedDateUtc = table.Column<DateTime>(type: "datetime2", unicode: false, nullable: false),
                    IsAsset = table.Column<bool>(type: "bit", unicode: false, nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    OrderName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsCreadOrderDate = table.Column<DateTime>(type: "datetime2", unicode: false, nullable: false),
                    IsCread = table.Column<bool>(type: "bit", unicode: false, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", unicode: false, nullable: false),
                    IsDeletedAt = table.Column<DateTime>(type: "datetime2", unicode: false, nullable: false),
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
                name: "Inventory",
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
                   // StorId = table.Column<int>(type: "int", unicode: false, nullable: false),
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
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    StorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory", x => x.InventoryId);
                    table.ForeignKey(
                        name: "FK_Inventory_Productos_ProveedosProductId",
                        column: x => x.ProductId,
                        principalTable: "Productos",
                        principalColumn: "ProductId");
                    table.ForeignKey(
                        name: "FK_Inventory_Proveedores_ProveedoresProveedorId",
                        column: x => x.ProveedorId,
                        principalTable: "Proveedores",
                        principalColumn: "ProveedorId");
                    table.ForeignKey(
                        name: "FK_Inventory_Shopping_ShoppingId",
                        column: x => x.ShoppingId,
                        principalTable: "Shopping",
                        principalColumn: "ShoppingId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inventory_Stores_StorId",
                        column: x => x.StorId,
                        principalTable: "Stores",
                        principalColumn: "StorId");
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
                    CodeCustomer = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Country = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", unicode: false, nullable: true),
                    IsUpdatedDate = table.Column<DateTime>(type: "datetime2", unicode: false, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", unicode: false, nullable: false),
                    IsStatu = table.Column<bool>(type: "bit", unicode: false, nullable: false),
                    IsModified = table.Column<bool>(type: "bit", unicode: false, nullable: false),
                    IsDeletedAt = table.Column<DateTime>(type: "datetime2", unicode: false, nullable: true),
                    OrderId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                    table.ForeignKey(
                        name: "FK_Customers_Orders_OrdersOrderId",
                        column: x => x.OrderId,
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
                    IsDeletedAt = table.Column<DateTime>(type: "datetime2", unicode: false, nullable: false),
                    IsModifiedSenderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsModifiedPostalCode = table.Column<bool>(type: "bit", unicode: false, nullable: false),
                    IsModifiedSender = table.Column<bool>(type: "bit", unicode: false, nullable: false),
                    IsAsset = table.Column<bool>(type: "bit", unicode: false, nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Senders", x => x.SenderId);
                    table.ForeignKey(
                        name: "FK_Senders_Orders_OrdersOrderId",
                        column: x => x.OrderId,
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
                    IsModifiedDate = table.Column<DateTime>(type: "datetime2", unicode: false, nullable: true),
                    IsDeletedAt = table.Column<DateTime>(type: "datetime2", unicode: false, nullable: false),
                    CustomersCustomerId = table.Column<int>(type: "int", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickers", x => x.TickerId);
                    table.ForeignKey(
                        name: "FK_Tickers_Customers_CustomersCustomerId",
                        column: x => x.CustomersCustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId");
                    table.ForeignKey(
                        name: "FK_Tickers_Productos_ProductosProductId",
                        column: x => x.ProductId,
                        principalTable: "Productos",
                        principalColumn: "ProductId");
                });

            migrationBuilder.CreateTable(
                name: "DetalleTickers",
                columns: table => new
                {
                    DetalleId = table.Column<int>(type: "int", unicode: false, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TickerId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", unicode: false, nullable: false),
                    //ProductId = table.Column<int>(type: "int", unicode: false, nullable: false),
                    Itbis = table.Column<decimal>(type: "decimal(18,2)", unicode: false, nullable: false),
                    Descounts = table.Column<decimal>(type: "decimal(18,2)", unicode: false, nullable: false),
                    TotalItbis = table.Column<decimal>(type: "decimal(18,2)", unicode: false, nullable: false),
                    TotalPagar = table.Column<decimal>(type: "decimal(18,2)", unicode: false, nullable: false),
                    TotalDescout = table.Column<decimal>(type: "decimal(18,2)", unicode: false, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", unicode: false, nullable: false),
                    IsDeletedAt = table.Column<DateTime>(type: "datetime2", unicode: false, nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", unicode: false, nullable: false),
                    IsModified = table.Column<bool>(type: "bit", unicode: false, nullable: false),
                    IsModifiedDate = table.Column<DateTime>(type: "datetime2", unicode: false, nullable: false),
                    TickersTickerId = table.Column<int>(type: "int", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleTickers", x => x.DetalleId);
                    table.ForeignKey(
                        name: "FK_DetalleTickers_Productos_ProductosProductId",
                        column: x => x.ProductId,
                        principalTable: "Productos",
                        principalColumn: "ProductId");
                    table.ForeignKey(
                        name: "FK_DetalleTickers_Tickers_TickersTickerId",
                        column: x => x.TickersTickerId,
                        principalTable: "Tickers",
                        principalColumn: "TickerId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_OrdersOrderId",
                table: "Customers",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleTickers_ProductosProductId",
                table: "DetalleTickers",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleTickers_TickersTickerId",
                table: "DetalleTickers",
                column: "TickerId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_ProveedoresProveedorId",
                table: "Inventory",
                column: "ProveedorId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_ProveedosProductId",
                table: "Inventory",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_ShoppingId",
                table: "Inventory",
                column: "ShoppingId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_StorId",
                table: "Inventory",
                column: "StorId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ShoppingId",
                table: "Orders",
                column: "ShoppingId");

            migrationBuilder.CreateIndex(
                name: "IX_Senders_OrderId",
                table: "Senders",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickers_CustomersCustomerId",
                table: "Tickers",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickers_ProductosProductId",
                table: "Tickers",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BranchOffices");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "DetalleTickers");

            migrationBuilder.DropTable(
                name: "Inventory");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Senders");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Tickers");

            migrationBuilder.DropTable(
                name: "Proveedores");

            migrationBuilder.DropTable(
                name: "Stores");

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
