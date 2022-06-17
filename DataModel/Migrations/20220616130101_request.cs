using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataModel.Migrations
{
    public partial class request : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "remainQuantity",
                table: "RequestItems",
                newName: "approvedQuantity");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "approvedQuantity",
                table: "RequestItems",
                newName: "remainQuantity");
        }
    }
}
