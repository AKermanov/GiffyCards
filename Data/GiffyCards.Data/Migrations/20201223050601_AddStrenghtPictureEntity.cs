using Microsoft.EntityFrameworkCore.Migrations;

namespace GiffyCards.Data.Migrations
{
    public partial class AddStrenghtPictureEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PictureUrl",
                table: "Strenghts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PictureUrl",
                table: "Strenghts");
        }
    }
}
