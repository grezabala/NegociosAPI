using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APINegocio.Migrations
{
    /// <inheritdoc />
    public partial class NegocioDbCuartaMG : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    IsDeletedAt = table.Column<DateTime>(type: "datetime2", unicode: false, nullable: false),
                    IsCreadAt = table.Column<DateTime>(type: "datetime2", unicode: false, nullable: false),
                    IsUpdatedBy = table.Column<bool>(type: "bit", unicode: false, nullable: false),
                    IsUpdatedAt = table.Column<DateTime>(type: "datetime2", unicode: false, nullable: false),
                    IsStatud = table.Column<bool>(type: "bit", unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchOffices", x => x.BranchId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BranchOffices");
        }
    }
}
