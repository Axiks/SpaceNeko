using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NekoSpace.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateImageRelationForTest3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharacterCover_ImageEntity_CoverId1",
                table: "CharacterCover");

            migrationBuilder.DropForeignKey(
                name: "FK_CharacterPoster_ImageEntity_PosterId1",
                table: "CharacterPoster");

            migrationBuilder.DropForeignKey(
                name: "FK_Cover_Media_ImageEntity_Id",
                table: "Cover_Media");

            migrationBuilder.DropForeignKey(
                name: "FK_Poster_Media_ImageEntity_Id",
                table: "Poster_Media");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Poster_Media",
                table: "Poster_Media");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cover_Media",
                table: "Cover_Media");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4e44deca-4e0b-4153-80bd-4cbf70429b55");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7047ab19-6c8d-4df3-a396-66d7863a4d6a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "abd84f32-ccc1-41fe-9c03-c3dc4638663a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bfefb40e-430c-4ffc-8b5a-a68154277ffa");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "5535e039-44c7-48d4-9e17-6dd307303e00", "9bf61b92-b38f-43a6-8714-9c58cdb89648" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5535e039-44c7-48d4-9e17-6dd307303e00");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9bf61b92-b38f-43a6-8714-9c58cdb89648");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Poster_Media",
                newName: "MediaId1");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ImageEntity",
                newName: "ImageId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Cover_Media",
                newName: "MediaId1");

            migrationBuilder.RenameColumn(
                name: "PosterId1",
                table: "CharacterPoster",
                newName: "PosterImageId");

            migrationBuilder.RenameIndex(
                name: "IX_CharacterPoster_PosterId1",
                table: "CharacterPoster",
                newName: "IX_CharacterPoster_PosterImageId");

            migrationBuilder.RenameColumn(
                name: "CoverId1",
                table: "CharacterCover",
                newName: "CoverImageId");

            migrationBuilder.RenameIndex(
                name: "IX_CharacterCover_CoverId1",
                table: "CharacterCover",
                newName: "IX_CharacterCover_CoverImageId");

            migrationBuilder.AddColumn<Guid>(
                name: "ImageId",
                table: "Poster_Media",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ImageId",
                table: "Cover_Media",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Poster_Media",
                table: "Poster_Media",
                column: "ImageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cover_Media",
                table: "Cover_Media",
                column: "ImageId");

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
                name: "FK_Cover_Media_ImageEntity_ImageId",
                table: "Cover_Media",
                column: "ImageId",
                principalTable: "ImageEntity",
                principalColumn: "ImageId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Poster_Media_ImageEntity_ImageId",
                table: "Poster_Media",
                column: "ImageId",
                principalTable: "ImageEntity",
                principalColumn: "ImageId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharacterCover_ImageEntity_CoverImageId",
                table: "CharacterCover");

            migrationBuilder.DropForeignKey(
                name: "FK_CharacterPoster_ImageEntity_PosterImageId",
                table: "CharacterPoster");

            migrationBuilder.DropForeignKey(
                name: "FK_Cover_Media_ImageEntity_ImageId",
                table: "Cover_Media");

            migrationBuilder.DropForeignKey(
                name: "FK_Poster_Media_ImageEntity_ImageId",
                table: "Poster_Media");

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

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Poster_Media");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Cover_Media");

            migrationBuilder.RenameColumn(
                name: "MediaId1",
                table: "Poster_Media",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ImageId",
                table: "ImageEntity",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "MediaId1",
                table: "Cover_Media",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "PosterImageId",
                table: "CharacterPoster",
                newName: "PosterId1");

            migrationBuilder.RenameIndex(
                name: "IX_CharacterPoster_PosterImageId",
                table: "CharacterPoster",
                newName: "IX_CharacterPoster_PosterId1");

            migrationBuilder.RenameColumn(
                name: "CoverImageId",
                table: "CharacterCover",
                newName: "CoverId1");

            migrationBuilder.RenameIndex(
                name: "IX_CharacterCover_CoverImageId",
                table: "CharacterCover",
                newName: "IX_CharacterCover_CoverId1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Poster_Media",
                table: "Poster_Media",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cover_Media",
                table: "Cover_Media",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4e44deca-4e0b-4153-80bd-4cbf70429b55", "1", "User", "USER" },
                    { "5535e039-44c7-48d4-9e17-6dd307303e00", "1", "Administrator", "ADMINISTRATOR" },
                    { "7047ab19-6c8d-4df3-a396-66d7863a4d6a", "1", "Moderator", "MODERATOR" },
                    { "abd84f32-ccc1-41fe-9c03-c3dc4638663a", "1", "Guest", "GUEST" },
                    { "bfefb40e-430c-4ffc-8b5a-a68154277ffa", "1", "Creator", "CREATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "About", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "9bf61b92-b38f-43a6-8714-9c58cdb89648", null, 0, "965e0475-856d-42fd-809c-161c14f27f4f", "admin@example.local", false, false, null, "ADMIN@EXAMPLE.LOCAL", "ADMIN", "AQAAAAEAACcQAAAAEHcnJe+yZ9BMU/ZP+V42eQaJYhEMQw4gKoLXDQFEHKcwhElL+c2NC7MkZJu2onNIdw==", null, false, "95ee5178-c7d1-4332-8965-e21bab7edfbc", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "5535e039-44c7-48d4-9e17-6dd307303e00", "9bf61b92-b38f-43a6-8714-9c58cdb89648" });

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

            migrationBuilder.AddForeignKey(
                name: "FK_Cover_Media_ImageEntity_Id",
                table: "Cover_Media",
                column: "Id",
                principalTable: "ImageEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Poster_Media_ImageEntity_Id",
                table: "Poster_Media",
                column: "Id",
                principalTable: "ImageEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
