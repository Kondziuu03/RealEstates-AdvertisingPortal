using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstates.Infrastructure.Persistence.Migrations
{
    public partial class ChangeImageProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bytes",
                table: "Images");

            migrationBuilder.AddColumn<byte>(
                name: "Data",
                table: "Images",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Data",
                table: "Images");

            migrationBuilder.AddColumn<long>(
                name: "Bytes",
                table: "Images",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
