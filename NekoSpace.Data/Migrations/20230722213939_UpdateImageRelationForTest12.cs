using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NekoSpace.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateImageRelationForTest12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropTable(
                name: "CharacterPoster");

            migrationBuilder.DropIndex(
                name: "IX_Posters_AnimeEntityId",
                table: "Posters");

            migrationBuilder.DropIndex(
                name: "IX_Posters_MangaEntityId",
                table: "Posters");

            migrationBuilder.DropIndex(
                name: "IX_Covers_AnimeEntityId",
                table: "Covers");

            migrationBuilder.DropIndex(
                name: "IX_Covers_MangaEntityId",
                table: "Covers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "477940d8-243c-4837-85cb-e07ce664dd4c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "56110733-9eb0-4887-a563-aabd35b559a9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "73060836-93d7-4b55-bbf5-422e2e77fcf4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "83b2f3f2-036f-46a4-bacc-6565ba950df6");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "844e429f-32e2-4bc3-b66c-c38a0863b691", "6fe542c1-af58-40aa-a343-a274e89884f3" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "844e429f-32e2-4bc3-b66c-c38a0863b691");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6fe542c1-af58-40aa-a343-a274e89884f3");

            migrationBuilder.DropColumn(
                name: "AnimeEntityId",
                table: "Posters");

            migrationBuilder.DropColumn(
                name: "From",
                table: "Posters");

            migrationBuilder.DropColumn(
                name: "Large",
                table: "Posters");

            migrationBuilder.DropColumn(
                name: "MangaEntityId",
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
                name: "AnimeEntityId",
                table: "Covers");

            migrationBuilder.DropColumn(
                name: "From",
                table: "Covers");

            migrationBuilder.DropColumn(
                name: "Large",
                table: "Covers");

            migrationBuilder.DropColumn(
                name: "MangaEntityId",
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

            migrationBuilder.RenameColumn(
                name: "ImageId",
                table: "Posters",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ImageId",
                table: "Covers",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CoverImageId",
                table: "CharacterCover",
                newName: "CoverId1");

            migrationBuilder.RenameIndex(
                name: "IX_CharacterCover_CoverImageId",
                table: "CharacterCover",
                newName: "IX_CharacterCover_CoverId1");

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MediaId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MediaImageEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MediaId = table.Column<Guid>(type: "uuid", nullable: false),
                    ImageId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    MediasId = table.Column<Guid>(type: "uuid", nullable: false),
                    PostersId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaImageEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MediaImageEntity_Medias_MediaId",
                        column: x => x.MediaId,
                        principalTable: "Medias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MediaImageEntity_Medias_MediasId",
                        column: x => x.MediasId,
                        principalTable: "Medias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "139ab28a-89ce-4b04-86a6-7655de49f26a", "1", "User", "USER" },
                    { "3fefdba3-40f2-40c8-a98d-5c2b68e225fe", "1", "Moderator", "MODERATOR" },
                    { "76dbabb5-e9b7-4957-b3e6-b6997c4c1567", "1", "Guest", "GUEST" },
                    { "7dfd405c-4ff0-4654-8995-057f20ecf830", "1", "Administrator", "ADMINISTRATOR" },
                    { "b6b70f3c-b02c-4c44-8583-705083cc9e42", "1", "Creator", "CREATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "About", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "bae3db66-388f-4354-9975-a108d01e37cd", null, 0, "761d063b-39ef-4cc9-91d5-db31346888f1", "admin@example.local", false, false, null, "ADMIN@EXAMPLE.LOCAL", "ADMIN", "AQAAAAEAACcQAAAAEHcnJe+yZ9BMU/ZP+V42eQaJYhEMQw4gKoLXDQFEHKcwhElL+c2NC7MkZJu2onNIdw==", null, false, "bc7e3439-cca8-4e0c-a25a-2ae3543f1fde", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "7dfd405c-4ff0-4654-8995-057f20ecf830", "bae3db66-388f-4354-9975-a108d01e37cd" });

            migrationBuilder.CreateIndex(
                name: "IX_MediaImageEntity_ImageId",
                table: "MediaImageEntity",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaImageEntity_MediaId",
                table: "MediaImageEntity",
                column: "MediaId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaImageEntity_MediasId",
                table: "MediaImageEntity",
                column: "MediasId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaImageEntity_PostersId",
                table: "MediaImageEntity",
                column: "PostersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "MediaImageEntity");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "139ab28a-89ce-4b04-86a6-7655de49f26a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3fefdba3-40f2-40c8-a98d-5c2b68e225fe");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "76dbabb5-e9b7-4957-b3e6-b6997c4c1567");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b6b70f3c-b02c-4c44-8583-705083cc9e42");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "7dfd405c-4ff0-4654-8995-057f20ecf830", "bae3db66-388f-4354-9975-a108d01e37cd" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7dfd405c-4ff0-4654-8995-057f20ecf830");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bae3db66-388f-4354-9975-a108d01e37cd");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Posters",
                newName: "ImageId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Covers",
                newName: "ImageId");

            migrationBuilder.RenameColumn(
                name: "CoverId1",
                table: "CharacterCover",
                newName: "CoverImageId");

            migrationBuilder.RenameIndex(
                name: "IX_CharacterCover_CoverId1",
                table: "CharacterCover",
                newName: "IX_CharacterCover_CoverImageId");

            migrationBuilder.AddColumn<Guid>(
                name: "AnimeEntityId",
                table: "Posters",
                type: "uuid",
                nullable: true);

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

            migrationBuilder.AddColumn<Guid>(
                name: "MangaEntityId",
                table: "Posters",
                type: "uuid",
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

            migrationBuilder.AddColumn<Guid>(
                name: "AnimeEntityId",
                table: "Covers",
                type: "uuid",
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

            migrationBuilder.AddColumn<Guid>(
                name: "MangaEntityId",
                table: "Covers",
                type: "uuid",
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

            migrationBuilder.CreateTable(
                name: "CharacterPoster",
                columns: table => new
                {
                    PosterId = table.Column<int>(type: "integer", nullable: false),
                    CharacterId = table.Column<Guid>(type: "uuid", nullable: false),
                    PosterImageId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterPoster", x => new { x.PosterId, x.CharacterId });
                    table.ForeignKey(
                        name: "FK_CharacterPoster_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "477940d8-243c-4837-85cb-e07ce664dd4c", "1", "Moderator", "MODERATOR" },
                    { "56110733-9eb0-4887-a563-aabd35b559a9", "1", "Creator", "CREATOR" },
                    { "73060836-93d7-4b55-bbf5-422e2e77fcf4", "1", "User", "USER" },
                    { "83b2f3f2-036f-46a4-bacc-6565ba950df6", "1", "Guest", "GUEST" },
                    { "844e429f-32e2-4bc3-b66c-c38a0863b691", "1", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "About", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "6fe542c1-af58-40aa-a343-a274e89884f3", null, 0, "40aebee0-7f31-4333-b369-46699ab2d865", "admin@example.local", false, false, null, "ADMIN@EXAMPLE.LOCAL", "ADMIN", "AQAAAAEAACcQAAAAEHcnJe+yZ9BMU/ZP+V42eQaJYhEMQw4gKoLXDQFEHKcwhElL+c2NC7MkZJu2onNIdw==", null, false, "2b2fff9d-dd59-40df-b109-617c729a4ea7", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "844e429f-32e2-4bc3-b66c-c38a0863b691", "6fe542c1-af58-40aa-a343-a274e89884f3" });

            migrationBuilder.CreateIndex(
                name: "IX_Posters_AnimeEntityId",
                table: "Posters",
                column: "AnimeEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Posters_MangaEntityId",
                table: "Posters",
                column: "MangaEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Covers_AnimeEntityId",
                table: "Covers",
                column: "AnimeEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Covers_MangaEntityId",
                table: "Covers",
                column: "MangaEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterPoster_CharacterId",
                table: "CharacterPoster",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterPoster_PosterImageId",
                table: "CharacterPoster",
                column: "PosterImageId");

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
    }
}
