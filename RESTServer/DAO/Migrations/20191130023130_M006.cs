using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAO.Migrations
{
    public partial class M006 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Sellers",
                newName: "Street");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Sellers",
                newName: "PostCode");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Sellers",
                newName: "Number");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Sellers",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UnitID",
                table: "ProductsBuy",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "InvoicesBuy",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Sellers");

            migrationBuilder.DropColumn(
                name: "UnitID",
                table: "ProductsBuy");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "InvoicesBuy");

            migrationBuilder.RenameColumn(
                name: "Street",
                table: "Sellers",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "PostCode",
                table: "Sellers",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "Number",
                table: "Sellers",
                newName: "Address");
        }
    }
}
