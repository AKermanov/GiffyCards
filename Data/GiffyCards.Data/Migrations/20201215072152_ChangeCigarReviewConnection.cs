using Microsoft.EntityFrameworkCore.Migrations;

namespace GiffyCards.Data.Migrations
{
    public partial class ChangeCigarReviewConnection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cigars_Reviews_ReviewId",
                table: "Cigars");

            migrationBuilder.DropIndex(
                name: "IX_Cigars_ReviewId",
                table: "Cigars");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "ReviewId",
                table: "Cigars");

            migrationBuilder.AddColumn<int>(
                name: "CigarId",
                table: "Reviews",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_CigarId",
                table: "Reviews",
                column: "CigarId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Cigars_CigarId",
                table: "Reviews",
                column: "CigarId",
                principalTable: "Cigars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Cigars_CigarId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_CigarId",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "CigarId",
                table: "Reviews");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Reviews",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReviewId",
                table: "Cigars",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cigars_ReviewId",
                table: "Cigars",
                column: "ReviewId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cigars_Reviews_ReviewId",
                table: "Cigars",
                column: "ReviewId",
                principalTable: "Reviews",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
