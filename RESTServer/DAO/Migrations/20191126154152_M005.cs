using Microsoft.EntityFrameworkCore.Migrations;

namespace DAO.Migrations
{
    public partial class M005 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "InvoicesSell",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "InvoicesBuy",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "InvoicesSell");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "InvoicesBuy");
        }
    }
}
