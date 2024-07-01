using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APINegocio.Migrations
{
    /// <inheritdoc />
    public partial class NegocioDbQuintaMG : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_Stores_StoresId",
                table: "Inventory");

            migrationBuilder.RenameColumn(
                name: "StoresId",
                table: "Stores",
                newName: "StorId");

            migrationBuilder.RenameColumn(
                name: "StorId",
                table: "Inventory",
                newName: "StorId");

            migrationBuilder.RenameColumn(
                name: "StorId",
                table: "Inventory",
                newName: "StorId");

            migrationBuilder.RenameIndex(
                name: "IX_Inventory_StoresId",
                table: "Inventory",
                newName: "IX_Inventory_StorId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "IsModifiedDate",
                table: "Tickers",
                type: "datetime2",
                unicode: false,
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldUnicode: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "IsApprovedAt",
                table: "Productos",
                type: "datetime2",
                unicode: false,
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ProductCode",
                table: "Productos",
                type: "varchar(15)",
                unicode: false,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentCode",
                table: "Payments",
                type: "varchar(15)",
                unicode: false,
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "IsUpdatedAt",
                table: "Inventory",
                type: "datetime2",
                unicode: false,
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldUnicode: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "IsDeletedAt",
                table: "Inventory",
                type: "datetime2",
                unicode: false,
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldUnicode: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "IsDateCread",
                table: "Inventory",
                type: "datetime2",
                unicode: false,
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldUnicode: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCread",
                table: "Inventory",
                type: "datetime2",
                unicode: false,
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldUnicode: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsStatu",
                table: "Inventory",
                type: "bit",
                unicode: false,
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Stock",
                table: "Inventory",
                type: "int",
                unicode: false,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "IsUpdatedDate",
                table: "Customers",
                type: "datetime2",
                unicode: false,
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldUnicode: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "IsDeletedAt",
                table: "Customers",
                type: "datetime2",
                unicode: false,
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldUnicode: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Customers",
                type: "datetime2",
                unicode: false,
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldUnicode: false);

            migrationBuilder.AddColumn<string>(
                name: "CodeCustomer",
                table: "Customers",
                type: "varchar(15)",
                unicode: false,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CodeCountries",
                table: "Countries",
                type: "varchar(15)",
                unicode: false,
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "IsDeletedAt",
                table: "BranchOffices",
                type: "datetime2",
                unicode: false,
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldUnicode: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_Stores_StorId",
                table: "Inventory",
                column: "StorId",
                principalTable: "Stores",
                principalColumn: "StorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_Stores_StorId",
                table: "Inventory");

            migrationBuilder.DropColumn(
                name: "IsApprovedAt",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "ProductCode",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "PaymentCode",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "IsStatus",
                table: "Inventory");

            migrationBuilder.DropColumn(
                name: "Stock",
                table: "Inventory");

            migrationBuilder.DropColumn(
                name: "CodeCustomer",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CodeCountries",
                table: "Countries");

            migrationBuilder.RenameColumn(
                name: "StorId",
                table: "Stores",
                newName: "StorId");

            migrationBuilder.RenameColumn(
                name: "StorId",
                table: "Inventory",
                newName: "StoresId");

            migrationBuilder.RenameColumn(
                name: "StorId",
                table: "Inventory",
                newName: "StoreId");

            migrationBuilder.RenameIndex(
                name: "IX_Inventory_StorId",
                table: "Inventory",
                newName: "IX_Inventory_StorId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "IsModifiedDate",
                table: "Tickers",
                type: "datetime2",
                unicode: false,
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldUnicode: false,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "IsUpdatedAt",
                table: "Inventory",
                type: "datetime2",
                unicode: false,
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldUnicode: false,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "IsDeletedAt",
                table: "Inventory",
                type: "datetime2",
                unicode: false,
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldUnicode: false,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "IsDateCread",
                table: "Inventory",
                type: "datetime2",
                unicode: false,
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldUnicode: false,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCread",
                table: "Inventory",
                type: "datetime2",
                unicode: false,
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldUnicode: false,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "IsUpdatedDate",
                table: "Customers",
                type: "datetime2",
                unicode: false,
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldUnicode: false,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "IsDeletedAt",
                table: "Customers",
                type: "datetime2",
                unicode: false,
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldUnicode: false,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Customers",
                type: "datetime2",
                unicode: false,
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldUnicode: false,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "IsDeletedAt",
                table: "BranchOffices",
                type: "datetime2",
                unicode: false,
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldUnicode: false,
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_Stores_StorId",
                table: "Inventory",
                column: "StorId",
                principalTable: "Stores",
                principalColumn: "StorId");
        }
    }
}
