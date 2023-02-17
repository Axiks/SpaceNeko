using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NekoSpace.Data.Migrations
{
    /// <inheritdoc />
    public partial class Thesettingsoftherequiredfieldshavebeenchanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MangaCover");

            migrationBuilder.DropTable(
                name: "MangaGenre");

            migrationBuilder.DropTable(
                name: "MangaPoster");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44ab4366-a5c6-4fbd-b257-0b21a691ff13");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4fcc00ca-d077-41fe-a7ed-69dd482ab92c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bf2c528d-950f-4b4b-85eb-18a2a924f81a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fa1b5680-d29e-46fa-935c-263383786fa7");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3c5ae579-e150-4d4b-b27c-466084c78008", "f57b352f-b2d7-4202-9d68-1a54d9f48935" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3c5ae579-e150-4d4b-b27c-466084c78008");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f57b352f-b2d7-4202-9d68-1a54d9f48935");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "MangaTitles");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "MangaTitles");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "MangaSynopsis");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "MangaSynopsis");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "CharacterTitles");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "CharacterTitles");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "CharacterNames");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "CharacterNames");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "AnimeTitle");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "AnimeTitle");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "AnimeSynopsis");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "AnimeSynopsis");

            migrationBuilder.CreateTable(
                name: "MangaCoverEntity",
                columns: table => new
                {
                    MangaId = table.Column<Guid>(type: "uuid", nullable: false),
                    CoverId = table.Column<int>(type: "integer", nullable: false)
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
                name: "MangaGenreEntity",
                columns: table => new
                {
                    MangaId = table.Column<Guid>(type: "uuid", nullable: false),
                    GenreId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MangaGenreEntity", x => new { x.MangaId, x.GenreId });
                    table.ForeignKey(
                        name: "FK_MangaGenreEntity_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MangaGenreEntity_Mangas_MangaId",
                        column: x => x.MangaId,
                        principalTable: "Mangas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MangaPosterEntity",
                columns: table => new
                {
                    MangaId = table.Column<Guid>(type: "uuid", nullable: false),
                    PosterId = table.Column<int>(type: "integer", nullable: false)
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
                    { "1208396f-e413-490b-a068-09439ee1a6ce", "1", "User", "USER" },
                    { "9c30579f-9f32-477f-a3ce-c474a1f387b6", "1", "Administrator", "ADMINISTRATOR" },
                    { "bb03faa3-7df8-4075-bd90-e8f7f0e5c549", "1", "Guest", "GUEST" },
                    { "cd017b6c-478e-4a2e-9599-0a41a7f26d91", "1", "Creator", "CREATOR" },
                    { "e7a06474-e159-43a7-a972-8137ed520017", "1", "Moderator", "MODERATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "About", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "bbd2394e-b7dc-4512-a4a8-bc86d0926f2f", null, 0, "21ea1616-3ab7-411b-af39-eeb1680f33e4", "admin@example.local", false, false, null, "ADMIN@EXAMPLE.LOCAL", "ADMIN", "AQAAAAEAACcQAAAAEHcnJe+yZ9BMU/ZP+V42eQaJYhEMQw4gKoLXDQFEHKcwhElL+c2NC7MkZJu2onNIdw==", null, false, "259c7e62-add5-4638-ac19-0746eedd9ccd", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "9c30579f-9f32-477f-a3ce-c474a1f387b6", "bbd2394e-b7dc-4512-a4a8-bc86d0926f2f" });

            migrationBuilder.CreateIndex(
                name: "IX_MangaCoverEntity_MangaId",
                table: "MangaCoverEntity",
                column: "MangaId");

            migrationBuilder.CreateIndex(
                name: "IX_MangaGenreEntity_GenreId",
                table: "MangaGenreEntity",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_MangaPosterEntity_MangaId",
                table: "MangaPosterEntity",
                column: "MangaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MangaCoverEntity");

            migrationBuilder.DropTable(
                name: "MangaGenreEntity");

            migrationBuilder.DropTable(
                name: "MangaPosterEntity");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1208396f-e413-490b-a068-09439ee1a6ce");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bb03faa3-7df8-4075-bd90-e8f7f0e5c549");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cd017b6c-478e-4a2e-9599-0a41a7f26d91");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e7a06474-e159-43a7-a972-8137ed520017");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "9c30579f-9f32-477f-a3ce-c474a1f387b6", "bbd2394e-b7dc-4512-a4a8-bc86d0926f2f" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9c30579f-9f32-477f-a3ce-c474a1f387b6");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bbd2394e-b7dc-4512-a4a8-bc86d0926f2f");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "MangaTitles",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "MangaTitles",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "MangaSynopsis",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "MangaSynopsis",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "CharacterTitles",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "CharacterTitles",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "CharacterNames",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "CharacterNames",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "AnimeTitle",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "AnimeTitle",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "AnimeSynopsis",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "AnimeSynopsis",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.CreateTable(
                name: "MangaCover",
                columns: table => new
                {
                    CoverId = table.Column<int>(type: "integer", nullable: false),
                    MangaId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MangaCover", x => new { x.CoverId, x.MangaId });
                    table.ForeignKey(
                        name: "FK_MangaCover_Images_CoverId",
                        column: x => x.CoverId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MangaCover_Mangas_MangaId",
                        column: x => x.MangaId,
                        principalTable: "Mangas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MangaGenre",
                columns: table => new
                {
                    MangaId = table.Column<Guid>(type: "uuid", nullable: false),
                    GenreId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MangaGenre", x => new { x.MangaId, x.GenreId });
                    table.ForeignKey(
                        name: "FK_MangaGenre_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MangaGenre_Mangas_MangaId",
                        column: x => x.MangaId,
                        principalTable: "Mangas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MangaPoster",
                columns: table => new
                {
                    PosterId = table.Column<int>(type: "integer", nullable: false),
                    MangaId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MangaPoster", x => new { x.PosterId, x.MangaId });
                    table.ForeignKey(
                        name: "FK_MangaPoster_Images_PosterId",
                        column: x => x.PosterId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MangaPoster_Mangas_MangaId",
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
                    { "3c5ae579-e150-4d4b-b27c-466084c78008", "1", "Administrator", "ADMINISTRATOR" },
                    { "44ab4366-a5c6-4fbd-b257-0b21a691ff13", "1", "User", "USER" },
                    { "4fcc00ca-d077-41fe-a7ed-69dd482ab92c", "1", "Creator", "CREATOR" },
                    { "bf2c528d-950f-4b4b-85eb-18a2a924f81a", "1", "Guest", "GUEST" },
                    { "fa1b5680-d29e-46fa-935c-263383786fa7", "1", "Moderator", "MODERATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "About", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "f57b352f-b2d7-4202-9d68-1a54d9f48935", null, 0, "2cca5a28-c5af-40b7-8b87-b56b954a71db", "admin@example.local", false, false, null, "ADMIN@EXAMPLE.LOCAL", "ADMIN", "AQAAAAEAACcQAAAAEHcnJe+yZ9BMU/ZP+V42eQaJYhEMQw4gKoLXDQFEHKcwhElL+c2NC7MkZJu2onNIdw==", null, false, "b183bef3-c72e-4e2c-8106-6baef8aaa1d0", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "3c5ae579-e150-4d4b-b27c-466084c78008", "f57b352f-b2d7-4202-9d68-1a54d9f48935" });

            migrationBuilder.CreateIndex(
                name: "IX_MangaCover_MangaId",
                table: "MangaCover",
                column: "MangaId");

            migrationBuilder.CreateIndex(
                name: "IX_MangaGenre_GenreId",
                table: "MangaGenre",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_MangaPoster_MangaId",
                table: "MangaPoster",
                column: "MangaId");
        }
    }
}
