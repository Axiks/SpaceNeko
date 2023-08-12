using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NekoSpace.Data.Migrations
{
    /// <inheritdoc />
    public partial class Updatepropositiontables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnimeTitle");

            migrationBuilder.DropTable(
                name: "ImageEntity");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0962d682-0a0d-4432-b71e-ac0adfe5feae");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "80718012-e7d6-45d2-b360-7329ff0dc7e1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "938847f2-a8d3-4647-86a3-833ea26f73d1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eb287bbe-c944-4442-b20b-3e237d24e889");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "7d1ae767-42ae-44d3-9e28-a8050def76cf", "d7661412-d0cf-4736-ad0d-d1cf5224d527" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7d1ae767-42ae-44d3-9e28-a8050def76cf");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d7661412-d0cf-4736-ad0d-d1cf5224d527");

            migrationBuilder.AddColumn<Guid>(
                name: "MediaId",
                table: "MangaTitles",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "MediaId",
                table: "MangaSynopsis",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "MediaId",
                table: "CharacterTitles",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "MediaId",
                table: "CharacterNames",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "MediaId",
                table: "AnimeSynopsis",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "MediaSynopsisEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MediaId = table.Column<Guid>(type: "uuid", nullable: false),
                    Language = table.Column<string>(type: "text", nullable: true),
                    From = table.Column<string>(type: "text", nullable: false),
                    IsMain = table.Column<bool>(type: "boolean", nullable: false),
                    IsOriginal = table.Column<bool>(type: "boolean", nullable: false),
                    IsAcceptProposal = table.Column<bool>(type: "boolean", nullable: true),
                    IsHidden = table.Column<bool>(type: "boolean", nullable: false),
                    CreatorUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Body = table.Column<string>(type: "text", nullable: false),
                    LanguageDetectionBySystem = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaSynopsisEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MediaSynopsisEntity_Medias_MediaId",
                        column: x => x.MediaId,
                        principalTable: "Medias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MediaTitleEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MediaId = table.Column<Guid>(type: "uuid", nullable: false),
                    Language = table.Column<string>(type: "text", nullable: true),
                    From = table.Column<string>(type: "text", nullable: false),
                    IsMain = table.Column<bool>(type: "boolean", nullable: false),
                    IsOriginal = table.Column<bool>(type: "boolean", nullable: false),
                    IsAcceptProposal = table.Column<bool>(type: "boolean", nullable: true),
                    IsHidden = table.Column<bool>(type: "boolean", nullable: false),
                    CreatorUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Body = table.Column<string>(type: "text", nullable: false),
                    LanguageDetectionBySystem = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaTitleEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MediaTitleEntity_Medias_MediaId",
                        column: x => x.MediaId,
                        principalTable: "Medias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "044948f5-58d0-482d-aa23-424e32dca539", "1", "Creator", "CREATOR" },
                    { "72b1a236-0f15-4c19-a710-e1b777aa89fc", "1", "Administrator", "ADMINISTRATOR" },
                    { "a84f63fd-8825-414c-8aa3-74d8d1cd91ed", "1", "Guest", "GUEST" },
                    { "f306ac79-3c23-48db-92f4-6ceeddf7b851", "1", "User", "USER" },
                    { "fe62173d-eac3-4099-bd9d-d27ba7b3b557", "1", "Moderator", "MODERATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "About", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "54aa3202-a127-4d02-9e53-099e0b25ee5c", null, 0, "4f9b342c-2706-428d-afbd-e75b8a7c6522", "admin@example.local", false, false, null, "ADMIN@EXAMPLE.LOCAL", "ADMIN", "AQAAAAEAACcQAAAAEHcnJe+yZ9BMU/ZP+V42eQaJYhEMQw4gKoLXDQFEHKcwhElL+c2NC7MkZJu2onNIdw==", null, false, "3c705add-42a6-4baa-85be-2e13148fd12b", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "72b1a236-0f15-4c19-a710-e1b777aa89fc", "54aa3202-a127-4d02-9e53-099e0b25ee5c" });

            migrationBuilder.CreateIndex(
                name: "IX_MangaTitles_MediaId",
                table: "MangaTitles",
                column: "MediaId");

            migrationBuilder.CreateIndex(
                name: "IX_MangaSynopsis_MediaId",
                table: "MangaSynopsis",
                column: "MediaId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterTitles_MediaId",
                table: "CharacterTitles",
                column: "MediaId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterNames_MediaId",
                table: "CharacterNames",
                column: "MediaId");

            migrationBuilder.CreateIndex(
                name: "IX_AnimeSynopsis_MediaId",
                table: "AnimeSynopsis",
                column: "MediaId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaSynopsisEntity_MediaId",
                table: "MediaSynopsisEntity",
                column: "MediaId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaTitleEntity_MediaId",
                table: "MediaTitleEntity",
                column: "MediaId");

            migrationBuilder.AddForeignKey(
                name: "FK_AnimeSynopsis_Medias_MediaId",
                table: "AnimeSynopsis",
                column: "MediaId",
                principalTable: "Medias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterNames_Medias_MediaId",
                table: "CharacterNames",
                column: "MediaId",
                principalTable: "Medias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterTitles_Medias_MediaId",
                table: "CharacterTitles",
                column: "MediaId",
                principalTable: "Medias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MangaSynopsis_Medias_MediaId",
                table: "MangaSynopsis",
                column: "MediaId",
                principalTable: "Medias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MangaTitles_Medias_MediaId",
                table: "MangaTitles",
                column: "MediaId",
                principalTable: "Medias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnimeSynopsis_Medias_MediaId",
                table: "AnimeSynopsis");

            migrationBuilder.DropForeignKey(
                name: "FK_CharacterNames_Medias_MediaId",
                table: "CharacterNames");

            migrationBuilder.DropForeignKey(
                name: "FK_CharacterTitles_Medias_MediaId",
                table: "CharacterTitles");

            migrationBuilder.DropForeignKey(
                name: "FK_MangaSynopsis_Medias_MediaId",
                table: "MangaSynopsis");

            migrationBuilder.DropForeignKey(
                name: "FK_MangaTitles_Medias_MediaId",
                table: "MangaTitles");

            migrationBuilder.DropTable(
                name: "MediaSynopsisEntity");

            migrationBuilder.DropTable(
                name: "MediaTitleEntity");

            migrationBuilder.DropIndex(
                name: "IX_MangaTitles_MediaId",
                table: "MangaTitles");

            migrationBuilder.DropIndex(
                name: "IX_MangaSynopsis_MediaId",
                table: "MangaSynopsis");

            migrationBuilder.DropIndex(
                name: "IX_CharacterTitles_MediaId",
                table: "CharacterTitles");

            migrationBuilder.DropIndex(
                name: "IX_CharacterNames_MediaId",
                table: "CharacterNames");

            migrationBuilder.DropIndex(
                name: "IX_AnimeSynopsis_MediaId",
                table: "AnimeSynopsis");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "044948f5-58d0-482d-aa23-424e32dca539");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a84f63fd-8825-414c-8aa3-74d8d1cd91ed");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f306ac79-3c23-48db-92f4-6ceeddf7b851");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fe62173d-eac3-4099-bd9d-d27ba7b3b557");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "72b1a236-0f15-4c19-a710-e1b777aa89fc", "54aa3202-a127-4d02-9e53-099e0b25ee5c" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "72b1a236-0f15-4c19-a710-e1b777aa89fc");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "54aa3202-a127-4d02-9e53-099e0b25ee5c");

            migrationBuilder.DropColumn(
                name: "MediaId",
                table: "MangaTitles");

            migrationBuilder.DropColumn(
                name: "MediaId",
                table: "MangaSynopsis");

            migrationBuilder.DropColumn(
                name: "MediaId",
                table: "CharacterTitles");

            migrationBuilder.DropColumn(
                name: "MediaId",
                table: "CharacterNames");

            migrationBuilder.DropColumn(
                name: "MediaId",
                table: "AnimeSynopsis");

            migrationBuilder.CreateTable(
                name: "AnimeTitle",
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
                    AnimeId = table.Column<Guid>(type: "uuid", nullable: false),
                    Body = table.Column<string>(type: "text", nullable: false),
                    LanguageDetectionBySystem = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimeTitle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnimeTitle_Animes_AnimeId",
                        column: x => x.AnimeId,
                        principalTable: "Animes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                    { "0962d682-0a0d-4432-b71e-ac0adfe5feae", "1", "User", "USER" },
                    { "7d1ae767-42ae-44d3-9e28-a8050def76cf", "1", "Administrator", "ADMINISTRATOR" },
                    { "80718012-e7d6-45d2-b360-7329ff0dc7e1", "1", "Moderator", "MODERATOR" },
                    { "938847f2-a8d3-4647-86a3-833ea26f73d1", "1", "Guest", "GUEST" },
                    { "eb287bbe-c944-4442-b20b-3e237d24e889", "1", "Creator", "CREATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "About", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "d7661412-d0cf-4736-ad0d-d1cf5224d527", null, 0, "8ed341eb-9f7f-40a3-b98f-f5d3ecea2981", "admin@example.local", false, false, null, "ADMIN@EXAMPLE.LOCAL", "ADMIN", "AQAAAAEAACcQAAAAEHcnJe+yZ9BMU/ZP+V42eQaJYhEMQw4gKoLXDQFEHKcwhElL+c2NC7MkZJu2onNIdw==", null, false, "241e2268-0064-4d79-acb1-49c1dcab8b8a", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "7d1ae767-42ae-44d3-9e28-a8050def76cf", "d7661412-d0cf-4736-ad0d-d1cf5224d527" });

            migrationBuilder.CreateIndex(
                name: "IX_AnimeTitle_AnimeId",
                table: "AnimeTitle",
                column: "AnimeId");
        }
    }
}
