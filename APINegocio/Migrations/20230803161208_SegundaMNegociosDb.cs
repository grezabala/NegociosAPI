using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APINegocio.Migrations
{
    /// <inheritdoc />
    public partial class SegundaMNegociosDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "IsDeletedAt",
                table: "Users",
                type: "datetime2",
                unicode: false,
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDateUtc",
                table: "Users",
                type: "datetime2",
                unicode: false,
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "IsDeletedAt",
                table: "Tickers",
                type: "datetime2",
                unicode: false,
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "IsDeletedAt",
                table: "Shopping",
                type: "datetime2",
                unicode: false,
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "IsDeletedAt",
                table: "Senders",
                type: "datetime2",
                unicode: false,
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "IsDeletedAt",
                table: "Proveedores",
                type: "datetime2",
                unicode: false,
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "IsDeletedAt",
                table: "Productos",
                type: "datetime2",
                unicode: false,
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "IsDeletedAt",
                table: "Orders",
                type: "datetime2",
                unicode: false,
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "IsDeletedAt",
                table: "DetalleTickers",
                type: "datetime2",
                unicode: false,
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdated",
                table: "DetalleTickers",
                type: "datetime2",
                unicode: false,
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "IsDeletedAt",
                table: "Customers",
                type: "datetime2",
                unicode: false,
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
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
                    IsUpdateAt = table.Column<DateTime>(type: "datetime2", unicode: false, nullable: false)
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
                    Note = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    IsRecurring = table.Column<bool>(type: "bit", unicode: false, nullable: false),
                    WhenDate = table.Column<DateTime>(type: "datetime2", unicode: false, nullable: false),
                    IsDateCreadCountry = table.Column<DateTime>(type: "datetime2", unicode: false, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", unicode: false, nullable: false),
                    IsDeletedAt = table.Column<DateTime>(type: "datetime2", unicode: false, nullable: false)
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
                    IsUpdatedAt = table.Column<DateTime>(type: "datetime2", unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.PaymentId);
                });

            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    StoresId = table.Column<int>(type: "int", unicode: false, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoresName = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    StoresDescription = table.Column<string>(type: "varchar(550)", unicode: false, maxLength: 550, nullable: false),
                    StoresCount = table.Column<int>(type: "int", unicode: false, nullable: false),
                    StoresTotal = table.Column<int>(type: "int", unicode: false, nullable: false),
                    Biography = table.Column<string>(type: "varchar(550)", unicode: false, maxLength: 550, nullable: false),
                    WebSite = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    FacebookAccount = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    InstagramAccount = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    Address = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    AceptPyments = table.Column<bool>(type: "bit", unicode: false, nullable: false),
                    Latitud = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    Longitud = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    WhatsAppNumber = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    PhoneNumber = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    OtherNumber = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", unicode: false, nullable: false),
                    IsCreadDateStore = table.Column<DateTime>(type: "datetime2", unicode: false, nullable: false),
                    IsModified = table.Column<DateTime>(type: "datetime2", unicode: false, nullable: false),
                    IsDeletedAt = table.Column<DateTime>(type: "datetime2", unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.StoresId);
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
                name: "City");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Stores");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsDeletedAt",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LastModifiedDateUtc",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsDeletedAt",
                table: "Tickers");

            migrationBuilder.DropColumn(
                name: "IsDeletedAt",
                table: "Shopping");

            migrationBuilder.DropColumn(
                name: "IsDeletedAt",
                table: "Senders");

            migrationBuilder.DropColumn(
                name: "IsDeletedAt",
                table: "Proveedores");

            migrationBuilder.DropColumn(
                name: "IsDeletedAt",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "IsDeletedAt",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "IsDeletedAt",
                table: "DetalleTickers");

            migrationBuilder.DropColumn(
                name: "LastUpdated",
                table: "DetalleTickers");

            migrationBuilder.DropColumn(
                name: "IsDeletedAt",
                table: "Customers");
        }
    }
}
