using Microsoft.EntityFrameworkCore.Migrations;

namespace DAO.Migrations
{
    public partial class M002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "98a462ad-f9c1-4789-95bb-a679541e81c7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cf421bf7-4397-4fbc-9d1a-a5c443f70d72");

            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "Units",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "TaxStages",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "Sellers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "ProductsSell",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "ProductsBuy",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "Clients",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "Categories",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "72339eb4-d747-428f-9023-581ec5120393", "a3ffc78e-40bd-4bf2-aad6-926d479d05c7", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "51d26b9c-d6fc-4689-a4f0-6e20b5defd2e", "c6014d92-ba6e-44a3-8f36-befa2e0a7cca", "Admin", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "51d26b9c-d6fc-4689-a4f0-6e20b5defd2e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "72339eb4-d747-428f-9023-581ec5120393");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "TaxStages");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Sellers");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "ProductsSell");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "ProductsBuy");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Categories");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "98a462ad-f9c1-4789-95bb-a679541e81c7", "ff66004c-a465-45b0-a7bf-728368cad5ba", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cf421bf7-4397-4fbc-9d1a-a5c443f70d72", "7c504467-c624-475c-9821-921bf8905931", "Admin", null });
        }
    }
}
