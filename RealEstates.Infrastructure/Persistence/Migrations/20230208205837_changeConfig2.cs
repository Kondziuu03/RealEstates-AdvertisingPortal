using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstates.Infrastructure.Persistence.Migrations
{
    public partial class changeConfig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Announcements_AnnouncementId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_Announcements_AnnouncementId",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_RealEstates_Announcements_AnnouncementId",
                table: "RealEstates");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Announcements_AnnouncementId",
                table: "Addresses",
                column: "AnnouncementId",
                principalTable: "Announcements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Announcements_AnnouncementId",
                table: "Images",
                column: "AnnouncementId",
                principalTable: "Announcements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RealEstates_Announcements_AnnouncementId",
                table: "RealEstates",
                column: "AnnouncementId",
                principalTable: "Announcements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Announcements_AnnouncementId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_Announcements_AnnouncementId",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_RealEstates_Announcements_AnnouncementId",
                table: "RealEstates");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Announcements_AnnouncementId",
                table: "Addresses",
                column: "AnnouncementId",
                principalTable: "Announcements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Announcements_AnnouncementId",
                table: "Images",
                column: "AnnouncementId",
                principalTable: "Announcements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RealEstates_Announcements_AnnouncementId",
                table: "RealEstates",
                column: "AnnouncementId",
                principalTable: "Announcements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
