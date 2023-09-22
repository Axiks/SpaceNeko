using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NekoSpace.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateImageRelationForTest8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44e76cb8-9b20-41b6-9de7-adca87ea42ef");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a24d75f5-95d2-4c60-8894-d0cd3e63fb9e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a8a32d31-96c1-49a2-b327-076f1495ab17");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dfddea2a-ea78-4e0e-a75b-f33fc6c50c32");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3ea0129a-1938-4ad0-9a36-f09d36ed8cc8", "333b0692-2a36-4151-96a4-11e84412a1d9" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3ea0129a-1938-4ad0-9a36-f09d36ed8cc8");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "333b0692-2a36-4151-96a4-11e84412a1d9");

            migrationBuilder.DropColumn(
                name: "From",
                table: "Posters");

            migrationBuilder.DropColumn(
                name: "Large",
                table: "Posters");

            migrationBuilder.DropColumn(
                name: "MediaId",
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
                name: "CreatedAt",
                table: "Mangas");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Mangas");

            migrationBuilder.DropColumn(
                name: "From",
                table: "Covers");

            migrationBuilder.DropColumn(
                name: "Large",
                table: "Covers");

            migrationBuilder.DropColumn(
                name: "MediaId",
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

            migrationBuilder.CreateTable(
                name: "ImageEntity",
                columns: table => new
                {
                    ImageId = table.Column<Guid>(type: "uuid", nullable: false),
                    MediaId = table.Column<Guid>(type: "uuid", nullable: false),
                    Original = table.Column<string>(type: "text", nullable: false),
                    Large = table.Column<string>(type: "text", nullable: true),
                    Medium = table.Column<string>(type: "text", nullable: true),
                    Small = table.Column<string>(type: "text", nullable: true),
                    From = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageEntity", x => x.ImageId);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0c840c13-7df9-45ff-9758-3f1be74d1aea", "1", "Creator", "CREATOR" },
                    { "353f5cad-bf2e-40de-a78e-996a0c20a50f", "1", "Guest", "GUEST" },
                    { "66b50987-3a9f-41ef-92c1-fea1c6c69a9b", "1", "Moderator", "MODERATOR" },
                    { "b39ff557-2b01-473e-8a9f-dbbc29df1162", "1", "User", "USER" },
                    { "e77345ed-4959-4455-8354-75eb8a44dac4", "1", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "About", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "0bc7b54e-0c52-494f-883f-39a53432d6ba", null, 0, "9adb2154-30c7-46dc-86cc-0f59d8aff304", "admin@example.local", false, false, null, "ADMIN@EXAMPLE.LOCAL", "ADMIN", "AQAAAAEAACcQAAAAEHcnJe+yZ9BMU/ZP+V42eQaJYhEMQw4gKoLXDQFEHKcwhElL+c2NC7MkZJu2onNIdw==", null, false, "0aad8d1c-78b0-46a4-9dec-542a506ad7b8", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "e77345ed-4959-4455-8354-75eb8a44dac4", "0bc7b54e-0c52-494f-883f-39a53432d6ba" });

            migrationBuilder.AddForeignKey(
                name: "FK_Animes_Medias_Id",
                table: "Animes",
                column: "Id",
                principalTable: "Medias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AssociatedService_Medias_MediaId",
                table: "AssociatedService",
                column: "MediaId",
                principalTable: "Medias",
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
                name: "FK_Characters_Medias_Id",
                table: "Characters",
                column: "Id",
                principalTable: "Medias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Covers_ImageEntity_ImageId",
                table: "Covers",
                column: "ImageId",
                principalTable: "ImageEntity",
                principalColumn: "ImageId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Mangas_Medias_Id",
                table: "Mangas",
                column: "Id",
                principalTable: "Medias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Posters_ImageEntity_ImageId",
                table: "Posters",
                column: "ImageId",
                principalTable: "ImageEntity",
                principalColumn: "ImageId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animes_Medias_Id",
                table: "Animes");

            migrationBuilder.DropForeignKey(
                name: "FK_AssociatedService_Medias_MediaId",
                table: "AssociatedService");

            migrationBuilder.DropForeignKey(
                name: "FK_CharacterCover_ImageEntity_CoverImageId",
                table: "CharacterCover");

            migrationBuilder.DropForeignKey(
                name: "FK_CharacterPoster_ImageEntity_PosterImageId",
                table: "CharacterPoster");

            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Medias_Id",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Covers_ImageEntity_ImageId",
                table: "Covers");

            migrationBuilder.DropForeignKey(
                name: "FK_Mangas_Medias_Id",
                table: "Mangas");

            migrationBuilder.DropForeignKey(
                name: "FK_Posters_ImageEntity_ImageId",
                table: "Posters");

            migrationBuilder.DropTable(
                name: "ImageEntity");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0c840c13-7df9-45ff-9758-3f1be74d1aea");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "353f5cad-bf2e-40de-a78e-996a0c20a50f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "66b50987-3a9f-41ef-92c1-fea1c6c69a9b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b39ff557-2b01-473e-8a9f-dbbc29df1162");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e77345ed-4959-4455-8354-75eb8a44dac4", "0bc7b54e-0c52-494f-883f-39a53432d6ba" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e77345ed-4959-4455-8354-75eb8a44dac4");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0bc7b54e-0c52-494f-883f-39a53432d6ba");

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
                name: "MediaId",
                table: "Posters",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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
                name: "MediaId",
                table: "Covers",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3ea0129a-1938-4ad0-9a36-f09d36ed8cc8", "1", "Administrator", "ADMINISTRATOR" },
                    { "44e76cb8-9b20-41b6-9de7-adca87ea42ef", "1", "Moderator", "MODERATOR" },
                    { "a24d75f5-95d2-4c60-8894-d0cd3e63fb9e", "1", "Creator", "CREATOR" },
                    { "a8a32d31-96c1-49a2-b327-076f1495ab17", "1", "User", "USER" },
                    { "dfddea2a-ea78-4e0e-a75b-f33fc6c50c32", "1", "Guest", "GUEST" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "About", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "333b0692-2a36-4151-96a4-11e84412a1d9", null, 0, "7b22f6c8-992b-459a-9122-929fd7533dcd", "admin@example.local", false, false, null, "ADMIN@EXAMPLE.LOCAL", "ADMIN", "AQAAAAEAACcQAAAAEHcnJe+yZ9BMU/ZP+V42eQaJYhEMQw4gKoLXDQFEHKcwhElL+c2NC7MkZJu2onNIdw==", null, false, "dab7a5b7-bf8f-4dcf-82b8-e4f86b45f664", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "3ea0129a-1938-4ad0-9a36-f09d36ed8cc8", "333b0692-2a36-4151-96a4-11e84412a1d9" });
        }
    }
}
