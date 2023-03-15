using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstates.Infrastructure.Persistence.Migrations
{
    public partial class AddRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "75EAFA86-47E4-4EAB-9833-5181E2F56943", "6FAEB7FB-C5CF-4A59-9C83-D2C4FD7F84CF", "Użytkownik", "UŻYTKOWNIK" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "E673A36A-9310-49CA-B64D-B89F1D54FEE3", "6361294E-A052-4851-A4A4-A1031CFBBD92", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "75EAFA86-47E4-4EAB-9833-5181E2F56943");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "E673A36A-9310-49CA-B64D-B89F1D54FEE3");
        }
    }
}
