using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NekoSpace.API.Migrations
{
    public partial class addAnotherServiceRelationCharacterFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnotherCharacterService");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5203f35d-ca60-4483-bf11-5b940fee5c82");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "838ed798-6f4e-4d5a-b330-9f5ae3584339");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c7eda508-5c74-49f1-a483-f2a2d34ec701");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cc6138ac-99ab-4a5a-a141-7810dea21aa6");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d7f10b8a-992b-454d-8e53-f460e6cd0b7b", "0295969a-6c95-495b-9423-1df3adf8d3bd" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7f10b8a-992b-454d-8e53-f460e6cd0b7b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0295969a-6c95-495b-9423-1df3adf8d3bd");

            migrationBuilder.AddColumn<int>(
                name: "AnilistId",
                table: "Characters",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AnimeDBId",
                table: "Characters",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MyAnimeList",
                table: "Characters",
                type: "integer",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a4601ac0-3b6d-4061-9a0c-422a5c5c8cee", "1", "Guest", "GUEST" },
                    { "a472c44f-3447-4fd5-b1a2-3c4f388a89a8", "1", "Administrator", "ADMINISTRATOR" },
                    { "c28c83af-4527-46fb-b87a-e5c0ee9fc157", "1", "Moderator", "MODERATOR" },
                    { "e80561c2-fccf-44f4-8de2-1ed626a21615", "1", "Creator", "CREATOR" },
                    { "f6df8551-0db6-4260-82b0-fcd793802c6c", "1", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "About", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "4a499c85-0d86-42c2-81e6-e3f03dabe1ca", null, 0, "6a12ad59-41d2-4a53-9418-d3004c4135a5", "admin@example.local", false, false, null, "ADMIN@EXAMPLE.LOCAL", "ADMIN", "AQAAAAEAACcQAAAAEHcnJe+yZ9BMU/ZP+V42eQaJYhEMQw4gKoLXDQFEHKcwhElL+c2NC7MkZJu2onNIdw==", null, false, "fc8bab89-be7b-4989-92b2-39f5a11e45a2", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "a472c44f-3447-4fd5-b1a2-3c4f388a89a8", "4a499c85-0d86-42c2-81e6-e3f03dabe1ca" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a4601ac0-3b6d-4061-9a0c-422a5c5c8cee");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c28c83af-4527-46fb-b87a-e5c0ee9fc157");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e80561c2-fccf-44f4-8de2-1ed626a21615");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f6df8551-0db6-4260-82b0-fcd793802c6c");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "a472c44f-3447-4fd5-b1a2-3c4f388a89a8", "4a499c85-0d86-42c2-81e6-e3f03dabe1ca" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a472c44f-3447-4fd5-b1a2-3c4f388a89a8");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4a499c85-0d86-42c2-81e6-e3f03dabe1ca");

            migrationBuilder.DropColumn(
                name: "AnilistId",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "AnimeDBId",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "MyAnimeList",
                table: "Characters");

            migrationBuilder.CreateTable(
                name: "AnotherCharacterService",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AnilistId = table.Column<int>(type: "integer", nullable: true),
                    AnimeDBId = table.Column<int>(type: "integer", nullable: true),
                    MyAnimeList = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnotherCharacterService", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnotherCharacterService_Characters_Id",
                        column: x => x.Id,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5203f35d-ca60-4483-bf11-5b940fee5c82", "1", "Guest", "GUEST" },
                    { "838ed798-6f4e-4d5a-b330-9f5ae3584339", "1", "Creator", "CREATOR" },
                    { "c7eda508-5c74-49f1-a483-f2a2d34ec701", "1", "User", "USER" },
                    { "cc6138ac-99ab-4a5a-a141-7810dea21aa6", "1", "Moderator", "MODERATOR" },
                    { "d7f10b8a-992b-454d-8e53-f460e6cd0b7b", "1", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "About", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "0295969a-6c95-495b-9423-1df3adf8d3bd", null, 0, "a4c60a0d-6f85-4019-8b57-760b8a4061c6", "admin@example.local", false, false, null, "ADMIN@EXAMPLE.LOCAL", "ADMIN", "AQAAAAEAACcQAAAAEHcnJe+yZ9BMU/ZP+V42eQaJYhEMQw4gKoLXDQFEHKcwhElL+c2NC7MkZJu2onNIdw==", null, false, "c94e6b34-8115-469e-8d45-74855daa5835", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "d7f10b8a-992b-454d-8e53-f460e6cd0b7b", "0295969a-6c95-495b-9423-1df3adf8d3bd" });
        }
    }
}
