using Microsoft.EntityFrameworkCore.Migrations;

namespace GiffyCards.Data.Migrations
{
    public partial class CreateShppingCart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CiagrId",
                table: "ShoppingCart");

            migrationBuilder.DropColumn(
                name: "UserdId",
                table: "ShoppingCart");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CiagrId",
                table: "ShoppingCart",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserdId",
                table: "ShoppingCart",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
