using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NekoSpace.Data.Migrations
{
    /// <inheritdoc />
    public partial class Createrefreshtockenmodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImageEntity");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2e880e1d-f590-4859-a7a2-588448715256");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3243fce7-5d35-4530-a200-494e8a2a6a9b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "950ebab0-4ae7-4b6c-89b8-ff0458cf8d99");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c2f5c092-62b7-445c-a3d4-b29cfa51c050");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e9e62f05-b193-4fe9-9340-b44a79097108", "cf577178-6712-4d4d-812f-a3f86e77e645" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e9e62f05-b193-4fe9-9340-b44a79097108");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cf577178-6712-4d4d-812f-a3f86e77e645");

            migrationBuilder.RenameColumn(
                name: "Sezon",
                table: "Animes",
                newName: "Season");

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    JwtId = table.Column<Guid>(type: "uuid", nullable: false),
                    Token = table.Column<string>(type: "text", nullable: false),
                    IsUsed = table.Column<bool>(type: "boolean", nullable: false),
                    IsRevoked = table.Column<bool>(type: "boolean", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1cf2b208-da59-4870-9c1b-5fba7875e426", "1", "Guest", "GUEST" },
                    { "230c910a-1375-4711-aab4-b4680c75b91c", "1", "Moderator", "MODERATOR" },
                    { "6884685c-4bbb-4638-841f-55cc669f9a8f", "1", "Administrator", "ADMINISTRATOR" },
                    { "c3795761-3e09-4996-8014-5a9a5b262771", "1", "User", "USER" },
                    { "cfb4865e-14f6-43be-a342-b1168b56cb5e", "1", "Creator", "CREATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "About", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "85ff06e3-6b77-4bc9-b3a7-b87c62a060f7", null, 0, "df8cd461-55e1-4b20-92e7-60ef8560c8c6", "admin@example.local", false, false, null, "ADMIN@EXAMPLE.LOCAL", "ADMIN", "AQAAAAEAACcQAAAAEHcnJe+yZ9BMU/ZP+V42eQaJYhEMQw4gKoLXDQFEHKcwhElL+c2NC7MkZJu2onNIdw==", null, false, "6c5119ed-f12c-4684-b3fe-c04a1af12a58", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "6884685c-4bbb-4638-841f-55cc669f9a8f", "85ff06e3-6b77-4bc9-b3a7-b87c62a060f7" });

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_UserId",
                table: "RefreshTokens",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1cf2b208-da59-4870-9c1b-5fba7875e426");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "230c910a-1375-4711-aab4-b4680c75b91c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c3795761-3e09-4996-8014-5a9a5b262771");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cfb4865e-14f6-43be-a342-b1168b56cb5e");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "6884685c-4bbb-4638-841f-55cc669f9a8f", "85ff06e3-6b77-4bc9-b3a7-b87c62a060f7" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6884685c-4bbb-4638-841f-55cc669f9a8f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "85ff06e3-6b77-4bc9-b3a7-b87c62a060f7");

            migrationBuilder.RenameColumn(
                name: "Season",
                table: "Animes",
                newName: "Sezon");

            migrationBuilder.CreateTable(
                name: "ImageEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2e880e1d-f590-4859-a7a2-588448715256", "1", "Creator", "CREATOR" },
                    { "3243fce7-5d35-4530-a200-494e8a2a6a9b", "1", "Moderator", "MODERATOR" },
                    { "950ebab0-4ae7-4b6c-89b8-ff0458cf8d99", "1", "Guest", "GUEST" },
                    { "c2f5c092-62b7-445c-a3d4-b29cfa51c050", "1", "User", "USER" },
                    { "e9e62f05-b193-4fe9-9340-b44a79097108", "1", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "About", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "cf577178-6712-4d4d-812f-a3f86e77e645", null, 0, "3c6a1152-9374-4cb3-a2b1-64fd4659086f", "admin@example.local", false, false, null, "ADMIN@EXAMPLE.LOCAL", "ADMIN", "AQAAAAEAACcQAAAAEHcnJe+yZ9BMU/ZP+V42eQaJYhEMQw4gKoLXDQFEHKcwhElL+c2NC7MkZJu2onNIdw==", null, false, "fd548af2-b869-4977-9b24-f5b929a5a436", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "e9e62f05-b193-4fe9-9340-b44a79097108", "cf577178-6712-4d4d-812f-a3f86e77e645" });
        }
    }
}
