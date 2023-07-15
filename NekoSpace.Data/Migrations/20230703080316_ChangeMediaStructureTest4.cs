using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NekoSpace.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeMediaStructureTest4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "CreatedAt",
                table: "Mangas");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Mangas");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "AnimeId",
                table: "AssociatedService");

            migrationBuilder.DropColumn(
                name: "CharacterId",
                table: "AssociatedService");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Animes");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Animes");

            migrationBuilder.RenameColumn(
                name: "MangaId",
                table: "AssociatedService",
                newName: "MediaId");

            migrationBuilder.RenameIndex(
                name: "IX_AssociatedService_MangaId",
                table: "AssociatedService",
                newName: "IX_AssociatedService_MediaId");

            migrationBuilder.CreateTable(
                name: "MediaEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaEntity", x => x.Id);
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

            migrationBuilder.AddForeignKey(
                name: "FK_Animes_MediaEntity_Id",
                table: "Animes",
                column: "Id",
                principalTable: "MediaEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AssociatedService_MediaEntity_MediaId",
                table: "AssociatedService",
                column: "MediaId",
                principalTable: "MediaEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_MediaEntity_Id",
                table: "Characters",
                column: "Id",
                principalTable: "MediaEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Mangas_MediaEntity_Id",
                table: "Mangas",
                column: "Id",
                principalTable: "MediaEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animes_MediaEntity_Id",
                table: "Animes");

            migrationBuilder.DropForeignKey(
                name: "FK_AssociatedService_MediaEntity_MediaId",
                table: "AssociatedService");

            migrationBuilder.DropForeignKey(
                name: "FK_Characters_MediaEntity_Id",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Mangas_MediaEntity_Id",
                table: "Mangas");

            migrationBuilder.DropTable(
                name: "MediaEntity");

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

            migrationBuilder.RenameColumn(
                name: "MediaId",
                table: "AssociatedService",
                newName: "MangaId");

            migrationBuilder.RenameIndex(
                name: "IX_AssociatedService_MediaId",
                table: "AssociatedService",
                newName: "IX_AssociatedService_MangaId");

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
    }
}
