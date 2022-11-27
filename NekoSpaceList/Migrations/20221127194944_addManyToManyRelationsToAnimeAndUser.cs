using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NekoSpace.API.Migrations
{
    /// <inheritdoc />
    public partial class addManyToManyRelationsToAnimeAndUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRatingAnime",
                table: "UserRatingAnime");

            migrationBuilder.DropIndex(
                name: "IX_UserRatingAnime_UserId",
                table: "UserRatingAnime");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserAnimeViewingStatus",
                table: "UserAnimeViewingStatus");

            migrationBuilder.DropIndex(
                name: "IX_UserAnimeViewingStatus_UserId",
                table: "UserAnimeViewingStatus");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a4601ac0-3b6d-4061-9a0c-422a5c5c8cee");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c28c83af-4527-46fb-b87a-e5c0ee9fc157");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e80561c2-fccf-44f4-8de2-1ed626a21615");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f6df8551-0db6-4260-82b0-fcd793802c6c");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "a472c44f-3447-4fd5-b1a2-3c4f388a89a8", "4a499c85-0d86-42c2-81e6-e3f03dabe1ca" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a472c44f-3447-4fd5-b1a2-3c4f388a89a8");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4a499c85-0d86-42c2-81e6-e3f03dabe1ca");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserRatingAnime");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserAnimeViewingStatus");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRatingAnime",
                table: "UserRatingAnime",
                columns: new[] { "UserId", "AnimeId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserAnimeViewingStatus",
                table: "UserAnimeViewingStatus",
                columns: new[] { "UserId", "AnimeId" });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRatingAnime",
                table: "UserRatingAnime");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserAnimeViewingStatus",
                table: "UserAnimeViewingStatus");

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

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "UserRatingAnime",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "UserAnimeViewingStatus",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRatingAnime",
                table: "UserRatingAnime",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserAnimeViewingStatus",
                table: "UserAnimeViewingStatus",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a4601ac0-3b6d-4061-9a0c-422a5c5c8cee", "1", "Guest", "GUEST" },
                    { "a472c44f-3447-4fd5-b1a2-3c4f388a89a8", "1", "Administrator", "ADMINISTRATOR" },
                    { "c28c83af-4527-46fb-b87a-e5c0ee9fc157", "1", "Moderator", "MODERATOR" },
                    { "e80561c2-fccf-44f4-8de2-1ed626a21615", "1", "Creator", "CREATOR" },
                    { "f6df8551-0db6-4260-82b0-fcd793802c6c", "1", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "About", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "4a499c85-0d86-42c2-81e6-e3f03dabe1ca", null, 0, "6a12ad59-41d2-4a53-9418-d3004c4135a5", "admin@example.local", false, false, null, "ADMIN@EXAMPLE.LOCAL", "ADMIN", "AQAAAAEAACcQAAAAEHcnJe+yZ9BMU/ZP+V42eQaJYhEMQw4gKoLXDQFEHKcwhElL+c2NC7MkZJu2onNIdw==", null, false, "fc8bab89-be7b-4989-92b2-39f5a11e45a2", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "a472c44f-3447-4fd5-b1a2-3c4f388a89a8", "4a499c85-0d86-42c2-81e6-e3f03dabe1ca" });

            migrationBuilder.CreateIndex(
                name: "IX_UserRatingAnime_UserId",
                table: "UserRatingAnime",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAnimeViewingStatus_UserId",
                table: "UserAnimeViewingStatus",
                column: "UserId");
        }
    }
}
