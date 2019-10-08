using Microsoft.EntityFrameworkCore.Migrations;

namespace DAO.Migrations
{
    public partial class M002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PriceBrutto",
                table: "InvoicesSell");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "PriceBrutto",
                table: "InvoicesSell",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
