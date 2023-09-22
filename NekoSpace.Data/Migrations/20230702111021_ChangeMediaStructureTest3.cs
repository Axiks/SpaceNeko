using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NekoSpace.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeMediaStructureTest3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssociatedService_Animes_MediaEntityId",
                table: "AssociatedService");

            migrationBuilder.DropForeignKey(
                name: "FK_AssociatedService_Characters_MediaEntityId",
                table: "AssociatedService");

            migrationBuilder.DropForeignKey(
                name: "FK_AssociatedService_Mangas_MediaEntityId",
                table: "AssociatedService");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "527532ad-0696-40c4-b4f4-ff1bb256001f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "54d57874-4fb5-4592-9c7b-04b941465ece");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5acaa349-fa64-4d61-bd24-5495629b103a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bba55f4c-ffc3-4866-a12a-2b09b3b1da78");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "661c618c-9119-4bfb-8797-d4ab22867221", "1acbd544-1d3e-4225-8ad2-def1c51d4119" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "661c618c-9119-4bfb-8797-d4ab22867221");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1acbd544-1d3e-4225-8ad2-def1c51d4119");

            migrationBuilder.RenameColumn(
                name: "MediaEntityId",
                table: "AssociatedService",
                newName: "MangaId");

            migrationBuilder.RenameIndex(
                name: "IX_AssociatedService_MediaEntityId",
                table: "AssociatedService",
                newName: "IX_AssociatedService_MangaId");

            migrationBuilder.AddColumn<Guid>(
                name: "AnimeId",
                table: "AssociatedService",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CharacterId",
                table: "AssociatedService",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "AssociatedService",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "AssociatedService",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "59084f9e-a517-40b7-80f4-8463a5f8d16f", "1", "User", "USER" },
                    { "945c71fa-0c2e-4a36-833c-bd45f70300cb", "1", "Creator", "CREATOR" },
                    { "b4d9a12b-eeaa-4a17-a79f-06627255065d", "1", "Guest", "GUEST" },
                    { "c8450a09-371f-48aa-8e84-2a6f7f7ee181", "1", "Administrator", "ADMINISTRATOR" },
                    { "e6c4d01f-09a1-4c0b-8205-7c42ad257125", "1", "Moderator", "MODERATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "About", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "ce2d0255-95b8-4f0d-ac76-23f8951f452a", null, 0, "7f59025a-cf84-475d-916f-7a239a6ffd45", "admin@example.local", false, false, null, "ADMIN@EXAMPLE.LOCAL", "ADMIN", "AQAAAAEAACcQAAAAEHcnJe+yZ9BMU/ZP+V42eQaJYhEMQw4gKoLXDQFEHKcwhElL+c2NC7MkZJu2onNIdw==", null, false, "ad40f48c-3713-4056-b318-cf75785a259c", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "c8450a09-371f-48aa-8e84-2a6f7f7ee181", "ce2d0255-95b8-4f0d-ac76-23f8951f452a" });

            migrationBuilder.CreateIndex(
                name: "IX_AssociatedService_AnimeId",
                table: "AssociatedService",
                column: "AnimeId");

            migrationBuilder.CreateIndex(
                name: "IX_AssociatedService_CharacterId",
                table: "AssociatedService",
                column: "CharacterId");

            migrationBuilder.AddForeignKey(
                name: "FK_AssociatedService_Animes_AnimeId",
                table: "AssociatedService",
                column: "AnimeId",
                principalTable: "Animes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AssociatedService_Characters_CharacterId",
                table: "AssociatedService",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AssociatedService_Mangas_MangaId",
                table: "AssociatedService",
                column: "MangaId",
                principalTable: "Mangas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssociatedService_Animes_AnimeId",
                table: "AssociatedService");

            migrationBuilder.DropForeignKey(
                name: "FK_AssociatedService_Characters_CharacterId",
                table: "AssociatedService");

            migrationBuilder.DropForeignKey(
                name: "FK_AssociatedService_Mangas_MangaId",
                table: "AssociatedService");

            migrationBuilder.DropIndex(
                name: "IX_AssociatedService_AnimeId",
                table: "AssociatedService");

            migrationBuilder.DropIndex(
                name: "IX_AssociatedService_CharacterId",
                table: "AssociatedService");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "59084f9e-a517-40b7-80f4-8463a5f8d16f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "945c71fa-0c2e-4a36-833c-bd45f70300cb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b4d9a12b-eeaa-4a17-a79f-06627255065d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e6c4d01f-09a1-4c0b-8205-7c42ad257125");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c8450a09-371f-48aa-8e84-2a6f7f7ee181", "ce2d0255-95b8-4f0d-ac76-23f8951f452a" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c8450a09-371f-48aa-8e84-2a6f7f7ee181");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ce2d0255-95b8-4f0d-ac76-23f8951f452a");

            migrationBuilder.DropColumn(
                name: "AnimeId",
                table: "AssociatedService");

            migrationBuilder.DropColumn(
                name: "CharacterId",
                table: "AssociatedService");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "AssociatedService");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "AssociatedService");

            migrationBuilder.RenameColumn(
                name: "MangaId",
                table: "AssociatedService",
                newName: "MediaEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_AssociatedService_MangaId",
                table: "AssociatedService",
                newName: "IX_AssociatedService_MediaEntityId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "527532ad-0696-40c4-b4f4-ff1bb256001f", "1", "Guest", "GUEST" },
                    { "54d57874-4fb5-4592-9c7b-04b941465ece", "1", "Creator", "CREATOR" },
                    { "5acaa349-fa64-4d61-bd24-5495629b103a", "1", "User", "USER" },
                    { "661c618c-9119-4bfb-8797-d4ab22867221", "1", "Administrator", "ADMINISTRATOR" },
                    { "bba55f4c-ffc3-4866-a12a-2b09b3b1da78", "1", "Moderator", "MODERATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "About", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1acbd544-1d3e-4225-8ad2-def1c51d4119", null, 0, "86d16432-c89c-49f8-98b4-fb62c53a8857", "admin@example.local", false, false, null, "ADMIN@EXAMPLE.LOCAL", "ADMIN", "AQAAAAEAACcQAAAAEHcnJe+yZ9BMU/ZP+V42eQaJYhEMQw4gKoLXDQFEHKcwhElL+c2NC7MkZJu2onNIdw==", null, false, "5ac2bc0c-fbc3-4aa3-88aa-88198b525f51", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "661c618c-9119-4bfb-8797-d4ab22867221", "1acbd544-1d3e-4225-8ad2-def1c51d4119" });

            migrationBuilder.AddForeignKey(
                name: "FK_AssociatedService_Animes_MediaEntityId",
                table: "AssociatedService",
                column: "MediaEntityId",
                principalTable: "Animes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AssociatedService_Characters_MediaEntityId",
                table: "AssociatedService",
                column: "MediaEntityId",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AssociatedService_Mangas_MediaEntityId",
                table: "AssociatedService",
                column: "MediaEntityId",
                principalTable: "Mangas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
