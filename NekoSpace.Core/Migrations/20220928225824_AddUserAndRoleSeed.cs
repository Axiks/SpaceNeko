using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NekoSpace.API.Migrations
{
    public partial class AddUserAndRoleSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "EpisodesDurationSeconds",
                table: "Animes",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1e651010-017d-41aa-879b-e34b1c162bc2", "1", "User", "User" },
                    { "3f3560f5-7832-4ae5-8aaa-ce842f034163", "1", "Guest", "Guest" },
                    { "70eccf39-dee5-4d9a-a0ae-d79cb500d9d7", "1", "Creator", "Creator" },
                    { "8a8b95ac-eb6f-4f07-bc57-0bd2f863839c", "1", "Moderator", "Moderator" },
                    { "c233bc2b-8667-4172-8d08-7ca08092e289", "1", "Administrator", "Administrator" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "About", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "7df613a5-3027-4d55-8f3c-2b2a2a31fb12", null, 0, "c8257901-f978-4a01-9aa4-4a91661c21fe", "admin@example.local", false, false, null, null, null, null, null, false, "00ea5660-85d0-4296-b155-291b0d5798d1", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "c233bc2b-8667-4172-8d08-7ca08092e289", "7df613a5-3027-4d55-8f3c-2b2a2a31fb12" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1e651010-017d-41aa-879b-e34b1c162bc2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3f3560f5-7832-4ae5-8aaa-ce842f034163");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "70eccf39-dee5-4d9a-a0ae-d79cb500d9d7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8a8b95ac-eb6f-4f07-bc57-0bd2f863839c");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c233bc2b-8667-4172-8d08-7ca08092e289", "7df613a5-3027-4d55-8f3c-2b2a2a31fb12" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c233bc2b-8667-4172-8d08-7ca08092e289");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7df613a5-3027-4d55-8f3c-2b2a2a31fb12");

            migrationBuilder.AlterColumn<int>(
                name: "EpisodesDurationSeconds",
                table: "Animes",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);
        }
    }
}
