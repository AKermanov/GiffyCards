using Microsoft.EntityFrameworkCore.Migrations;

namespace GiffyCards.Data.Migrations
{
    public partial class UsersPhotos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_CustomerPhotos_CustomerPhotoId1",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CustomerPhotoId1",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CustomerPhotoId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CustomerPhotoId1",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "CustomerPhotos",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPhotos_UserId",
                table: "CustomerPhotos",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerPhotos_AspNetUsers_UserId",
                table: "CustomerPhotos",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerPhotos_AspNetUsers_UserId",
                table: "CustomerPhotos");

            migrationBuilder.DropIndex(
                name: "IX_CustomerPhotos_UserId",
                table: "CustomerPhotos");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "CustomerPhotos");

            migrationBuilder.AddColumn<int>(
                name: "CustomerPhotoId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomerPhotoId1",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CustomerPhotoId1",
                table: "AspNetUsers",
                column: "CustomerPhotoId1");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_CustomerPhotos_CustomerPhotoId1",
                table: "AspNetUsers",
                column: "CustomerPhotoId1",
                principalTable: "CustomerPhotos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
