using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NekoSpace.Data.Migrations
{
    /// <inheritdoc />
    public partial class Changeanimetitlerelation6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7deeae8b-01d9-45c8-80eb-885f93559895");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cb0f73f9-683d-46ee-82bf-e3baf32ba108");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cdb992b4-6861-44b6-a2a2-c7ca6a31f4fc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f139609b-2598-43e9-bc2c-bfe1cade0a53");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c22a01e9-392a-4f05-b1a8-b9c7003ebd1c", "3036207b-14ce-430f-a70f-d6ab9dfe5a22" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c22a01e9-392a-4f05-b1a8-b9c7003ebd1c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3036207b-14ce-430f-a70f-d6ab9dfe5a22");

            migrationBuilder.AddColumn<Guid>(
                name: "AnimeId",
                table: "AnimeTitle",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "469954fb-6512-4f92-aa33-f76d97b0ee5d", "1", "Guest", "GUEST" },
                    { "68bbe165-36fa-4dae-a2e9-a5c1ddfe1388", "1", "Moderator", "MODERATOR" },
                    { "9aa27c67-8a59-4447-995b-77352f0eeabe", "1", "Administrator", "ADMINISTRATOR" },
                    { "acdda606-08db-49c5-a1e1-8aacbed774df", "1", "User", "USER" },
                    { "f309b6cf-c2ab-47df-b86e-a35bbe0e5b59", "1", "Creator", "CREATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "About", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "7b87a7a9-4a30-4748-864f-f9f300c44ffd", null, 0, "5594bc2d-d64a-4506-920d-b6da9a0deea2", "admin@example.local", false, false, null, "ADMIN@EXAMPLE.LOCAL", "ADMIN", "AQAAAAEAACcQAAAAEHcnJe+yZ9BMU/ZP+V42eQaJYhEMQw4gKoLXDQFEHKcwhElL+c2NC7MkZJu2onNIdw==", null, false, "a222594e-e64b-4662-83cc-2171532155d4", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "9aa27c67-8a59-4447-995b-77352f0eeabe", "7b87a7a9-4a30-4748-864f-f9f300c44ffd" });

            migrationBuilder.CreateIndex(
                name: "IX_AnimeTitle_AnimeId",
                table: "AnimeTitle",
                column: "AnimeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AnimeTitle_Animes_AnimeId",
                table: "AnimeTitle",
                column: "AnimeId",
                principalTable: "Animes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnimeTitle_Animes_AnimeId",
                table: "AnimeTitle");

            migrationBuilder.DropIndex(
                name: "IX_AnimeTitle_AnimeId",
                table: "AnimeTitle");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "469954fb-6512-4f92-aa33-f76d97b0ee5d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "68bbe165-36fa-4dae-a2e9-a5c1ddfe1388");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "acdda606-08db-49c5-a1e1-8aacbed774df");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f309b6cf-c2ab-47df-b86e-a35bbe0e5b59");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "9aa27c67-8a59-4447-995b-77352f0eeabe", "7b87a7a9-4a30-4748-864f-f9f300c44ffd" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9aa27c67-8a59-4447-995b-77352f0eeabe");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7b87a7a9-4a30-4748-864f-f9f300c44ffd");

            migrationBuilder.DropColumn(
                name: "AnimeId",
                table: "AnimeTitle");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7deeae8b-01d9-45c8-80eb-885f93559895", "1", "Guest", "GUEST" },
                    { "c22a01e9-392a-4f05-b1a8-b9c7003ebd1c", "1", "Administrator", "ADMINISTRATOR" },
                    { "cb0f73f9-683d-46ee-82bf-e3baf32ba108", "1", "Moderator", "MODERATOR" },
                    { "cdb992b4-6861-44b6-a2a2-c7ca6a31f4fc", "1", "Creator", "CREATOR" },
                    { "f139609b-2598-43e9-bc2c-bfe1cade0a53", "1", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "About", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "3036207b-14ce-430f-a70f-d6ab9dfe5a22", null, 0, "394cbad4-fd32-490e-8a35-c5333f2f6da7", "admin@example.local", false, false, null, "ADMIN@EXAMPLE.LOCAL", "ADMIN", "AQAAAAEAACcQAAAAEHcnJe+yZ9BMU/ZP+V42eQaJYhEMQw4gKoLXDQFEHKcwhElL+c2NC7MkZJu2onNIdw==", null, false, "9dbc0ce6-fc67-4bce-bd4a-2af056ef3371", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "c22a01e9-392a-4f05-b1a8-b9c7003ebd1c", "3036207b-14ce-430f-a70f-d6ab9dfe5a22" });
        }
    }
}
