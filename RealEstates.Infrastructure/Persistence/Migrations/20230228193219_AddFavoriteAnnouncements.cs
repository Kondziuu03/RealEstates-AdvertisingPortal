using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstates.Infrastructure.Persistence.Migrations
{
    public partial class AddFavoriteAnnouncements : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
