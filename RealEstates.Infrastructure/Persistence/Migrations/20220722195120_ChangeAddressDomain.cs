using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstates.Infrastructure.Persistence.Migrations
{
    public partial class ChangeAddressDomain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_RealEstates_RealEstateId",
                table: "Addresses");

            migrationBuilder.RenameColumn(
                name: "RealEstateId",
                table: "Addresses",
                newName: "AnnouncementId");

            migrationBuilder.RenameIndex(
                name: "IX_Addresses_RealEstateId",
                table: "Addresses",
                newName: "IX_Addresses_AnnouncementId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Announcements_AnnouncementId",
                table: "Addresses",
                column: "AnnouncementId",
                principalTable: "Announcements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Announcements_AnnouncementId",
                table: "Addresses");

            migrationBuilder.RenameColumn(
                name: "AnnouncementId",
                table: "Addresses",
                newName: "RealEstateId");

            migrationBuilder.RenameIndex(
                name: "IX_Addresses_AnnouncementId",
                table: "Addresses",
                newName: "IX_Addresses_RealEstateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_RealEstates_RealEstateId",
                table: "Addresses",
                column: "RealEstateId",
                principalTable: "RealEstates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
