using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NekoSpace.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateImageRelationForTest4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animes_MediaEntity_Id",
                table: "Animes");

            migrationBuilder.DropForeignKey(
                name: "FK_AssociatedService_MediaEntity_MediaId",
                table: "AssociatedService");

            migrationBuilder.DropForeignKey(
                name: "FK_CharacterCover_ImageEntity_CoverImageId",
                table: "CharacterCover");

            migrationBuilder.DropForeignKey(
                name: "FK_CharacterPoster_ImageEntity_PosterImageId",
                table: "CharacterPoster");

            migrationBuilder.DropForeignKey(
                name: "FK_Characters_MediaEntity_Id",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Cover_Media_Animes_AnimeEntityId",
                table: "Cover_Media");

            migrationBuilder.DropForeignKey(
                name: "FK_Cover_Media_ImageEntity_ImageId",
                table: "Cover_Media");

            migrationBuilder.DropForeignKey(
                name: "FK_Cover_Media_Mangas_MangaEntityId",
                table: "Cover_Media");

            migrationBuilder.DropForeignKey(
                name: "FK_Cover_Media_MediaEntity_MediaId",
                table: "Cover_Media");

            migrationBuilder.DropForeignKey(
                name: "FK_Mangas_MediaEntity_Id",
                table: "Mangas");

            migrationBuilder.DropForeignKey(
                name: "FK_Poster_Media_Animes_AnimeEntityId",
                table: "Poster_Media");

            migrationBuilder.DropForeignKey(
                name: "FK_Poster_Media_ImageEntity_ImageId",
                table: "Poster_Media");

            migrationBuilder.DropForeignKey(
                name: "FK_Poster_Media_Mangas_MangaEntityId",
                table: "Poster_Media");

            migrationBuilder.DropForeignKey(
                name: "FK_Poster_Media_MediaEntity_MediaId",
                table: "Poster_Media");

            migrationBuilder.DropTable(
                name: "ImageEntity");

            migrationBuilder.DropTable(
                name: "MediaEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Poster_Media",
                table: "Poster_Media");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cover_Media",
                table: "Cover_Media");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "424dee6a-9fb5-45a7-b3ad-9d2e7e584693");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b2a1b5c4-7839-451a-bc83-15dd17df3ac3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d31b1093-a22d-44b1-9708-f930b2b964c6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "da72fe2c-f51d-4f42-81a3-5bf63dc6d9a7");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "9f0e1653-86eb-42b2-9e4b-dbf3139c18f4", "fb0b32b8-35a7-4366-8a68-7752fa8aac5a" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9f0e1653-86eb-42b2-9e4b-dbf3139c18f4");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fb0b32b8-35a7-4366-8a68-7752fa8aac5a");

            migrationBuilder.RenameTable(
                name: "Poster_Media",
                newName: "Posters");

            migrationBuilder.RenameTable(
                name: "Cover_Media",
                newName: "Covers");

            migrationBuilder.RenameIndex(
                name: "IX_Poster_Media_MediaId",
                table: "Posters",
                newName: "IX_Posters_MediaId");

            migrationBuilder.RenameIndex(
                name: "IX_Poster_Media_MangaEntityId",
                table: "Posters",
                newName: "IX_Posters_MangaEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Poster_Media_AnimeEntityId",
                table: "Posters",
                newName: "IX_Posters_AnimeEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Cover_Media_MediaId",
                table: "Covers",
                newName: "IX_Covers_MediaId");

            migrationBuilder.RenameIndex(
                name: "IX_Cover_Media_MangaEntityId",
                table: "Covers",
                newName: "IX_Covers_MangaEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Cover_Media_AnimeEntityId",
                table: "Covers",
                newName: "IX_Covers_AnimeEntityId");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "Mangas",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "Mangas",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "Characters",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "Characters",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "Animes",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "Animes",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<int>(
                name: "From",
                table: "Posters",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Large",
                table: "Posters",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Medium",
                table: "Posters",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Original",
                table: "Posters",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Small",
                table: "Posters",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "From",
                table: "Covers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Large",
                table: "Covers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Medium",
                table: "Covers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Original",
                table: "Covers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Small",
                table: "Covers",
                type: "text",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Posters",
                table: "Posters",
                column: "ImageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Covers",
                table: "Covers",
                column: "ImageId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7dc99fdf-2b45-4a31-88d5-16f5447197f7", "1", "Guest", "GUEST" },
                    { "b871117d-fd9c-447b-a086-3d17ee2cec30", "1", "Administrator", "ADMINISTRATOR" },
                    { "de7b4456-213a-41b0-8bd0-e241521027a4", "1", "User", "USER" },
                    { "ed9b284c-9077-4e8d-8778-82ebe5e855ce", "1", "Moderator", "MODERATOR" },
                    { "f2eb358d-694a-4b22-a25f-e9ce92071ba1", "1", "Creator", "CREATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "About", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "543f1111-f16b-4664-beda-31f18cccd55f", null, 0, "25926e80-6e43-49ff-9bd5-50917a2aa524", "admin@example.local", false, false, null, "ADMIN@EXAMPLE.LOCAL", "ADMIN", "AQAAAAEAACcQAAAAEHcnJe+yZ9BMU/ZP+V42eQaJYhEMQw4gKoLXDQFEHKcwhElL+c2NC7MkZJu2onNIdw==", null, false, "326e2667-f01f-4734-81d6-cb1b1235a3af", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "b871117d-fd9c-447b-a086-3d17ee2cec30", "543f1111-f16b-4664-beda-31f18cccd55f" });

            migrationBuilder.AddForeignKey(
                name: "FK_Covers_Animes_AnimeEntityId",
                table: "Covers",
                column: "AnimeEntityId",
                principalTable: "Animes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Covers_Mangas_MangaEntityId",
                table: "Covers",
                column: "MangaEntityId",
                principalTable: "Mangas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Posters_Animes_AnimeEntityId",
                table: "Posters",
                column: "AnimeEntityId",
                principalTable: "Animes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Posters_Mangas_MangaEntityId",
                table: "Posters",
                column: "MangaEntityId",
                principalTable: "Mangas",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Covers_Animes_AnimeEntityId",
                table: "Covers");

            migrationBuilder.DropForeignKey(
                name: "FK_Covers_Mangas_MangaEntityId",
                table: "Covers");

            migrationBuilder.DropForeignKey(
                name: "FK_Posters_Animes_AnimeEntityId",
                table: "Posters");

            migrationBuilder.DropForeignKey(
                name: "FK_Posters_Mangas_MangaEntityId",
                table: "Posters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Posters",
                table: "Posters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Covers",
                table: "Covers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7dc99fdf-2b45-4a31-88d5-16f5447197f7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "de7b4456-213a-41b0-8bd0-e241521027a4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ed9b284c-9077-4e8d-8778-82ebe5e855ce");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f2eb358d-694a-4b22-a25f-e9ce92071ba1");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b871117d-fd9c-447b-a086-3d17ee2cec30", "543f1111-f16b-4664-beda-31f18cccd55f" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b871117d-fd9c-447b-a086-3d17ee2cec30");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "543f1111-f16b-4664-beda-31f18cccd55f");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Mangas");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Mangas");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Animes");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Animes");

            migrationBuilder.DropColumn(
                name: "From",
                table: "Posters");

            migrationBuilder.DropColumn(
                name: "Large",
                table: "Posters");

            migrationBuilder.DropColumn(
                name: "Medium",
                table: "Posters");

            migrationBuilder.DropColumn(
                name: "Original",
                table: "Posters");

            migrationBuilder.DropColumn(
                name: "Small",
                table: "Posters");

            migrationBuilder.DropColumn(
                name: "From",
                table: "Covers");

            migrationBuilder.DropColumn(
                name: "Large",
                table: "Covers");

            migrationBuilder.DropColumn(
                name: "Medium",
                table: "Covers");

            migrationBuilder.DropColumn(
                name: "Original",
                table: "Covers");

            migrationBuilder.DropColumn(
                name: "Small",
                table: "Covers");

            migrationBuilder.RenameTable(
                name: "Posters",
                newName: "Poster_Media");

            migrationBuilder.RenameTable(
                name: "Covers",
                newName: "Cover_Media");

            migrationBuilder.RenameIndex(
                name: "IX_Posters_MediaId",
                table: "Poster_Media",
                newName: "IX_Poster_Media_MediaId");

            migrationBuilder.RenameIndex(
                name: "IX_Posters_MangaEntityId",
                table: "Poster_Media",
                newName: "IX_Poster_Media_MangaEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Posters_AnimeEntityId",
                table: "Poster_Media",
                newName: "IX_Poster_Media_AnimeEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Covers_MediaId",
                table: "Cover_Media",
                newName: "IX_Cover_Media_MediaId");

            migrationBuilder.RenameIndex(
                name: "IX_Covers_MangaEntityId",
                table: "Cover_Media",
                newName: "IX_Cover_Media_MangaEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Covers_AnimeEntityId",
                table: "Cover_Media",
                newName: "IX_Cover_Media_AnimeEntityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Poster_Media",
                table: "Poster_Media",
                column: "ImageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cover_Media",
                table: "Cover_Media",
                column: "ImageId");

            migrationBuilder.CreateTable(
                name: "ImageEntity",
                columns: table => new
                {
                    ImageId = table.Column<Guid>(type: "uuid", nullable: false),
                    From = table.Column<int>(type: "integer", nullable: false),
                    Large = table.Column<string>(type: "text", nullable: true),
                    Medium = table.Column<string>(type: "text", nullable: true),
                    Original = table.Column<string>(type: "text", nullable: false),
                    Small = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageEntity", x => x.ImageId);
                });

            migrationBuilder.CreateTable(
                name: "MediaEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaEntity", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "424dee6a-9fb5-45a7-b3ad-9d2e7e584693", "1", "Creator", "CREATOR" },
                    { "9f0e1653-86eb-42b2-9e4b-dbf3139c18f4", "1", "Administrator", "ADMINISTRATOR" },
                    { "b2a1b5c4-7839-451a-bc83-15dd17df3ac3", "1", "User", "USER" },
                    { "d31b1093-a22d-44b1-9708-f930b2b964c6", "1", "Moderator", "MODERATOR" },
                    { "da72fe2c-f51d-4f42-81a3-5bf63dc6d9a7", "1", "Guest", "GUEST" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "About", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "fb0b32b8-35a7-4366-8a68-7752fa8aac5a", null, 0, "459757d6-b560-4130-9368-932103340e10", "admin@example.local", false, false, null, "ADMIN@EXAMPLE.LOCAL", "ADMIN", "AQAAAAEAACcQAAAAEHcnJe+yZ9BMU/ZP+V42eQaJYhEMQw4gKoLXDQFEHKcwhElL+c2NC7MkZJu2onNIdw==", null, false, "565a7a36-64ad-4ea5-ac5c-8bb306f0c449", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "9f0e1653-86eb-42b2-9e4b-dbf3139c18f4", "fb0b32b8-35a7-4366-8a68-7752fa8aac5a" });

            migrationBuilder.AddForeignKey(
                name: "FK_Animes_MediaEntity_Id",
                table: "Animes",
                column: "Id",
                principalTable: "MediaEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AssociatedService_MediaEntity_MediaId",
                table: "AssociatedService",
                column: "MediaId",
                principalTable: "MediaEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterCover_ImageEntity_CoverImageId",
                table: "CharacterCover",
                column: "CoverImageId",
                principalTable: "ImageEntity",
                principalColumn: "ImageId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterPoster_ImageEntity_PosterImageId",
                table: "CharacterPoster",
                column: "PosterImageId",
                principalTable: "ImageEntity",
                principalColumn: "ImageId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_MediaEntity_Id",
                table: "Characters",
                column: "Id",
                principalTable: "MediaEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cover_Media_Animes_AnimeEntityId",
                table: "Cover_Media",
                column: "AnimeEntityId",
                principalTable: "Animes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cover_Media_ImageEntity_ImageId",
                table: "Cover_Media",
                column: "ImageId",
                principalTable: "ImageEntity",
                principalColumn: "ImageId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cover_Media_Mangas_MangaEntityId",
                table: "Cover_Media",
                column: "MangaEntityId",
                principalTable: "Mangas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cover_Media_MediaEntity_MediaId",
                table: "Cover_Media",
                column: "MediaId",
                principalTable: "MediaEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Mangas_MediaEntity_Id",
                table: "Mangas",
                column: "Id",
                principalTable: "MediaEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Poster_Media_Animes_AnimeEntityId",
                table: "Poster_Media",
                column: "AnimeEntityId",
                principalTable: "Animes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Poster_Media_ImageEntity_ImageId",
                table: "Poster_Media",
                column: "ImageId",
                principalTable: "ImageEntity",
                principalColumn: "ImageId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Poster_Media_Mangas_MangaEntityId",
                table: "Poster_Media",
                column: "MangaEntityId",
                principalTable: "Mangas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Poster_Media_MediaEntity_MediaId",
                table: "Poster_Media",
                column: "MediaId",
                principalTable: "MediaEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
