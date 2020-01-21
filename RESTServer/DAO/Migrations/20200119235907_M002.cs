using System;
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
                keyValue: "7a0e358e-76f9-4f30-9e91-42b0befd3b66");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f2923fae-d455-439d-b786-973e3bfb89db");

            migrationBuilder.AddColumn<Guid>(
                name: "PaymentMethodID",
                table: "InvoicesSell",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "PaymentMethodID",
                table: "InvoicesBuy",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "PaymentMethods",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethods", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8d09d664-988d-45d1-a5ac-7dc9740a736a", "973f0436-73da-4767-a63a-529d9c1c5747", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "629d8567-7990-44a1-bd49-c02cbab24256", "7540b9f3-7982-4c37-8cfd-dfe6e693df48", "Admin", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PaymentMethods");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "629d8567-7990-44a1-bd49-c02cbab24256");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8d09d664-988d-45d1-a5ac-7dc9740a736a");

            migrationBuilder.DropColumn(
                name: "PaymentMethodID",
                table: "InvoicesSell");

            migrationBuilder.DropColumn(
                name: "PaymentMethodID",
                table: "InvoicesBuy");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f2923fae-d455-439d-b786-973e3bfb89db", "59c26316-9b0a-4409-b0d0-8ca894d11f45", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7a0e358e-76f9-4f30-9e91-42b0befd3b66", "cceed104-965f-41d3-b8fb-306fdf4cc95d", "Admin", null });
        }
    }
}
