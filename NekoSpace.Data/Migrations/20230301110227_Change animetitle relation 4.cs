using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NekoSpace.Data.Migrations
{
    /// <inheritdoc />
    public partial class Changeanimetitlerelation4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnimeSynopsis_Animes_AnimeId",
                table: "AnimeSynopsis");

            migrationBuilder.DropIndex(
                name: "IX_AnimeSynopsis_AnimeId",
                table: "AnimeSynopsis");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "267eb2ce-8783-4538-a076-373f69fdc718");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "89e8cbc2-5620-4d5c-88e2-f198c4fc7b9d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b0e1039b-64a6-458a-827e-73f96c87c7c4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c48f83fc-055a-4a5f-8ea9-58399d6553f0");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "cb987bdf-85bb-4bfc-89aa-bec9da3d83d5", "80420176-0e43-4dc7-ab60-7b09ccf8e66e" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cb987bdf-85bb-4bfc-89aa-bec9da3d83d5");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80420176-0e43-4dc7-ab60-7b09ccf8e66e");

            migrationBuilder.DropColumn(
                name: "AnimeId",
                table: "AnimeTitle");

            migrationBuilder.DropColumn(
                name: "AnimeId",
                table: "AnimeSynopsis");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0096bade-b080-4baf-905d-c2e2b24596fa", "1", "User", "USER" },
                    { "37894077-ac89-4f9f-9966-6d1072db18a7", "1", "Administrator", "ADMINISTRATOR" },
                    { "a59c52cc-9cbc-45c9-a13b-573894c5fbf0", "1", "Guest", "GUEST" },
                    { "c232d302-3578-43e5-8638-44ed266eaf11", "1", "Moderator", "MODERATOR" },
                    { "c47fb939-c5ab-4043-b58c-e53c0e689912", "1", "Creator", "CREATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "About", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "28423c0c-e4d2-4e6e-a36b-9f8e6400948c", null, 0, "e4e1a6b2-720f-4359-bba9-d8d93441c772", "admin@example.local", false, false, null, "ADMIN@EXAMPLE.LOCAL", "ADMIN", "AQAAAAEAACcQAAAAEHcnJe+yZ9BMU/ZP+V42eQaJYhEMQw4gKoLXDQFEHKcwhElL+c2NC7MkZJu2onNIdw==", null, false, "7f3fed08-f6e7-4d44-b6a4-68c36e3d372e", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "37894077-ac89-4f9f-9966-6d1072db18a7", "28423c0c-e4d2-4e6e-a36b-9f8e6400948c" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0096bade-b080-4baf-905d-c2e2b24596fa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a59c52cc-9cbc-45c9-a13b-573894c5fbf0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c232d302-3578-43e5-8638-44ed266eaf11");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c47fb939-c5ab-4043-b58c-e53c0e689912");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "37894077-ac89-4f9f-9966-6d1072db18a7", "28423c0c-e4d2-4e6e-a36b-9f8e6400948c" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "37894077-ac89-4f9f-9966-6d1072db18a7");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "28423c0c-e4d2-4e6e-a36b-9f8e6400948c");

            migrationBuilder.AddColumn<Guid>(
                name: "AnimeId",
                table: "AnimeTitle",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "AnimeId",
                table: "AnimeSynopsis",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "267eb2ce-8783-4538-a076-373f69fdc718", "1", "Creator", "CREATOR" },
                    { "89e8cbc2-5620-4d5c-88e2-f198c4fc7b9d", "1", "Moderator", "MODERATOR" },
                    { "b0e1039b-64a6-458a-827e-73f96c87c7c4", "1", "Guest", "GUEST" },
                    { "c48f83fc-055a-4a5f-8ea9-58399d6553f0", "1", "User", "USER" },
                    { "cb987bdf-85bb-4bfc-89aa-bec9da3d83d5", "1", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "About", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "80420176-0e43-4dc7-ab60-7b09ccf8e66e", null, 0, "e44fb9b0-7c28-437a-9586-cfd664a7d5cb", "admin@example.local", false, false, null, "ADMIN@EXAMPLE.LOCAL", "ADMIN", "AQAAAAEAACcQAAAAEHcnJe+yZ9BMU/ZP+V42eQaJYhEMQw4gKoLXDQFEHKcwhElL+c2NC7MkZJu2onNIdw==", null, false, "e38bd1bb-5293-4b93-9c8f-59257fe8677e", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "cb987bdf-85bb-4bfc-89aa-bec9da3d83d5", "80420176-0e43-4dc7-ab60-7b09ccf8e66e" });

            migrationBuilder.CreateIndex(
                name: "IX_AnimeSynopsis_AnimeId",
                table: "AnimeSynopsis",
                column: "AnimeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AnimeSynopsis_Animes_AnimeId",
                table: "AnimeSynopsis",
                column: "AnimeId",
                principalTable: "Animes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
