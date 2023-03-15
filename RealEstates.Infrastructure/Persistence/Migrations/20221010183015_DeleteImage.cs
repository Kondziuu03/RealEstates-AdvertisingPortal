using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstates.Infrastructure.Persistence.Migrations
{
    public partial class DeleteImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Data",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "Extension",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "FileType",
                table: "Images");

            migrationBuilder.AddColumn<long>(
                name: "Bytes",
                table: "Images",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bytes",
                table: "Images");

            migrationBuilder.AddColumn<byte[]>(
                name: "Data",
                table: "Images",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Extension",
                table: "Images",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileType",
                table: "Images",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
