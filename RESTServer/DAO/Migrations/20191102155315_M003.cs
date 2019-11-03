using Microsoft.EntityFrameworkCore.Migrations;

namespace DAO.Migrations
{
    public partial class M003 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Clients",
                newName: "Street");

            migrationBuilder.RenameColumn(
                name: "Mail",
                table: "Clients",
                newName: "PostCode");

            migrationBuilder.RenameColumn(
                name: "Adress",
                table: "Clients",
                newName: "Number");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Clients",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Clients");

            migrationBuilder.RenameColumn(
                name: "Street",
                table: "Clients",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "PostCode",
                table: "Clients",
                newName: "Mail");

            migrationBuilder.RenameColumn(
                name: "Number",
                table: "Clients",
                newName: "Adress");
        }
    }
}
