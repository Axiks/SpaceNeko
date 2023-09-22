using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NekoSpace.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateImageRelationForTest13 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MediaImageEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Images",
                table: "Images");

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

            migrationBuilder.DropColumn(
                name: "MediaId",
                table: "Posters");

            migrationBuilder.DropColumn(
                name: "MediaId",
                table: "Covers");

            migrationBuilder.DropColumn(
                name: "MediaId",
                table: "Images");

            migrationBuilder.RenameTable(
                name: "Images",
                newName: "ImageEntity");

            migrationBuilder.AddColumn<int>(
                name: "From",
                table: "ImageEntity",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Large",
                table: "ImageEntity",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Medium",
                table: "ImageEntity",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Original",
                table: "ImageEntity",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Small",
                table: "ImageEntity",
                type: "text",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ImageEntity",
                table: "ImageEntity",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Cover_Media",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AnimeId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cover_Media", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cover_Media_Animes_AnimeId",
                        column: x => x.AnimeId,
                        principalTable: "Animes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cover_Media_Covers_Id",
                        column: x => x.Id,
                        principalTable: "Covers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Poster_Media",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AnimeId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Poster_Media", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Poster_Media_Animes_AnimeId",
                        column: x => x.AnimeId,
                        principalTable: "Animes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Poster_Media_Posters_Id",
                        column: x => x.Id,
                        principalTable: "Posters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0a2d7862-edf8-4026-bc0f-6eff1c756c33", "1", "Administrator", "ADMINISTRATOR" },
                    { "3ff43889-ef56-4e11-ab68-5320a769022c", "1", "Guest", "GUEST" },
                    { "a49fa0f6-7b16-48ee-8ee8-1b48b4a82ba2", "1", "User", "USER" },
                    { "b9d3aeea-ab1d-4dd1-a4ca-65971f793352", "1", "Creator", "CREATOR" },
                    { "d54241d9-3330-438a-9d9e-06a74e87cc01", "1", "Moderator", "MODERATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "About", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "2a9ec42f-23be-4bbd-b7e2-b47e7c25c950", null, 0, "4c61b3a5-bd02-4486-bc36-de7128b9cf69", "admin@example.local", false, false, null, "ADMIN@EXAMPLE.LOCAL", "ADMIN", "AQAAAAEAACcQAAAAEHcnJe+yZ9BMU/ZP+V42eQaJYhEMQw4gKoLXDQFEHKcwhElL+c2NC7MkZJu2onNIdw==", null, false, "59e47f2f-fbd5-42e1-bfdf-df8a34283dcd", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "0a2d7862-edf8-4026-bc0f-6eff1c756c33", "2a9ec42f-23be-4bbd-b7e2-b47e7c25c950" });

            migrationBuilder.CreateIndex(
                name: "IX_Cover_Media_AnimeId",
                table: "Cover_Media",
                column: "AnimeId");

            migrationBuilder.CreateIndex(
                name: "IX_Poster_Media_AnimeId",
                table: "Poster_Media",
                column: "AnimeId");

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterCover_ImageEntity_CoverId1",
                table: "CharacterCover",
                column: "CoverId1",
                principalTable: "ImageEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Covers_ImageEntity_Id",
                table: "Covers",
                column: "Id",
                principalTable: "ImageEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Posters_ImageEntity_Id",
                table: "Posters",
                column: "Id",
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
                name: "FK_Covers_ImageEntity_Id",
                table: "Covers");

            migrationBuilder.DropForeignKey(
                name: "FK_Posters_ImageEntity_Id",
                table: "Posters");

            migrationBuilder.DropTable(
                name: "Cover_Media");

            migrationBuilder.DropTable(
                name: "Poster_Media");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ImageEntity",
                table: "ImageEntity");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3ff43889-ef56-4e11-ab68-5320a769022c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a49fa0f6-7b16-48ee-8ee8-1b48b4a82ba2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b9d3aeea-ab1d-4dd1-a4ca-65971f793352");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d54241d9-3330-438a-9d9e-06a74e87cc01");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0a2d7862-edf8-4026-bc0f-6eff1c756c33", "2a9ec42f-23be-4bbd-b7e2-b47e7c25c950" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0a2d7862-edf8-4026-bc0f-6eff1c756c33");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2a9ec42f-23be-4bbd-b7e2-b47e7c25c950");

            migrationBuilder.DropColumn(
                name: "From",
                table: "ImageEntity");

            migrationBuilder.DropColumn(
                name: "Large",
                table: "ImageEntity");

            migrationBuilder.DropColumn(
                name: "Medium",
                table: "ImageEntity");

            migrationBuilder.DropColumn(
                name: "Original",
                table: "ImageEntity");

            migrationBuilder.DropColumn(
                name: "Small",
                table: "ImageEntity");

            migrationBuilder.RenameTable(
                name: "ImageEntity",
                newName: "Images");

            migrationBuilder.AddColumn<Guid>(
                name: "MediaId",
                table: "Posters",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "MediaId",
                table: "Covers",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "MediaId",
                table: "Images",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Images",
                table: "Images",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "MediaImageEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ImageId = table.Column<Guid>(type: "uuid", nullable: false),
                    MediaId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    MediasId = table.Column<Guid>(type: "uuid", nullable: false),
                    PostersId = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
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
    }
}
