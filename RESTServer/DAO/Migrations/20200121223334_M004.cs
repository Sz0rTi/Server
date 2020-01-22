using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAO.Migrations
{
    public partial class M004 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Purchases");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b34ea1f9-9a4e-4923-8d4c-1eecbc96a083");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c7001e71-c951-4350-bdd4-e3b450e0d92c");

            migrationBuilder.CreateTable(
                name: "Summaries",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Month = table.Column<int>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    SumBought = table.Column<double>(nullable: false),
                    SumSold = table.Column<double>(nullable: false),
                    SumEarned = table.Column<double>(nullable: false),
                    UserID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Summaries", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SummaryProductBuys",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    SummaryID = table.Column<Guid>(nullable: false),
                    ProductName = table.Column<string>(nullable: true),
                    Amount = table.Column<int>(nullable: false),
                    AvgBuyPrice = table.Column<double>(nullable: false),
                    SumBought = table.Column<double>(nullable: false),
                    UserID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SummaryProductBuys", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SummaryProductBuys_Summaries_SummaryID",
                        column: x => x.SummaryID,
                        principalTable: "Summaries",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SummaryProductSells",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    ProductName = table.Column<string>(nullable: true),
                    AvgBuyPrice = table.Column<double>(nullable: false),
                    AvgSellPrice = table.Column<double>(nullable: false),
                    AvgEarn = table.Column<double>(nullable: false),
                    SumBought = table.Column<double>(nullable: false),
                    SumSold = table.Column<double>(nullable: false),
                    SumEarned = table.Column<double>(nullable: false),
                    Amount = table.Column<int>(nullable: false),
                    SummaryID = table.Column<Guid>(nullable: false),
                    UserID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SummaryProductSells", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SummaryProductSells_Summaries_SummaryID",
                        column: x => x.SummaryID,
                        principalTable: "Summaries",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b78591ff-442c-4a0e-af89-ab55a99ccb71", "a3e9e732-aef6-4b36-95c5-65876ffeb8e7", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0947b86f-652f-493a-ba4e-082252b24bc4", "9f739a6a-bbd6-41ab-a0bb-86f2b980fc07", "Admin", null });

            migrationBuilder.CreateIndex(
                name: "IX_SummaryProductBuys_SummaryID",
                table: "SummaryProductBuys",
                column: "SummaryID");

            migrationBuilder.CreateIndex(
                name: "IX_SummaryProductSells_SummaryID",
                table: "SummaryProductSells",
                column: "SummaryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SummaryProductBuys");

            migrationBuilder.DropTable(
                name: "SummaryProductSells");

            migrationBuilder.DropTable(
                name: "Summaries");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0947b86f-652f-493a-ba4e-082252b24bc4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b78591ff-442c-4a0e-af89-ab55a99ccb71");

            migrationBuilder.CreateTable(
                name: "Purchases",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Amount = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    PriceNetto = table.Column<double>(nullable: false),
                    ProductID = table.Column<Guid>(nullable: false),
                    TaxStageID = table.Column<Guid>(nullable: false),
                    UnitID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchases", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Purchases_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c7001e71-c951-4350-bdd4-e3b450e0d92c", "0b02bbe1-705f-4230-8592-0bced329c22d", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b34ea1f9-9a4e-4923-8d4c-1eecbc96a083", "68f799bd-1033-4749-813e-930f36fa1238", "Admin", null });

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_ProductID",
                table: "Purchases",
                column: "ProductID");
        }
    }
}
