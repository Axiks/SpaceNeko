using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NekoSpace.API.Migrations
{
    public partial class addAnotherServiceRelationCharacter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_AnotherCharacterService_AnotherServiceId",
                table: "Characters");

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

            migrationBuilder.AddForeignKey(
                name: "FK_AnotherCharacterService_Characters_Id",
                table: "AnotherCharacterService",
                column: "Id",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnotherCharacterService_Characters_Id",
                table: "AnotherCharacterService");

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

            migrationBuilder.AddColumn<Guid>(
                name: "AnotherServiceId",
                table: "Characters",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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
    }
}
