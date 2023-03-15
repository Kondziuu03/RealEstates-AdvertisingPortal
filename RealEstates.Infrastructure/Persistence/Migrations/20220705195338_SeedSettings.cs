using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstates.Infrastructure.Persistence.Migrations
{
    public partial class SeedSettings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "Id", "Description", "Order" },
                values: new object[] { 1, "E-mail", 2 });

            migrationBuilder.InsertData(
                table: "SettingsPositions",
                columns: new[] { "Id", "Description", "Key", "Order", "SettingsId", "Type", "Value" },
                values: new object[,]
                {
                    { 1, "Host", "HostSmtp", 1, 1, 0, "smtp.gmail.com" },
                    { 2, "Port", "Port", 2, 1, 2, "587" },
                    { 3, "Adres e-mail nadawcy", "SenderEmail", 3, 1, 0, "" },
                    { 4, "Hasło", "SenderEmailPassword", 4, 1, 4, "" },
                    { 5, "Nazwa nadawcy", "SenderName", 5, 1, 0, "Konrad Kolka" },
                    { 6, "Login nadawcy", "SenderLogin", 6, 1, 0, "" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SettingsPositions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SettingsPositions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SettingsPositions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "SettingsPositions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "SettingsPositions",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "SettingsPositions",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
