using Microsoft.EntityFrameworkCore.Migrations;

namespace DAO.Migrations
{
    public partial class M003 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "629d8567-7990-44a1-bd49-c02cbab24256");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8d09d664-988d-45d1-a5ac-7dc9740a736a");

            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "PaymentMethods",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c7001e71-c951-4350-bdd4-e3b450e0d92c", "0b02bbe1-705f-4230-8592-0bced329c22d", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b34ea1f9-9a4e-4923-8d4c-1eecbc96a083", "68f799bd-1033-4749-813e-930f36fa1238", "Admin", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b34ea1f9-9a4e-4923-8d4c-1eecbc96a083");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c7001e71-c951-4350-bdd4-e3b450e0d92c");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "PaymentMethods");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8d09d664-988d-45d1-a5ac-7dc9740a736a", "973f0436-73da-4767-a63a-529d9c1c5747", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "629d8567-7990-44a1-bd49-c02cbab24256", "7540b9f3-7982-4c37-8cfd-dfe6e693df48", "Admin", null });
        }
    }
}
