using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NekoSpace.Data.Migrations
{
    /// <inheritdoc />
    public partial class Updatepropositiontables2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MediaSynopsisEntity_Medias_MediaId",
                table: "MediaSynopsisEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_MediaTitleEntity_Medias_MediaId",
                table: "MediaTitleEntity");

            migrationBuilder.DropTable(
                name: "ImageEntity");

            migrationBuilder.DropTable(
                name: "TextVariantSubItemEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MediaTitleEntity",
                table: "MediaTitleEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MediaSynopsisEntity",
                table: "MediaSynopsisEntity");

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

            migrationBuilder.RenameTable(
                name: "MediaTitleEntity",
                newName: "MediaTitles");

            migrationBuilder.RenameTable(
                name: "MediaSynopsisEntity",
                newName: "MediaSynopsis");

            migrationBuilder.RenameIndex(
                name: "IX_MediaTitleEntity_MediaId",
                table: "MediaTitles",
                newName: "IX_MediaTitles_MediaId");

            migrationBuilder.RenameIndex(
                name: "IX_MediaSynopsisEntity_MediaId",
                table: "MediaSynopsis",
                newName: "IX_MediaSynopsis_MediaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MediaTitles",
                table: "MediaTitles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MediaSynopsis",
                table: "MediaSynopsis",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "10c15deb-373e-414c-a881-5fdc2f245ada", "1", "User", "USER" },
                    { "3ddf9278-6638-430f-bee0-bd77bdc413e6", "1", "Creator", "CREATOR" },
                    { "45a820a6-5949-43c0-af92-84143c46c99d", "1", "Administrator", "ADMINISTRATOR" },
                    { "5693508c-3dda-4251-8144-d57e43fb27dc", "1", "Moderator", "MODERATOR" },
                    { "dc1259ec-d977-432d-8bac-bcdcae517fa6", "1", "Guest", "GUEST" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "About", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "459c2d6b-f289-4639-96ab-ac963e95dc3c", null, 0, "732f9512-2f22-4a94-876b-4d4f24057590", "admin@example.local", false, false, null, "ADMIN@EXAMPLE.LOCAL", "ADMIN", "AQAAAAEAACcQAAAAEHcnJe+yZ9BMU/ZP+V42eQaJYhEMQw4gKoLXDQFEHKcwhElL+c2NC7MkZJu2onNIdw==", null, false, "e5cd62bf-d5f0-436a-b5e8-99cf5dcac0b1", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "45a820a6-5949-43c0-af92-84143c46c99d", "459c2d6b-f289-4639-96ab-ac963e95dc3c" });

            migrationBuilder.AddForeignKey(
                name: "FK_MediaSynopsis_Medias_MediaId",
                table: "MediaSynopsis",
                column: "MediaId",
                principalTable: "Medias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MediaTitles_Medias_MediaId",
                table: "MediaTitles",
                column: "MediaId",
                principalTable: "Medias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MediaSynopsis_Medias_MediaId",
                table: "MediaSynopsis");

            migrationBuilder.DropForeignKey(
                name: "FK_MediaTitles_Medias_MediaId",
                table: "MediaTitles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MediaTitles",
                table: "MediaTitles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MediaSynopsis",
                table: "MediaSynopsis");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "10c15deb-373e-414c-a881-5fdc2f245ada");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3ddf9278-6638-430f-bee0-bd77bdc413e6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5693508c-3dda-4251-8144-d57e43fb27dc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dc1259ec-d977-432d-8bac-bcdcae517fa6");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "45a820a6-5949-43c0-af92-84143c46c99d", "459c2d6b-f289-4639-96ab-ac963e95dc3c" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "45a820a6-5949-43c0-af92-84143c46c99d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "459c2d6b-f289-4639-96ab-ac963e95dc3c");

            migrationBuilder.RenameTable(
                name: "MediaTitles",
                newName: "MediaTitleEntity");

            migrationBuilder.RenameTable(
                name: "MediaSynopsis",
                newName: "MediaSynopsisEntity");

            migrationBuilder.RenameIndex(
                name: "IX_MediaTitles_MediaId",
                table: "MediaTitleEntity",
                newName: "IX_MediaTitleEntity_MediaId");

            migrationBuilder.RenameIndex(
                name: "IX_MediaSynopsis_MediaId",
                table: "MediaSynopsisEntity",
                newName: "IX_MediaSynopsisEntity_MediaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MediaTitleEntity",
                table: "MediaTitleEntity",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MediaSynopsisEntity",
                table: "MediaSynopsisEntity",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ImageEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MediaId = table.Column<Guid>(type: "uuid", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "TextVariantSubItemEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MediaId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatorUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    From = table.Column<string>(type: "text", nullable: false),
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

            migrationBuilder.AddForeignKey(
                name: "FK_MediaSynopsisEntity_Medias_MediaId",
                table: "MediaSynopsisEntity",
                column: "MediaId",
                principalTable: "Medias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MediaTitleEntity_Medias_MediaId",
                table: "MediaTitleEntity",
                column: "MediaId",
                principalTable: "Medias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
