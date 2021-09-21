using Microsoft.EntityFrameworkCore.Migrations;

namespace eCommerceTest.Migrations
{
    public partial class Fixing_Producer_ID_Field : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "Producers",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Producers",
                newName: "id");
        }
    }
}
