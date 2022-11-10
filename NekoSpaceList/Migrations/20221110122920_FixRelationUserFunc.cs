using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NekoSpace.API.Migrations
{
    public partial class FixRelationUserFunc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserFavoriteAnime",
                table: "UserFavoriteAnime");

            migrationBuilder.DropIndex(
                name: "IX_UserFavoriteAnime_UserId",
                table: "UserFavoriteAnime");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "260d8484-a9fd-4eda-a878-7cc16c0ee0f4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e14d2970-d835-4340-acd0-62d0936d448c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fb881781-a6d2-41ec-b05c-152175b218c8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fdad698b-3bfb-42e0-9c09-8cb6de811f92");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "420a0525-0618-4ed6-8931-901ab706b66d", "951ade4a-9c51-4060-b976-78bb25c0cd72" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "420a0525-0618-4ed6-8931-901ab706b66d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "951ade4a-9c51-4060-b976-78bb25c0cd72");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserFavoriteAnime");

            migrationBuilder.RenameColumn(
                name: "Rating",
                table: "UserRatingAnime",
                newName: "RatingValue");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserFavoriteAnime",
                table: "UserFavoriteAnime",
                columns: new[] { "UserId", "AnimeId" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4b09195f-a423-48ff-8979-82f7469375a9", "1", "Administrator", "ADMINISTRATOR" },
                    { "7cc7d07b-20b3-4229-b205-244b1876e96b", "1", "Guest", "GUEST" },
                    { "919ef74c-63d2-4f0b-8f4c-0bcdb80720cf", "1", "Moderator", "MODERATOR" },
                    { "e8035066-74b6-41e3-8851-451a3c6ed9e1", "1", "User", "USER" },
                    { "f5b11b2b-6b50-4b70-840c-fdfe8ee852d8", "1", "Creator", "CREATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "About", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "4ae9bd33-0bad-44ef-ab09-50cca47ee099", null, 0, "9ee9012d-bf3a-44a6-b8ea-3ba51b54d36d", "admin@example.local", false, false, null, "ADMIN@EXAMPLE.LOCAL", "ADMIN", "AQAAAAEAACcQAAAAEHcnJe+yZ9BMU/ZP+V42eQaJYhEMQw4gKoLXDQFEHKcwhElL+c2NC7MkZJu2onNIdw==", null, false, "eb1abba6-cc65-40ee-b714-59795b4a3221", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "4b09195f-a423-48ff-8979-82f7469375a9", "4ae9bd33-0bad-44ef-ab09-50cca47ee099" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserFavoriteAnime",
                table: "UserFavoriteAnime");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7cc7d07b-20b3-4229-b205-244b1876e96b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "919ef74c-63d2-4f0b-8f4c-0bcdb80720cf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e8035066-74b6-41e3-8851-451a3c6ed9e1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f5b11b2b-6b50-4b70-840c-fdfe8ee852d8");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "4b09195f-a423-48ff-8979-82f7469375a9", "4ae9bd33-0bad-44ef-ab09-50cca47ee099" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4b09195f-a423-48ff-8979-82f7469375a9");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4ae9bd33-0bad-44ef-ab09-50cca47ee099");

            migrationBuilder.RenameColumn(
                name: "RatingValue",
                table: "UserRatingAnime",
                newName: "Rating");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "UserFavoriteAnime",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserFavoriteAnime",
                table: "UserFavoriteAnime",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "260d8484-a9fd-4eda-a878-7cc16c0ee0f4", "1", "Creator", "CREATOR" },
                    { "420a0525-0618-4ed6-8931-901ab706b66d", "1", "Administrator", "ADMINISTRATOR" },
                    { "e14d2970-d835-4340-acd0-62d0936d448c", "1", "Guest", "GUEST" },
                    { "fb881781-a6d2-41ec-b05c-152175b218c8", "1", "User", "USER" },
                    { "fdad698b-3bfb-42e0-9c09-8cb6de811f92", "1", "Moderator", "MODERATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "About", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "951ade4a-9c51-4060-b976-78bb25c0cd72", null, 0, "37d0ae44-9243-404c-9e4a-86c5254e8831", "admin@example.local", false, false, null, "ADMIN@EXAMPLE.LOCAL", "ADMIN", "AQAAAAEAACcQAAAAEHcnJe+yZ9BMU/ZP+V42eQaJYhEMQw4gKoLXDQFEHKcwhElL+c2NC7MkZJu2onNIdw==", null, false, "b0f98817-df93-4a1c-8ca6-05621562b701", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "420a0525-0618-4ed6-8931-901ab706b66d", "951ade4a-9c51-4060-b976-78bb25c0cd72" });

            migrationBuilder.CreateIndex(
                name: "IX_UserFavoriteAnime_UserId",
                table: "UserFavoriteAnime",
                column: "UserId");
        }
    }
}
