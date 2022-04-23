using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtGalleryAPI.Migrations
{
    public partial class AddUserSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "EmailAddress", "FirstName", "IsBannded", "IsEditor", "LastName", "PasswordHash", "UserRole" },
                values: new object[] { "maups", "mau@paro.mnd", "Guy De", false, false, "Maupesant", "1255376235", "U" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "EmailAddress", "FirstName", "IsBannded", "IsEditor", "LastName", "PasswordHash", "UserRole" },
                values: new object[] { "mws", "simon@kaballana.mnd", "Martin", false, true, "Wickramasinghe", "1255376235", "U" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: "maups");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: "mws");
        }
    }
}
