using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NekoSpace.API.Migrations
{
    public partial class changeCharacterModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7cc7d07b-20b3-4229-b205-244b1876e96b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "919ef74c-63d2-4f0b-8f4c-0bcdb80720cf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e8035066-74b6-41e3-8851-451a3c6ed9e1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f5b11b2b-6b50-4b70-840c-fdfe8ee852d8");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "4b09195f-a423-48ff-8979-82f7469375a9", "4ae9bd33-0bad-44ef-ab09-50cca47ee099" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4b09195f-a423-48ff-8979-82f7469375a9");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4ae9bd33-0bad-44ef-ab09-50cca47ee099");

            migrationBuilder.AlterColumn<DateTime>(
                name: "From",
                table: "Mangas",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddColumn<Guid>(
                name: "AnotherServiceId",
                table: "Characters",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "AnotherCharacterService",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MyAnimeList = table.Column<int>(type: "integer", nullable: true),
                    AnimeDBId = table.Column<int>(type: "integer", nullable: true),
                    AnilistId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnotherCharacterService", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "12104f70-d5d3-4016-aa2f-ae6a502b930d", "1", "User", "USER" },
                    { "4e02ba13-3435-4873-8211-86e830efda4b", "1", "Guest", "GUEST" },
                    { "5b05d670-2b90-4a02-85b9-8a42c79f1cda", "1", "Administrator", "ADMINISTRATOR" },
                    { "773af2ba-52b3-43ba-8e1d-e68fcb3a02fb", "1", "Moderator", "MODERATOR" },
                    { "8ff2cd53-6a82-4ae6-a2d9-d130198fbc60", "1", "Creator", "CREATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "About", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1a6cf93f-8e73-446f-9341-e9252a2b301e", null, 0, "eccab1ac-ca21-4ba0-9851-a7058c6756b6", "admin@example.local", false, false, null, "ADMIN@EXAMPLE.LOCAL", "ADMIN", "AQAAAAEAACcQAAAAEHcnJe+yZ9BMU/ZP+V42eQaJYhEMQw4gKoLXDQFEHKcwhElL+c2NC7MkZJu2onNIdw==", null, false, "ecb6e41e-d92d-44d0-bb58-c61ead11077f", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "5b05d670-2b90-4a02-85b9-8a42c79f1cda", "1a6cf93f-8e73-446f-9341-e9252a2b301e" });

            migrationBuilder.CreateIndex(
                name: "IX_Characters_AnotherServiceId",
                table: "Characters",
                column: "AnotherServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_AnotherCharacterService_AnotherServiceId",
                table: "Characters",
                column: "AnotherServiceId",
                principalTable: "AnotherCharacterService",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_AnotherCharacterService_AnotherServiceId",
                table: "Characters");

            migrationBuilder.DropTable(
                name: "AnotherCharacterService");

            migrationBuilder.DropIndex(
                name: "IX_Characters_AnotherServiceId",
                table: "Characters");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "12104f70-d5d3-4016-aa2f-ae6a502b930d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4e02ba13-3435-4873-8211-86e830efda4b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "773af2ba-52b3-43ba-8e1d-e68fcb3a02fb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8ff2cd53-6a82-4ae6-a2d9-d130198fbc60");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "5b05d670-2b90-4a02-85b9-8a42c79f1cda", "1a6cf93f-8e73-446f-9341-e9252a2b301e" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5b05d670-2b90-4a02-85b9-8a42c79f1cda");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a6cf93f-8e73-446f-9341-e9252a2b301e");

            migrationBuilder.DropColumn(
                name: "AnotherServiceId",
                table: "Characters");

            migrationBuilder.AlterColumn<DateTime>(
                name: "From",
                table: "Mangas",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4b09195f-a423-48ff-8979-82f7469375a9", "1", "Administrator", "ADMINISTRATOR" },
                    { "7cc7d07b-20b3-4229-b205-244b1876e96b", "1", "Guest", "GUEST" },
                    { "919ef74c-63d2-4f0b-8f4c-0bcdb80720cf", "1", "Moderator", "MODERATOR" },
                    { "e8035066-74b6-41e3-8851-451a3c6ed9e1", "1", "User", "USER" },
                    { "f5b11b2b-6b50-4b70-840c-fdfe8ee852d8", "1", "Creator", "CREATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "About", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "4ae9bd33-0bad-44ef-ab09-50cca47ee099", null, 0, "9ee9012d-bf3a-44a6-b8ea-3ba51b54d36d", "admin@example.local", false, false, null, "ADMIN@EXAMPLE.LOCAL", "ADMIN", "AQAAAAEAACcQAAAAEHcnJe+yZ9BMU/ZP+V42eQaJYhEMQw4gKoLXDQFEHKcwhElL+c2NC7MkZJu2onNIdw==", null, false, "eb1abba6-cc65-40ee-b714-59795b4a3221", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "4b09195f-a423-48ff-8979-82f7469375a9", "4ae9bd33-0bad-44ef-ab09-50cca47ee099" });
        }
    }
}
