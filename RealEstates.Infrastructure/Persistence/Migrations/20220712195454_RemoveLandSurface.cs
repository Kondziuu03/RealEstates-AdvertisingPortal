using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstates.Infrastructure.Persistence.Migrations
{
    public partial class RemoveLandSurface : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LandArea",
                table: "RealEstates");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "LandArea",
                table: "RealEstates",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
