using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NekoSpace.Data.Migrations
{
    /// <inheritdoc />
    public partial class Addnewcoonectionbetwpropositiontableanduser : Migration
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

            migrationBuilder.AlterColumn<string>(
                name: "CreatorUserId",
                table: "MediaTitles",
                type: "text",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatorUserId",
                table: "MediaSynopsis",
                type: "text",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatorUserId",
                table: "MediaPosters",
                type: "text",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatorUserId",
                table: "MediaCovers",
                type: "text",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatorUserId",
                table: "CharacterTitles",
                type: "text",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatorUserId",
                table: "CharacterNames",
                type: "text",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

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
                name: "IX_MediaTitles_CreatorUserId",
                table: "MediaTitles",
                column: "CreatorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaSynopsis_CreatorUserId",
                table: "MediaSynopsis",
                column: "CreatorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaPosters_CreatorUserId",
                table: "MediaPosters",
                column: "CreatorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaCovers_CreatorUserId",
                table: "MediaCovers",
                column: "CreatorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterTitles_CreatorUserId",
                table: "CharacterTitles",
                column: "CreatorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterNames_CreatorUserId",
                table: "CharacterNames",
                column: "CreatorUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterNames_AspNetUsers_CreatorUserId",
                table: "CharacterNames",
                column: "CreatorUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterTitles_AspNetUsers_CreatorUserId",
                table: "CharacterTitles",
                column: "CreatorUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MediaCovers_AspNetUsers_CreatorUserId",
                table: "MediaCovers",
                column: "CreatorUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MediaPosters_AspNetUsers_CreatorUserId",
                table: "MediaPosters",
                column: "CreatorUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MediaSynopsis_AspNetUsers_CreatorUserId",
                table: "MediaSynopsis",
                column: "CreatorUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MediaTitles_AspNetUsers_CreatorUserId",
                table: "MediaTitles",
                column: "CreatorUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharacterNames_AspNetUsers_CreatorUserId",
                table: "CharacterNames");

            migrationBuilder.DropForeignKey(
                name: "FK_CharacterTitles_AspNetUsers_CreatorUserId",
                table: "CharacterTitles");

            migrationBuilder.DropForeignKey(
                name: "FK_MediaCovers_AspNetUsers_CreatorUserId",
                table: "MediaCovers");

            migrationBuilder.DropForeignKey(
                name: "FK_MediaPosters_AspNetUsers_CreatorUserId",
                table: "MediaPosters");

            migrationBuilder.DropForeignKey(
                name: "FK_MediaSynopsis_AspNetUsers_CreatorUserId",
                table: "MediaSynopsis");

            migrationBuilder.DropForeignKey(
                name: "FK_MediaTitles_AspNetUsers_CreatorUserId",
                table: "MediaTitles");

            migrationBuilder.DropIndex(
                name: "IX_MediaTitles_CreatorUserId",
                table: "MediaTitles");

            migrationBuilder.DropIndex(
                name: "IX_MediaSynopsis_CreatorUserId",
                table: "MediaSynopsis");

            migrationBuilder.DropIndex(
                name: "IX_MediaPosters_CreatorUserId",
                table: "MediaPosters");

            migrationBuilder.DropIndex(
                name: "IX_MediaCovers_CreatorUserId",
                table: "MediaCovers");

            migrationBuilder.DropIndex(
                name: "IX_CharacterTitles_CreatorUserId",
                table: "CharacterTitles");

            migrationBuilder.DropIndex(
                name: "IX_CharacterNames_CreatorUserId",
                table: "CharacterNames");

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

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorUserId",
                table: "MediaTitles",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorUserId",
                table: "MediaSynopsis",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorUserId",
                table: "MediaPosters",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorUserId",
                table: "MediaCovers",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorUserId",
                table: "CharacterTitles",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorUserId",
                table: "CharacterNames",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ImageEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MediaId = table.Column<Guid>(type: "uuid", nullable: false),
                    AcceptOfferUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatorUserId = table.Column<Guid>(type: "uuid", nullable: true),
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
                });

            migrationBuilder.CreateTable(
                name: "TextVariantSubItemEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MediaId = table.Column<Guid>(type: "uuid", nullable: false),
                    AcceptOfferUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatorUserId = table.Column<Guid>(type: "uuid", nullable: true),
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
                });

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
    }
}
