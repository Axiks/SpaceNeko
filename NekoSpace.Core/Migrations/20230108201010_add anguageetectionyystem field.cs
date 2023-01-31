using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NekoSpace.API.Migrations
{
    /// <inheritdoc />
    public partial class addanguageetectionyystemfield : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "484f1214-7d66-49aa-a3e6-b416fd6cab8f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4c10f542-2f59-44a4-abf7-864955b0edc6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5154749c-b052-4cb2-8e3c-bdb34bee648b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "659a87f6-6230-4a94-9120-c121fd0d3ee3");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f103aab6-b20b-4b89-9d42-227a2beff401", "41c04c7b-f0e0-479f-aee3-3479969097fb" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f103aab6-b20b-4b89-9d42-227a2beff401");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "41c04c7b-f0e0-479f-aee3-3479969097fb");

            migrationBuilder.AddColumn<bool>(
                name: "LanguageDetectionBySystem",
                table: "AnimeTitle",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LanguageDetectionBySystem",
                table: "AnimeSynopsis",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9b351b39-896c-41c3-950d-3f6b62f179ba", "1", "Administrator", "ADMINISTRATOR" },
                    { "9faa44a4-09b4-4514-bd29-a5f7b9dcd6b5", "1", "Guest", "GUEST" },
                    { "b2b69d87-c020-474d-919a-904bfd1c58e3", "1", "Creator", "CREATOR" },
                    { "db1b0726-ed51-464f-8413-4cfa68e3eacc", "1", "User", "USER" },
                    { "f679c7f7-6eff-4b4f-bc68-7b53adf41c75", "1", "Moderator", "MODERATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "About", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "74989410-06c5-4ddd-a79c-90efecc00ac4", null, 0, "6af00544-69dd-4ed7-a55b-bf267495011c", "admin@example.local", false, false, null, "ADMIN@EXAMPLE.LOCAL", "ADMIN", "AQAAAAEAACcQAAAAEHcnJe+yZ9BMU/ZP+V42eQaJYhEMQw4gKoLXDQFEHKcwhElL+c2NC7MkZJu2onNIdw==", null, false, "ec8546b0-9ccf-4cb1-b561-3065e51f58a6", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "9b351b39-896c-41c3-950d-3f6b62f179ba", "74989410-06c5-4ddd-a79c-90efecc00ac4" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9faa44a4-09b4-4514-bd29-a5f7b9dcd6b5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b2b69d87-c020-474d-919a-904bfd1c58e3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "db1b0726-ed51-464f-8413-4cfa68e3eacc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f679c7f7-6eff-4b4f-bc68-7b53adf41c75");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "9b351b39-896c-41c3-950d-3f6b62f179ba", "74989410-06c5-4ddd-a79c-90efecc00ac4" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9b351b39-896c-41c3-950d-3f6b62f179ba");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "74989410-06c5-4ddd-a79c-90efecc00ac4");

            migrationBuilder.DropColumn(
                name: "LanguageDetectionBySystem",
                table: "AnimeTitle");

            migrationBuilder.DropColumn(
                name: "LanguageDetectionBySystem",
                table: "AnimeSynopsis");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "484f1214-7d66-49aa-a3e6-b416fd6cab8f", "1", "User", "USER" },
                    { "4c10f542-2f59-44a4-abf7-864955b0edc6", "1", "Guest", "GUEST" },
                    { "5154749c-b052-4cb2-8e3c-bdb34bee648b", "1", "Moderator", "MODERATOR" },
                    { "659a87f6-6230-4a94-9120-c121fd0d3ee3", "1", "Creator", "CREATOR" },
                    { "f103aab6-b20b-4b89-9d42-227a2beff401", "1", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "About", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "41c04c7b-f0e0-479f-aee3-3479969097fb", null, 0, "9b39b751-486e-4605-8e6a-b434fd75b9af", "admin@example.local", false, false, null, "ADMIN@EXAMPLE.LOCAL", "ADMIN", "AQAAAAEAACcQAAAAEHcnJe+yZ9BMU/ZP+V42eQaJYhEMQw4gKoLXDQFEHKcwhElL+c2NC7MkZJu2onNIdw==", null, false, "9b3ae6a0-67c4-47a2-bbf4-95b5341460bc", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "f103aab6-b20b-4b89-9d42-227a2beff401", "41c04c7b-f0e0-479f-aee3-3479969097fb" });
        }
    }
}
