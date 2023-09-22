using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NekoSpace.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateImageRelationForTest16 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "47bb23fb-152f-4980-9191-2198a0e1e6a2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6a69ba74-f024-42d0-be01-7ec2ac45d166");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ca497994-e231-42d2-849e-184af3ba01f5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fe4a3a30-4a41-48cb-b0c2-0ad9021ed0ff");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f3a663ff-040a-4b2b-a6ea-f1f4086d7539", "1d029781-e052-4c72-b025-69f9c025decc" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f3a663ff-040a-4b2b-a6ea-f1f4086d7539");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1d029781-e052-4c72-b025-69f9c025decc");

            migrationBuilder.CreateTable(
                name: "MangaCoverEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Original = table.Column<string>(type: "text", nullable: false),
                    Large = table.Column<string>(type: "text", nullable: true),
                    Medium = table.Column<string>(type: "text", nullable: true),
                    Small = table.Column<string>(type: "text", nullable: true),
                    From = table.Column<int>(type: "integer", nullable: false),
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
                    Original = table.Column<string>(type: "text", nullable: false),
                    Large = table.Column<string>(type: "text", nullable: true),
                    Medium = table.Column<string>(type: "text", nullable: true),
                    Small = table.Column<string>(type: "text", nullable: true),
                    From = table.Column<int>(type: "integer", nullable: false),
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "47bb23fb-152f-4980-9191-2198a0e1e6a2", "1", "User", "USER" },
                    { "6a69ba74-f024-42d0-be01-7ec2ac45d166", "1", "Moderator", "MODERATOR" },
                    { "ca497994-e231-42d2-849e-184af3ba01f5", "1", "Guest", "GUEST" },
                    { "f3a663ff-040a-4b2b-a6ea-f1f4086d7539", "1", "Administrator", "ADMINISTRATOR" },
                    { "fe4a3a30-4a41-48cb-b0c2-0ad9021ed0ff", "1", "Creator", "CREATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "About", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1d029781-e052-4c72-b025-69f9c025decc", null, 0, "bac635ed-28d2-4f94-890c-bf15b94ab761", "admin@example.local", false, false, null, "ADMIN@EXAMPLE.LOCAL", "ADMIN", "AQAAAAEAACcQAAAAEHcnJe+yZ9BMU/ZP+V42eQaJYhEMQw4gKoLXDQFEHKcwhElL+c2NC7MkZJu2onNIdw==", null, false, "960628d0-fbbd-43d6-b6ae-7b9d2f2d9874", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "f3a663ff-040a-4b2b-a6ea-f1f4086d7539", "1d029781-e052-4c72-b025-69f9c025decc" });
        }
    }
}
