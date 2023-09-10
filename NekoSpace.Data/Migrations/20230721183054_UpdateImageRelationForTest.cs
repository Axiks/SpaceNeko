using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NekoSpace.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateImageRelationForTest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharacterCover_Images_CoverId",
                table: "CharacterCover");

            migrationBuilder.DropForeignKey(
                name: "FK_CharacterPoster_Images_PosterId",
                table: "CharacterPoster");

            migrationBuilder.DropTable(
                name: "AnimeCover");

            migrationBuilder.DropTable(
                name: "AnimePoster");

            migrationBuilder.DropTable(
                name: "MangaCoverEntity");

            migrationBuilder.DropTable(
                name: "MangaPosterEntity");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5b2f3d90-7c49-48f4-af8b-394a81e8d7fa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6bfe1a52-b0b8-4e92-af17-886ffd98caeb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7a020eb1-7d98-4c44-a028-f84a77aa08e5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b3a362b1-49d5-4e23-93ee-aad2ae555ce1");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "5218f5f2-7d0b-4453-b90b-08a28e55642b", "a0d3ae73-9212-41f2-8514-c5ab94c30a87" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5218f5f2-7d0b-4453-b90b-08a28e55642b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a0d3ae73-9212-41f2-8514-c5ab94c30a87");

            migrationBuilder.AlterColumn<string>(
                name: "Language",
                table: "CharacterTitles",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<Guid>(
                name: "PosterId1",
                table: "CharacterPoster",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<string>(
                name: "Language",
                table: "CharacterNames",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<Guid>(
                name: "CoverId1",
                table: "CharacterCover",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<string>(
                name: "Language",
                table: "AnimeTitle",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Language",
                table: "AnimeSynopsis",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Animes",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Source",
                table: "Animes",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "AiringStatus",
                table: "Animes",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "AgeRating",
                table: "Animes",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.CreateTable(
                name: "ImageEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Original = table.Column<string>(type: "text", nullable: false),
                    Large = table.Column<string>(type: "text", nullable: true),
                    Medium = table.Column<string>(type: "text", nullable: true),
                    Small = table.Column<string>(type: "text", nullable: true),
                    From = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cover_Media",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AnimeEntityId = table.Column<Guid>(type: "uuid", nullable: true),
                    MangaEntityId = table.Column<Guid>(type: "uuid", nullable: true),
                    MediaId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cover_Media", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cover_Media_Animes_AnimeEntityId",
                        column: x => x.AnimeEntityId,
                        principalTable: "Animes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Cover_Media_ImageEntity_Id",
                        column: x => x.Id,
                        principalTable: "ImageEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cover_Media_Mangas_MangaEntityId",
                        column: x => x.MangaEntityId,
                        principalTable: "Mangas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Cover_Media_MediaEntity_MediaId",
                        column: x => x.MediaId,
                        principalTable: "MediaEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Poster_Media",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AnimeEntityId = table.Column<Guid>(type: "uuid", nullable: true),
                    MangaEntityId = table.Column<Guid>(type: "uuid", nullable: true),
                    MediaId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Poster_Media", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Poster_Media_Animes_AnimeEntityId",
                        column: x => x.AnimeEntityId,
                        principalTable: "Animes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Poster_Media_ImageEntity_Id",
                        column: x => x.Id,
                        principalTable: "ImageEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Poster_Media_Mangas_MangaEntityId",
                        column: x => x.MangaEntityId,
                        principalTable: "Mangas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Poster_Media_MediaEntity_MediaId",
                        column: x => x.MediaId,
                        principalTable: "MediaEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "50209e41-eb22-452e-a8bf-8c5982cdc809", "1", "Administrator", "ADMINISTRATOR" },
                    { "861d72c4-753e-4443-b741-aa32b44da1c7", "1", "Guest", "GUEST" },
                    { "8db1ac02-7cf3-42d3-9f48-e05fc3620092", "1", "User", "USER" },
                    { "a18133eb-592a-4aeb-825f-73454cecd511", "1", "Moderator", "MODERATOR" },
                    { "cf49383a-1b44-4b80-8efa-712f9f0008ea", "1", "Creator", "CREATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "About", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "987fa849-5906-4980-a248-d85f794518ae", null, 0, "0845fc65-5a67-4ac5-ba53-99271be212d3", "admin@example.local", false, false, null, "ADMIN@EXAMPLE.LOCAL", "ADMIN", "AQAAAAEAACcQAAAAEHcnJe+yZ9BMU/ZP+V42eQaJYhEMQw4gKoLXDQFEHKcwhElL+c2NC7MkZJu2onNIdw==", null, false, "b885a392-f95d-4e24-97fa-0b3eef785826", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "50209e41-eb22-452e-a8bf-8c5982cdc809", "987fa849-5906-4980-a248-d85f794518ae" });

            migrationBuilder.CreateIndex(
                name: "IX_CharacterPoster_PosterId1",
                table: "CharacterPoster",
                column: "PosterId1");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterCover_CoverId1",
                table: "CharacterCover",
                column: "CoverId1");

            migrationBuilder.CreateIndex(
                name: "IX_Cover_Media_AnimeEntityId",
                table: "Cover_Media",
                column: "AnimeEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Cover_Media_MangaEntityId",
                table: "Cover_Media",
                column: "MangaEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Cover_Media_MediaId",
                table: "Cover_Media",
                column: "MediaId");

            migrationBuilder.CreateIndex(
                name: "IX_Poster_Media_AnimeEntityId",
                table: "Poster_Media",
                column: "AnimeEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Poster_Media_MangaEntityId",
                table: "Poster_Media",
                column: "MangaEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Poster_Media_MediaId",
                table: "Poster_Media",
                column: "MediaId");

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterCover_ImageEntity_CoverId1",
                table: "CharacterCover",
                column: "CoverId1",
                principalTable: "ImageEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterPoster_ImageEntity_PosterId1",
                table: "CharacterPoster",
                column: "PosterId1",
                principalTable: "ImageEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharacterCover_ImageEntity_CoverId1",
                table: "CharacterCover");

            migrationBuilder.DropForeignKey(
                name: "FK_CharacterPoster_ImageEntity_PosterId1",
                table: "CharacterPoster");

            migrationBuilder.DropTable(
                name: "Cover_Media");

            migrationBuilder.DropTable(
                name: "Poster_Media");

            migrationBuilder.DropTable(
                name: "ImageEntity");

            migrationBuilder.DropIndex(
                name: "IX_CharacterPoster_PosterId1",
                table: "CharacterPoster");

            migrationBuilder.DropIndex(
                name: "IX_CharacterCover_CoverId1",
                table: "CharacterCover");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "861d72c4-753e-4443-b741-aa32b44da1c7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8db1ac02-7cf3-42d3-9f48-e05fc3620092");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18133eb-592a-4aeb-825f-73454cecd511");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cf49383a-1b44-4b80-8efa-712f9f0008ea");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "50209e41-eb22-452e-a8bf-8c5982cdc809", "987fa849-5906-4980-a248-d85f794518ae" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "50209e41-eb22-452e-a8bf-8c5982cdc809");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "987fa849-5906-4980-a248-d85f794518ae");

            migrationBuilder.DropColumn(
                name: "PosterId1",
                table: "CharacterPoster");

            migrationBuilder.DropColumn(
                name: "CoverId1",
                table: "CharacterCover");

            migrationBuilder.AlterColumn<string>(
                name: "Language",
                table: "CharacterTitles",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Language",
                table: "CharacterNames",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Language",
                table: "AnimeTitle",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Language",
                table: "AnimeSynopsis",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Animes",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Source",
                table: "Animes",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AiringStatus",
                table: "Animes",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AgeRating",
                table: "Animes",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    From = table.Column<int>(type: "integer", nullable: false),
                    Large = table.Column<string>(type: "text", nullable: true),
                    Medium = table.Column<string>(type: "text", nullable: true),
                    Original = table.Column<string>(type: "text", nullable: false),
                    Small = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AnimeCover",
                columns: table => new
                {
                    CoverId = table.Column<int>(type: "integer", nullable: false),
                    AnimeId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimeCover", x => new { x.CoverId, x.AnimeId });
                    table.ForeignKey(
                        name: "FK_AnimeCover_Animes_AnimeId",
                        column: x => x.AnimeId,
                        principalTable: "Animes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnimeCover_Images_CoverId",
                        column: x => x.CoverId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnimePoster",
                columns: table => new
                {
                    PosterId = table.Column<int>(type: "integer", nullable: false),
                    AnimeId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimePoster", x => new { x.PosterId, x.AnimeId });
                    table.ForeignKey(
                        name: "FK_AnimePoster_Animes_AnimeId",
                        column: x => x.AnimeId,
                        principalTable: "Animes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnimePoster_Images_PosterId",
                        column: x => x.PosterId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MangaCoverEntity",
                columns: table => new
                {
                    CoverId = table.Column<int>(type: "integer", nullable: false),
                    MangaId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MangaCoverEntity", x => new { x.CoverId, x.MangaId });
                    table.ForeignKey(
                        name: "FK_MangaCoverEntity_Images_CoverId",
                        column: x => x.CoverId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MangaCoverEntity_Mangas_MangaId",
                        column: x => x.MangaId,
                        principalTable: "Mangas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MangaPosterEntity",
                columns: table => new
                {
                    PosterId = table.Column<int>(type: "integer", nullable: false),
                    MangaId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MangaPosterEntity", x => new { x.PosterId, x.MangaId });
                    table.ForeignKey(
                        name: "FK_MangaPosterEntity_Images_PosterId",
                        column: x => x.PosterId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MangaPosterEntity_Mangas_MangaId",
                        column: x => x.MangaId,
                        principalTable: "Mangas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5218f5f2-7d0b-4453-b90b-08a28e55642b", "1", "Administrator", "ADMINISTRATOR" },
                    { "5b2f3d90-7c49-48f4-af8b-394a81e8d7fa", "1", "Guest", "GUEST" },
                    { "6bfe1a52-b0b8-4e92-af17-886ffd98caeb", "1", "Creator", "CREATOR" },
                    { "7a020eb1-7d98-4c44-a028-f84a77aa08e5", "1", "Moderator", "MODERATOR" },
                    { "b3a362b1-49d5-4e23-93ee-aad2ae555ce1", "1", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "About", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "a0d3ae73-9212-41f2-8514-c5ab94c30a87", null, 0, "fb439a50-df43-4378-8c5c-940a44105870", "admin@example.local", false, false, null, "ADMIN@EXAMPLE.LOCAL", "ADMIN", "AQAAAAEAACcQAAAAEHcnJe+yZ9BMU/ZP+V42eQaJYhEMQw4gKoLXDQFEHKcwhElL+c2NC7MkZJu2onNIdw==", null, false, "85a92f63-9bab-4901-9714-b4cf2a4f16cd", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "5218f5f2-7d0b-4453-b90b-08a28e55642b", "a0d3ae73-9212-41f2-8514-c5ab94c30a87" });

            migrationBuilder.CreateIndex(
                name: "IX_AnimeCover_AnimeId",
                table: "AnimeCover",
                column: "AnimeId");

            migrationBuilder.CreateIndex(
                name: "IX_AnimePoster_AnimeId",
                table: "AnimePoster",
                column: "AnimeId");

            migrationBuilder.CreateIndex(
                name: "IX_AnimePoster_PosterId",
                table: "AnimePoster",
                column: "PosterId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MangaCoverEntity_MangaId",
                table: "MangaCoverEntity",
                column: "MangaId");

            migrationBuilder.CreateIndex(
                name: "IX_MangaPosterEntity_MangaId",
                table: "MangaPosterEntity",
                column: "MangaId");

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterCover_Images_CoverId",
                table: "CharacterCover",
                column: "CoverId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterPoster_Images_PosterId",
                table: "CharacterPoster",
                column: "PosterId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
