using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NekoSpace.API.Migrations
{
    public partial class AddHidenColumnToAnimeTitleAandSynopsis : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1e651010-017d-41aa-879b-e34b1c162bc2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3f3560f5-7832-4ae5-8aaa-ce842f034163");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "70eccf39-dee5-4d9a-a0ae-d79cb500d9d7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8a8b95ac-eb6f-4f07-bc57-0bd2f863839c");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c233bc2b-8667-4172-8d08-7ca08092e289", "7df613a5-3027-4d55-8f3c-2b2a2a31fb12" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c233bc2b-8667-4172-8d08-7ca08092e289");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7df613a5-3027-4d55-8f3c-2b2a2a31fb12");

            migrationBuilder.AddColumn<bool>(
                name: "IsHidden",
                table: "AnimeTitle",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHidden",
                table: "AnimeSynopsis",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "06c1f246-aca7-41fe-a784-60dc402f0cb5", "1", "Moderator", "MODERATOR" },
                    { "13afc6d7-1a2a-4f75-893b-0d67c6edc17d", "1", "User", "USER" },
                    { "1f58423c-19cc-4128-b1e2-fadce0ddd2c0", "1", "Creator", "CREATOR" },
                    { "55b3e1ff-6b00-48ec-9569-138766573d84", "1", "Guest", "GUEST" },
                    { "b2f23a80-fccf-469f-8870-0ccacac71228", "1", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "About", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "a48f5e56-e445-40a2-91b3-df75b63cf306", null, 0, "ceb39c68-ae4e-423b-8cfb-2afd8ead4a25", "admin@example.local", false, false, null, "ADMIN@EXAMPLE.LOCAL", "ADMIN", "AQAAAAEAACcQAAAAEHcnJe+yZ9BMU/ZP+V42eQaJYhEMQw4gKoLXDQFEHKcwhElL+c2NC7MkZJu2onNIdw==", null, false, "50d8e8c6-fce1-4ecc-b234-d64616529637", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "b2f23a80-fccf-469f-8870-0ccacac71228", "a48f5e56-e445-40a2-91b3-df75b63cf306" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "06c1f246-aca7-41fe-a784-60dc402f0cb5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "13afc6d7-1a2a-4f75-893b-0d67c6edc17d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1f58423c-19cc-4128-b1e2-fadce0ddd2c0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "55b3e1ff-6b00-48ec-9569-138766573d84");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b2f23a80-fccf-469f-8870-0ccacac71228", "a48f5e56-e445-40a2-91b3-df75b63cf306" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b2f23a80-fccf-469f-8870-0ccacac71228");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a48f5e56-e445-40a2-91b3-df75b63cf306");

            migrationBuilder.DropColumn(
                name: "IsHidden",
                table: "AnimeTitle");

            migrationBuilder.DropColumn(
                name: "IsHidden",
                table: "AnimeSynopsis");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1e651010-017d-41aa-879b-e34b1c162bc2", "1", "User", "User" },
                    { "3f3560f5-7832-4ae5-8aaa-ce842f034163", "1", "Guest", "Guest" },
                    { "70eccf39-dee5-4d9a-a0ae-d79cb500d9d7", "1", "Creator", "Creator" },
                    { "8a8b95ac-eb6f-4f07-bc57-0bd2f863839c", "1", "Moderator", "Moderator" },
                    { "c233bc2b-8667-4172-8d08-7ca08092e289", "1", "Administrator", "Administrator" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "About", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "7df613a5-3027-4d55-8f3c-2b2a2a31fb12", null, 0, "c8257901-f978-4a01-9aa4-4a91661c21fe", "admin@example.local", false, false, null, null, null, null, null, false, "00ea5660-85d0-4296-b155-291b0d5798d1", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "c233bc2b-8667-4172-8d08-7ca08092e289", "7df613a5-3027-4d55-8f3c-2b2a2a31fb12" });
        }
    }
}
