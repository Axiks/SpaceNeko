using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NekoSpace.API.Migrations
{
    public partial class NewUserFunc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "06c1f246-aca7-41fe-a784-60dc402f0cb5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "13afc6d7-1a2a-4f75-893b-0d67c6edc17d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1f58423c-19cc-4128-b1e2-fadce0ddd2c0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "55b3e1ff-6b00-48ec-9569-138766573d84");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b2f23a80-fccf-469f-8870-0ccacac71228", "a48f5e56-e445-40a2-91b3-df75b63cf306" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b2f23a80-fccf-469f-8870-0ccacac71228");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a48f5e56-e445-40a2-91b3-df75b63cf306");

            migrationBuilder.AlterColumn<bool>(
                name: "IsHidden",
                table: "AnimeTitle",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.CreateTable(
                name: "UserAnimeViewingStatus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    AnimeId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAnimeViewingStatus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAnimeViewingStatus_Animes_AnimeId",
                        column: x => x.AnimeId,
                        principalTable: "Animes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserAnimeViewingStatus_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserFavoriteAnime",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AnimeId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFavoriteAnime", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserFavoriteAnime_Animes_AnimeId",
                        column: x => x.AnimeId,
                        principalTable: "Animes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserFavoriteAnime_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRatingAnime",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Rating = table.Column<float>(type: "real", nullable: false),
                    AnimeId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRatingAnime", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRatingAnime_Animes_AnimeId",
                        column: x => x.AnimeId,
                        principalTable: "Animes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRatingAnime_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "260d8484-a9fd-4eda-a878-7cc16c0ee0f4", "1", "Creator", "CREATOR" },
                    { "420a0525-0618-4ed6-8931-901ab706b66d", "1", "Administrator", "ADMINISTRATOR" },
                    { "e14d2970-d835-4340-acd0-62d0936d448c", "1", "Guest", "GUEST" },
                    { "fb881781-a6d2-41ec-b05c-152175b218c8", "1", "User", "USER" },
                    { "fdad698b-3bfb-42e0-9c09-8cb6de811f92", "1", "Moderator", "MODERATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "About", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "951ade4a-9c51-4060-b976-78bb25c0cd72", null, 0, "37d0ae44-9243-404c-9e4a-86c5254e8831", "admin@example.local", false, false, null, "ADMIN@EXAMPLE.LOCAL", "ADMIN", "AQAAAAEAACcQAAAAEHcnJe+yZ9BMU/ZP+V42eQaJYhEMQw4gKoLXDQFEHKcwhElL+c2NC7MkZJu2onNIdw==", null, false, "b0f98817-df93-4a1c-8ca6-05621562b701", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "420a0525-0618-4ed6-8931-901ab706b66d", "951ade4a-9c51-4060-b976-78bb25c0cd72" });

            migrationBuilder.CreateIndex(
                name: "IX_UserAnimeViewingStatus_AnimeId",
                table: "UserAnimeViewingStatus",
                column: "AnimeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAnimeViewingStatus_UserId",
                table: "UserAnimeViewingStatus",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFavoriteAnime_AnimeId",
                table: "UserFavoriteAnime",
                column: "AnimeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFavoriteAnime_UserId",
                table: "UserFavoriteAnime",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRatingAnime_AnimeId",
                table: "UserRatingAnime",
                column: "AnimeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRatingAnime_UserId",
                table: "UserRatingAnime",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserAnimeViewingStatus");

            migrationBuilder.DropTable(
                name: "UserFavoriteAnime");

            migrationBuilder.DropTable(
                name: "UserRatingAnime");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "260d8484-a9fd-4eda-a878-7cc16c0ee0f4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e14d2970-d835-4340-acd0-62d0936d448c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fb881781-a6d2-41ec-b05c-152175b218c8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fdad698b-3bfb-42e0-9c09-8cb6de811f92");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "420a0525-0618-4ed6-8931-901ab706b66d", "951ade4a-9c51-4060-b976-78bb25c0cd72" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "420a0525-0618-4ed6-8931-901ab706b66d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "951ade4a-9c51-4060-b976-78bb25c0cd72");

            migrationBuilder.AlterColumn<bool>(
                name: "IsHidden",
                table: "AnimeTitle",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "06c1f246-aca7-41fe-a784-60dc402f0cb5", "1", "Moderator", "MODERATOR" },
                    { "13afc6d7-1a2a-4f75-893b-0d67c6edc17d", "1", "User", "USER" },
                    { "1f58423c-19cc-4128-b1e2-fadce0ddd2c0", "1", "Creator", "CREATOR" },
                    { "55b3e1ff-6b00-48ec-9569-138766573d84", "1", "Guest", "GUEST" },
                    { "b2f23a80-fccf-469f-8870-0ccacac71228", "1", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "About", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "a48f5e56-e445-40a2-91b3-df75b63cf306", null, 0, "ceb39c68-ae4e-423b-8cfb-2afd8ead4a25", "admin@example.local", false, false, null, "ADMIN@EXAMPLE.LOCAL", "ADMIN", "AQAAAAEAACcQAAAAEHcnJe+yZ9BMU/ZP+V42eQaJYhEMQw4gKoLXDQFEHKcwhElL+c2NC7MkZJu2onNIdw==", null, false, "50d8e8c6-fce1-4ecc-b234-d64616529637", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "b2f23a80-fccf-469f-8870-0ccacac71228", "a48f5e56-e445-40a2-91b3-df75b63cf306" });
        }
    }
}
