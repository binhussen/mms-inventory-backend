using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataModel.Migrations
{
    public partial class property : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "bithPlace",
                table: "Customers",
                newName: "birthPlace");

            migrationBuilder.AddColumn<bool>(
                name: "availability",
                table: "StoreItems",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "availability",
                table: "StoreItems");

            migrationBuilder.RenameColumn(
                name: "birthPlace",
                table: "Customers",
                newName: "bithPlace");
        }
    }
}
