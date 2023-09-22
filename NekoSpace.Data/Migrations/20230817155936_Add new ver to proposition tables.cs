using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NekoSpace.Data.Migrations
{
    /// <inheritdoc />
    public partial class Addnewvertopropositiontables : Migration
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
                keyValue: "1a5332a4-6ba8-4d04-b619-61ed5eeb3dd9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "98baf236-a302-4cbd-bd40-68abb231f98a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a2ee6b10-b106-4f82-9836-db2f13ec254c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ff000b89-9d59-4938-879a-7e06f94146e3");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "8ecb9063-021c-4d1c-bc05-9e59288f3ba5", "da235766-308e-4bf8-8966-e6d57c8cd3ac" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8ecb9063-021c-4d1c-bc05-9e59288f3ba5");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "da235766-308e-4bf8-8966-e6d57c8cd3ac");

            migrationBuilder.AddColumn<Guid>(
                name: "AcceptOfferUserId",
                table: "MediaTitles",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "MediaTitles",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "AcceptOfferUserId",
                table: "MediaSynopsis",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "MediaSynopsis",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "AcceptOfferUserId",
                table: "MediaPosters",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "MediaPosters",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "AcceptOfferUserId",
                table: "MediaCovers",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "MediaCovers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "AcceptOfferUserId",
                table: "CharacterTitles",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "CharacterTitles",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "AcceptOfferUserId",
                table: "CharacterNames",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "CharacterNames",
                type: "text",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "09d9f372-65a9-410a-ac2c-aafb685b27a9", "1", "Creator", "CREATOR" },
                    { "ba1a8443-a50a-4913-b01e-14278d329179", "1", "Administrator", "ADMINISTRATOR" },
                    { "c2df6333-b40f-4778-a5be-08ed4b012381", "1", "Guest", "GUEST" },
                    { "cd35aaa5-b190-4475-8089-1f9279189252", "1", "User", "USER" },
                    { "dc2306e6-c20b-42bf-923d-34cc0a5f1a25", "1", "Moderator", "MODERATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "About", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "c1fd55dc-64ff-4f3e-ab68-316264302441", null, 0, "8c8ec7e5-305e-4c79-b50c-a6ba944578a0", "admin@example.local", false, false, null, "ADMIN@EXAMPLE.LOCAL", "ADMIN", "AQAAAAEAACcQAAAAEHcnJe+yZ9BMU/ZP+V42eQaJYhEMQw4gKoLXDQFEHKcwhElL+c2NC7MkZJu2onNIdw==", null, false, "4c38ab14-f886-4c25-a975-93cac9709896", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "ba1a8443-a50a-4913-b01e-14278d329179", "c1fd55dc-64ff-4f3e-ab68-316264302441" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "09d9f372-65a9-410a-ac2c-aafb685b27a9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c2df6333-b40f-4778-a5be-08ed4b012381");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cd35aaa5-b190-4475-8089-1f9279189252");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dc2306e6-c20b-42bf-923d-34cc0a5f1a25");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ba1a8443-a50a-4913-b01e-14278d329179", "c1fd55dc-64ff-4f3e-ab68-316264302441" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ba1a8443-a50a-4913-b01e-14278d329179");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c1fd55dc-64ff-4f3e-ab68-316264302441");

            migrationBuilder.DropColumn(
                name: "AcceptOfferUserId",
                table: "MediaTitles");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "MediaTitles");

            migrationBuilder.DropColumn(
                name: "AcceptOfferUserId",
                table: "MediaSynopsis");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "MediaSynopsis");

            migrationBuilder.DropColumn(
                name: "AcceptOfferUserId",
                table: "MediaPosters");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "MediaPosters");

            migrationBuilder.DropColumn(
                name: "AcceptOfferUserId",
                table: "MediaCovers");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "MediaCovers");

            migrationBuilder.DropColumn(
                name: "AcceptOfferUserId",
                table: "CharacterTitles");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "CharacterTitles");

            migrationBuilder.DropColumn(
                name: "AcceptOfferUserId",
                table: "CharacterNames");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "CharacterNames");

            migrationBuilder.CreateTable(
                name: "ImageEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MediaId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatorUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    From = table.Column<int>(type: "integer", nullable: false),
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
                    From = table.Column<int>(type: "integer", nullable: false),
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
                    { "1a5332a4-6ba8-4d04-b619-61ed5eeb3dd9", "1", "Moderator", "MODERATOR" },
                    { "8ecb9063-021c-4d1c-bc05-9e59288f3ba5", "1", "Administrator", "ADMINISTRATOR" },
                    { "98baf236-a302-4cbd-bd40-68abb231f98a", "1", "Creator", "CREATOR" },
                    { "a2ee6b10-b106-4f82-9836-db2f13ec254c", "1", "User", "USER" },
                    { "ff000b89-9d59-4938-879a-7e06f94146e3", "1", "Guest", "GUEST" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "About", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "da235766-308e-4bf8-8966-e6d57c8cd3ac", null, 0, "ee87a502-f3e3-485a-84ca-0f73515e3617", "admin@example.local", false, false, null, "ADMIN@EXAMPLE.LOCAL", "ADMIN", "AQAAAAEAACcQAAAAEHcnJe+yZ9BMU/ZP+V42eQaJYhEMQw4gKoLXDQFEHKcwhElL+c2NC7MkZJu2onNIdw==", null, false, "8897024b-a3ec-4f47-aaa3-b5dee12a50be", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "8ecb9063-021c-4d1c-bc05-9e59288f3ba5", "da235766-308e-4bf8-8966-e6d57c8cd3ac" });
        }
    }
}
