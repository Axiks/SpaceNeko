using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NekoSpace.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateImageRelationForTest17 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MangaCoverEntity");

            migrationBuilder.DropTable(
                name: "MangaPosterEntity");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "50bb6af3-2aa6-40c3-81bb-5363b3c41a2d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ab38670d-36cc-463f-9a74-09333b4fc487");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "af801b90-e53e-4953-bdf7-8967429fad8e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e7c2d034-b74b-4617-905a-b76b77aa9174");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d421848f-e367-46c5-a766-10f0dd95197c", "33865243-d90e-4867-8234-ad2508904521" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d421848f-e367-46c5-a766-10f0dd95197c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "33865243-d90e-4867-8234-ad2508904521");

            migrationBuilder.CreateTable(
                name: "MediaPosterEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Original = table.Column<string>(type: "text", nullable: false),
                    Large = table.Column<string>(type: "text", nullable: true),
                    Medium = table.Column<string>(type: "text", nullable: true),
                    Small = table.Column<string>(type: "text", nullable: true),
                    From = table.Column<int>(type: "integer", nullable: false),
                    MediaId = table.Column<Guid>(type: "uuid", nullable: false),
                    ImageId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaPosterEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MediaPosterEntity_Medias_MediaId",
                        column: x => x.MediaId,
                        principalTable: "Medias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0ec68f94-23d1-44c3-91b4-a64fcebef41a", "1", "User", "USER" },
                    { "20d82e54-bc99-43e4-b02e-c76f8bae6c26", "1", "Guest", "GUEST" },
                    { "39d3ad6b-f228-451e-87d6-9bcf2526d45b", "1", "Creator", "CREATOR" },
                    { "3d2b8799-b1c5-4342-8a21-03663529fb42", "1", "Moderator", "MODERATOR" },
                    { "c1449d70-e5f4-4695-abc9-75e805f6b8b9", "1", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "About", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "cef966d8-9395-4902-b9df-521dd283645a", null, 0, "cdca0240-c8be-4c0e-ae25-4022b8655d0b", "admin@example.local", false, false, null, "ADMIN@EXAMPLE.LOCAL", "ADMIN", "AQAAAAEAACcQAAAAEHcnJe+yZ9BMU/ZP+V42eQaJYhEMQw4gKoLXDQFEHKcwhElL+c2NC7MkZJu2onNIdw==", null, false, "941fdd29-9c44-4291-9c92-96e735d387b7", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "c1449d70-e5f4-4695-abc9-75e805f6b8b9", "cef966d8-9395-4902-b9df-521dd283645a" });

            migrationBuilder.CreateIndex(
                name: "IX_MediaPosterEntity_ImageId",
                table: "MediaPosterEntity",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaPosterEntity_MediaId",
                table: "MediaPosterEntity",
                column: "MediaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MediaPosterEntity");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0ec68f94-23d1-44c3-91b4-a64fcebef41a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "20d82e54-bc99-43e4-b02e-c76f8bae6c26");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "39d3ad6b-f228-451e-87d6-9bcf2526d45b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d2b8799-b1c5-4342-8a21-03663529fb42");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c1449d70-e5f4-4695-abc9-75e805f6b8b9", "cef966d8-9395-4902-b9df-521dd283645a" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c1449d70-e5f4-4695-abc9-75e805f6b8b9");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cef966d8-9395-4902-b9df-521dd283645a");

            migrationBuilder.CreateTable(
                name: "MangaCoverEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    From = table.Column<int>(type: "integer", nullable: false),
                    Large = table.Column<string>(type: "text", nullable: true),
                    Medium = table.Column<string>(type: "text", nullable: true),
                    Original = table.Column<string>(type: "text", nullable: false),
                    Small = table.Column<string>(type: "text", nullable: true),
                    MangaId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MangaCoverEntity", x => x.Id);
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
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    From = table.Column<int>(type: "integer", nullable: false),
                    Large = table.Column<string>(type: "text", nullable: true),
                    Medium = table.Column<string>(type: "text", nullable: true),
                    Original = table.Column<string>(type: "text", nullable: false),
                    Small = table.Column<string>(type: "text", nullable: true),
                    MangaId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MangaPosterEntity", x => x.Id);
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
                    { "50bb6af3-2aa6-40c3-81bb-5363b3c41a2d", "1", "Guest", "GUEST" },
                    { "ab38670d-36cc-463f-9a74-09333b4fc487", "1", "Creator", "CREATOR" },
                    { "af801b90-e53e-4953-bdf7-8967429fad8e", "1", "Moderator", "MODERATOR" },
                    { "d421848f-e367-46c5-a766-10f0dd95197c", "1", "Administrator", "ADMINISTRATOR" },
                    { "e7c2d034-b74b-4617-905a-b76b77aa9174", "1", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "About", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "33865243-d90e-4867-8234-ad2508904521", null, 0, "a11c8c8a-1cb3-452c-80b0-fe5542b2e8b0", "admin@example.local", false, false, null, "ADMIN@EXAMPLE.LOCAL", "ADMIN", "AQAAAAEAACcQAAAAEHcnJe+yZ9BMU/ZP+V42eQaJYhEMQw4gKoLXDQFEHKcwhElL+c2NC7MkZJu2onNIdw==", null, false, "b4d178dd-3d9c-46cd-b03e-f0b083970f19", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "d421848f-e367-46c5-a766-10f0dd95197c", "33865243-d90e-4867-8234-ad2508904521" });

            migrationBuilder.CreateIndex(
                name: "IX_MangaCoverEntity_MangaId",
                table: "MangaCoverEntity",
                column: "MangaId");

            migrationBuilder.CreateIndex(
                name: "IX_MangaPosterEntity_MangaId",
                table: "MangaPosterEntity",
                column: "MangaId");
        }
    }
}
