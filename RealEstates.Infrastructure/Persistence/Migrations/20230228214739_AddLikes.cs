using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstates.Infrastructure.Persistence.Migrations
{
    public partial class AddLikes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Announcements_AspNetUsers_ApplicationUserId",
                table: "Announcements");

            migrationBuilder.DropIndex(
                name: "IX_Announcements_ApplicationUserId",
                table: "Announcements");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Announcements");

            migrationBuilder.AddColumn<int>(
                name: "Likes",
                table: "Announcements",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Likes",
                table: "Announcements");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Announcements",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Announcements_ApplicationUserId",
                table: "Announcements",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Announcements_AspNetUsers_ApplicationUserId",
                table: "Announcements",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
