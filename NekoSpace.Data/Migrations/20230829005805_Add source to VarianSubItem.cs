using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NekoSpace.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddsourcetoVarianSubItem : Migration
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
                keyValue: "18fad7af-1679-4e5c-931d-5034d677099a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "216e305b-9624-411a-8393-d20a2a4d19dd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "53e0e4c8-b3fd-4f7f-a275-aa67cf5ecb33");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c29ebbbd-a470-4791-bafa-ea1b18f84243");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "7d782e39-d9c0-47f7-b641-6f49a20cfe77", "344cacc1-9f8a-4a20-b9c0-597454dcac19" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7d782e39-d9c0-47f7-b641-6f49a20cfe77");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "344cacc1-9f8a-4a20-b9c0-597454dcac19");

            migrationBuilder.AddColumn<string>(
                name: "SourceName",
                table: "MediaTitles",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SourceUrl",
                table: "MediaTitles",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SourceName",
                table: "MediaSynopsis",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SourceUrl",
                table: "MediaSynopsis",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SourceName",
                table: "MediaPosters",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SourceUrl",
                table: "MediaPosters",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SourceName",
                table: "MediaCovers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SourceUrl",
                table: "MediaCovers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SourceName",
                table: "CharacterTitles",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SourceUrl",
                table: "CharacterTitles",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SourceName",
                table: "CharacterNames",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SourceUrl",
                table: "CharacterNames",
                type: "text",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "02266f8d-7dac-470f-a65d-df81c117a5de", "1", "Administrator", "ADMINISTRATOR" },
                    { "1e7afb9f-d83a-4b56-bf85-7f88f1cf4b7f", "1", "Creator", "CREATOR" },
                    { "c03edc51-521f-4219-aeed-10c50a6f9af3", "1", "Moderator", "MODERATOR" },
                    { "dbc1cb2d-4cb1-4502-b6cc-56ab1423b7d0", "1", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "About", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "d6070a05-591c-4ffb-b336-d869730aff74", null, 0, "d9c74b8f-e495-484d-ae46-ab0ad0137875", "admin@example.local", false, false, null, "ADMIN@EXAMPLE.LOCAL", "ADMIN", "AQAAAAEAACcQAAAAEHcnJe+yZ9BMU/ZP+V42eQaJYhEMQw4gKoLXDQFEHKcwhElL+c2NC7MkZJu2onNIdw==", null, false, "ea578983-573e-4522-a310-d4839c020340", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "02266f8d-7dac-470f-a65d-df81c117a5de", "d6070a05-591c-4ffb-b336-d869730aff74" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1e7afb9f-d83a-4b56-bf85-7f88f1cf4b7f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c03edc51-521f-4219-aeed-10c50a6f9af3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dbc1cb2d-4cb1-4502-b6cc-56ab1423b7d0");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "02266f8d-7dac-470f-a65d-df81c117a5de", "d6070a05-591c-4ffb-b336-d869730aff74" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "02266f8d-7dac-470f-a65d-df81c117a5de");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d6070a05-591c-4ffb-b336-d869730aff74");

            migrationBuilder.DropColumn(
                name: "SourceName",
                table: "MediaTitles");

            migrationBuilder.DropColumn(
                name: "SourceUrl",
                table: "MediaTitles");

            migrationBuilder.DropColumn(
                name: "SourceName",
                table: "MediaSynopsis");

            migrationBuilder.DropColumn(
                name: "SourceUrl",
                table: "MediaSynopsis");

            migrationBuilder.DropColumn(
                name: "SourceName",
                table: "MediaPosters");

            migrationBuilder.DropColumn(
                name: "SourceUrl",
                table: "MediaPosters");

            migrationBuilder.DropColumn(
                name: "SourceName",
                table: "MediaCovers");

            migrationBuilder.DropColumn(
                name: "SourceUrl",
                table: "MediaCovers");

            migrationBuilder.DropColumn(
                name: "SourceName",
                table: "CharacterTitles");

            migrationBuilder.DropColumn(
                name: "SourceUrl",
                table: "CharacterTitles");

            migrationBuilder.DropColumn(
                name: "SourceName",
                table: "CharacterNames");

            migrationBuilder.DropColumn(
                name: "SourceUrl",
                table: "CharacterNames");

            migrationBuilder.CreateTable(
                name: "ImageEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatorUserId = table.Column<string>(type: "text", nullable: true),
                    MediaId = table.Column<Guid>(type: "uuid", nullable: false),
                    AcceptOfferUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    From = table.Column<int>(type: "integer", nullable: false),
                    IsAcceptProposal = table.Column<bool>(type: "boolean", nullable: true),
                    IsHidden = table.Column<bool>(type: "boolean", nullable: false),
                    IsMain = table.Column<bool>(type: "boolean", nullable: false),
                    IsOriginal = table.Column<bool>(type: "boolean", nullable: false),
                    Language = table.Column<string>(type: "text", nullable: true),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Large = table.Column<string>(type: "text", nullable: true),
                    Medium = table.Column<string>(type: "text", nullable: true),
                    Original = table.Column<string>(type: "text", nullable: false),
                    Small = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImageEntity_AspNetUsers_CreatorUserId",
                        column: x => x.CreatorUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TextVariantSubItemEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatorUserId = table.Column<string>(type: "text", nullable: true),
                    MediaId = table.Column<Guid>(type: "uuid", nullable: false),
                    AcceptOfferUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    From = table.Column<int>(type: "integer", nullable: false),
                    IsAcceptProposal = table.Column<bool>(type: "boolean", nullable: true),
                    IsHidden = table.Column<bool>(type: "boolean", nullable: false),
                    IsMain = table.Column<bool>(type: "boolean", nullable: false),
                    IsOriginal = table.Column<bool>(type: "boolean", nullable: false),
                    Language = table.Column<string>(type: "text", nullable: true),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Body = table.Column<string>(type: "text", nullable: false),
                    LanguageDetectionBySystem = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TextVariantSubItemEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TextVariantSubItemEntity_AspNetUsers_CreatorUserId",
                        column: x => x.CreatorUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "18fad7af-1679-4e5c-931d-5034d677099a", "1", "Moderator", "MODERATOR" },
                    { "216e305b-9624-411a-8393-d20a2a4d19dd", "1", "User", "USER" },
                    { "53e0e4c8-b3fd-4f7f-a275-aa67cf5ecb33", "1", "Guest", "GUEST" },
                    { "7d782e39-d9c0-47f7-b641-6f49a20cfe77", "1", "Administrator", "ADMINISTRATOR" },
                    { "c29ebbbd-a470-4791-bafa-ea1b18f84243", "1", "Creator", "CREATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "About", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "344cacc1-9f8a-4a20-b9c0-597454dcac19", null, 0, "f6cc50eb-84ec-4265-bf50-968497a001e3", "admin@example.local", false, false, null, "ADMIN@EXAMPLE.LOCAL", "ADMIN", "AQAAAAEAACcQAAAAEHcnJe+yZ9BMU/ZP+V42eQaJYhEMQw4gKoLXDQFEHKcwhElL+c2NC7MkZJu2onNIdw==", null, false, "2cd31d3d-64d4-4c81-95cb-1bc51d1578f4", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "7d782e39-d9c0-47f7-b641-6f49a20cfe77", "344cacc1-9f8a-4a20-b9c0-597454dcac19" });

            migrationBuilder.CreateIndex(
                name: "IX_ImageEntity_CreatorUserId",
                table: "ImageEntity",
                column: "CreatorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TextVariantSubItemEntity_CreatorUserId",
                table: "TextVariantSubItemEntity",
                column: "CreatorUserId");
        }
    }
}
