using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NekoSpace.Data.Migrations
{
    /// <inheritdoc />
    public partial class Updatepropositiontables3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImageEntity");

            migrationBuilder.DropTable(
                name: "TextVariantSubItemEntity");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "10c15deb-373e-414c-a881-5fdc2f245ada");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3ddf9278-6638-430f-bee0-bd77bdc413e6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5693508c-3dda-4251-8144-d57e43fb27dc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dc1259ec-d977-432d-8bac-bcdcae517fa6");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "45a820a6-5949-43c0-af92-84143c46c99d", "459c2d6b-f289-4639-96ab-ac963e95dc3c" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "45a820a6-5949-43c0-af92-84143c46c99d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "459c2d6b-f289-4639-96ab-ac963e95dc3c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "190fad51-4e7c-463e-a10a-64c7515b060b", "1", "Creator", "CREATOR" },
                    { "5f1e45c8-99df-431e-86c1-88b81269c7ae", "1", "Moderator", "MODERATOR" },
                    { "c5986e89-7979-4a5f-aa12-9cb34b27616c", "1", "Guest", "GUEST" },
                    { "ecb7f95f-f02d-4d09-8058-3eb7f7dd00ca", "1", "Administrator", "ADMINISTRATOR" },
                    { "f030b6d9-bf9a-477a-92c8-45ed30cfc98d", "1", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "About", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "99d0946e-8985-4edd-9c5f-05c17cf71cca", null, 0, "0996a1b3-b415-4830-b7c5-b777ed80abb0", "admin@example.local", false, false, null, "ADMIN@EXAMPLE.LOCAL", "ADMIN", "AQAAAAEAACcQAAAAEHcnJe+yZ9BMU/ZP+V42eQaJYhEMQw4gKoLXDQFEHKcwhElL+c2NC7MkZJu2onNIdw==", null, false, "cd041c92-5e30-46e2-9011-70f9b36de8fe", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "ecb7f95f-f02d-4d09-8058-3eb7f7dd00ca", "99d0946e-8985-4edd-9c5f-05c17cf71cca" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "190fad51-4e7c-463e-a10a-64c7515b060b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5f1e45c8-99df-431e-86c1-88b81269c7ae");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c5986e89-7979-4a5f-aa12-9cb34b27616c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f030b6d9-bf9a-477a-92c8-45ed30cfc98d");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ecb7f95f-f02d-4d09-8058-3eb7f7dd00ca", "99d0946e-8985-4edd-9c5f-05c17cf71cca" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ecb7f95f-f02d-4d09-8058-3eb7f7dd00ca");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "99d0946e-8985-4edd-9c5f-05c17cf71cca");

            migrationBuilder.CreateTable(
                name: "ImageEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MediaId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatorUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    From = table.Column<string>(type: "text", nullable: false),
                    IsAcceptProposal = table.Column<bool>(type: "boolean", nullable: true),
                    IsHidden = table.Column<bool>(type: "boolean", nullable: false),
                    IsMain = table.Column<bool>(type: "boolean", nullable: false),
                    IsOriginal = table.Column<bool>(type: "boolean", nullable: false),
                    Language = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Large = table.Column<string>(type: "text", nullable: true),
                    Medium = table.Column<string>(type: "text", nullable: true),
                    Original = table.Column<string>(type: "text", nullable: false),
                    Small = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TextVariantSubItemEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MediaId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatorUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    From = table.Column<string>(type: "text", nullable: false),
                    IsAcceptProposal = table.Column<bool>(type: "boolean", nullable: true),
                    IsHidden = table.Column<bool>(type: "boolean", nullable: false),
                    IsMain = table.Column<bool>(type: "boolean", nullable: false),
                    IsOriginal = table.Column<bool>(type: "boolean", nullable: false),
                    Language = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Body = table.Column<string>(type: "text", nullable: false),
                    LanguageDetectionBySystem = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TextVariantSubItemEntity", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "10c15deb-373e-414c-a881-5fdc2f245ada", "1", "User", "USER" },
                    { "3ddf9278-6638-430f-bee0-bd77bdc413e6", "1", "Creator", "CREATOR" },
                    { "45a820a6-5949-43c0-af92-84143c46c99d", "1", "Administrator", "ADMINISTRATOR" },
                    { "5693508c-3dda-4251-8144-d57e43fb27dc", "1", "Moderator", "MODERATOR" },
                    { "dc1259ec-d977-432d-8bac-bcdcae517fa6", "1", "Guest", "GUEST" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "About", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "459c2d6b-f289-4639-96ab-ac963e95dc3c", null, 0, "732f9512-2f22-4a94-876b-4d4f24057590", "admin@example.local", false, false, null, "ADMIN@EXAMPLE.LOCAL", "ADMIN", "AQAAAAEAACcQAAAAEHcnJe+yZ9BMU/ZP+V42eQaJYhEMQw4gKoLXDQFEHKcwhElL+c2NC7MkZJu2onNIdw==", null, false, "e5cd62bf-d5f0-436a-b5e8-99cf5dcac0b1", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "45a820a6-5949-43c0-af92-84143c46c99d", "459c2d6b-f289-4639-96ab-ac963e95dc3c" });
        }
    }
}
