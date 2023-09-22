using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NekoSpace.Data.Migrations
{
    /// <inheritdoc />
    public partial class Changeanimetitlerelation7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnimeSynopsis_Animes_MediaId",
                table: "AnimeSynopsis");

            migrationBuilder.DropForeignKey(
                name: "FK_AnimeTitle_Animes_MediaId",
                table: "AnimeTitle");

            migrationBuilder.DropForeignKey(
                name: "FK_CharacterNames_Characters_MediaId",
                table: "CharacterNames");

            migrationBuilder.DropForeignKey(
                name: "FK_CharacterTitles_Characters_MediaId",
                table: "CharacterTitles");

            migrationBuilder.DropForeignKey(
                name: "FK_MangaSynopsis_Mangas_MediaId",
                table: "MangaSynopsis");

            migrationBuilder.DropForeignKey(
                name: "FK_MangaTitles_Mangas_MediaId",
                table: "MangaTitles");

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
                name: "IX_AnimeTitle_MediaId",
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
                table: "AnimeTitle");

            migrationBuilder.RenameColumn(
                name: "MediaId",
                table: "AnimeSynopsis",
                newName: "AnimeId");

            migrationBuilder.RenameIndex(
                name: "IX_AnimeSynopsis_MediaId",
                table: "AnimeSynopsis",
                newName: "IX_AnimeSynopsis_AnimeId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "36a1bb76-663f-4c43-9da1-901a7ddb6ea7", "1", "Moderator", "MODERATOR" },
                    { "80a625b9-c377-4812-b751-faaa1bbb1890", "1", "Guest", "GUEST" },
                    { "93ce44b5-58c0-4316-a946-a9bb2d72719e", "1", "User", "USER" },
                    { "abd9afc8-d346-4276-83d3-3d1371efc9cc", "1", "Creator", "CREATOR" },
                    { "df4123a7-2b24-4a7a-9a54-2b4ff9bea466", "1", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "About", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "9c530d32-8b6c-4192-b495-b86533b0dc64", null, 0, "b09ab2e9-4131-4b2f-b35a-055042d496c3", "admin@example.local", false, false, null, "ADMIN@EXAMPLE.LOCAL", "ADMIN", "AQAAAAEAACcQAAAAEHcnJe+yZ9BMU/ZP+V42eQaJYhEMQw4gKoLXDQFEHKcwhElL+c2NC7MkZJu2onNIdw==", null, false, "f67052b4-454e-48da-bf17-05975424c40f", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "df4123a7-2b24-4a7a-9a54-2b4ff9bea466", "9c530d32-8b6c-4192-b495-b86533b0dc64" });

            migrationBuilder.AddForeignKey(
                name: "FK_AnimeSynopsis_Animes_AnimeId",
                table: "AnimeSynopsis",
                column: "AnimeId",
                principalTable: "Animes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnimeSynopsis_Animes_AnimeId",
                table: "AnimeSynopsis");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "36a1bb76-663f-4c43-9da1-901a7ddb6ea7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "80a625b9-c377-4812-b751-faaa1bbb1890");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "93ce44b5-58c0-4316-a946-a9bb2d72719e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "abd9afc8-d346-4276-83d3-3d1371efc9cc");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "df4123a7-2b24-4a7a-9a54-2b4ff9bea466", "9c530d32-8b6c-4192-b495-b86533b0dc64" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "df4123a7-2b24-4a7a-9a54-2b4ff9bea466");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9c530d32-8b6c-4192-b495-b86533b0dc64");

            migrationBuilder.RenameColumn(
                name: "AnimeId",
                table: "AnimeSynopsis",
                newName: "MediaId");

            migrationBuilder.RenameIndex(
                name: "IX_AnimeSynopsis_AnimeId",
                table: "AnimeSynopsis",
                newName: "IX_AnimeSynopsis_MediaId");

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
                name: "IX_AnimeTitle_MediaId",
                table: "AnimeTitle",
                column: "MediaId");

            migrationBuilder.AddForeignKey(
                name: "FK_AnimeSynopsis_Animes_MediaId",
                table: "AnimeSynopsis",
                column: "MediaId",
                principalTable: "Animes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AnimeTitle_Animes_MediaId",
                table: "AnimeTitle",
                column: "MediaId",
                principalTable: "Animes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterNames_Characters_MediaId",
                table: "CharacterNames",
                column: "MediaId",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterTitles_Characters_MediaId",
                table: "CharacterTitles",
                column: "MediaId",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MangaSynopsis_Mangas_MediaId",
                table: "MangaSynopsis",
                column: "MediaId",
                principalTable: "Mangas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MangaTitles_Mangas_MediaId",
                table: "MangaTitles",
                column: "MediaId",
                principalTable: "Mangas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
