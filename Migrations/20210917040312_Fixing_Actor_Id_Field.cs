using Microsoft.EntityFrameworkCore.Migrations;

namespace eCommerceTest.Migrations
{
    public partial class Fixing_Actor_Id_Field : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "Actors",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Actors",
                newName: "id");
        }
    }
}
