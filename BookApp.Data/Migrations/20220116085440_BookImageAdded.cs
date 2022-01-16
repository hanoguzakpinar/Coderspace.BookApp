using Microsoft.EntityFrameworkCore.Migrations;

namespace BookApp.Data.Migrations
{
    public partial class BookImageAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Books",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "ee048215-5870-4a10-b4bf-68d000589769");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "fb3fc058-a282-4bb0-b154-583098ec82de");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e46892a3-3ce2-494e-b2e0-b2e0a8823256", "AQAAAAEAACcQAAAAEL+el3lo3YCS1nQ1j8w/skQNTTWtNM5cEvJZTZVW9UDJQrjHCCq+LNxiTgl0ROqf+Q==", "e11567e0-cf79-4b1e-96d9-54d57eb9df25" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Books");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "07e00f46-748c-4460-8304-0d0e4610002f");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "7116b27c-2f53-47c0-8987-81042fa16172");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "af5c88e0-4c96-4104-898a-62feefe24059", "AQAAAAEAACcQAAAAEEseytF7wNxUQ2ITdrlSnJnp0G7eQYrAFOPMmuvu4NqeZS5BcrPlmNM/T7hI6ZSsbw==", "dd9f1c6b-c2b3-4b5d-aa40-389d365d32c4" });
        }
    }
}
