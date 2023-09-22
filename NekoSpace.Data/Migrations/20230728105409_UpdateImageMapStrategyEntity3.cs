using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NekoSpace.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateImageMapStrategyEntity3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImageEntity");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "20383517-c26f-49ba-860d-3d1c08ce1fd4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "43203eb8-8ddd-4f98-80b3-19cf5446ea1d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5c965bc6-9480-4afc-a0a2-802eaf9e8cee");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a9cd3e35-6453-4af9-b33e-af78ec972651");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "82a5b66e-63a7-4b70-8dbe-70ab22417027", "8a7052f3-541a-41b4-a622-9b5a48cf3a1e" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "82a5b66e-63a7-4b70-8dbe-70ab22417027");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8a7052f3-541a-41b4-a622-9b5a48cf3a1e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "01be9433-66f4-4bf9-9645-3f7ac228150c", "1", "User", "USER" },
                    { "324bce58-f582-4ec8-bfb6-af6ed133b2f1", "1", "Administrator", "ADMINISTRATOR" },
                    { "7e36c5df-8d22-4d78-9943-ac37ffcb4326", "1", "Moderator", "MODERATOR" },
                    { "82ef1cd3-10a2-4fd9-9b14-dc705ce0e84a", "1", "Creator", "CREATOR" },
                    { "9c173c0f-867e-44da-a83a-055d71a5396a", "1", "Guest", "GUEST" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "About", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "ce1d19d2-ac15-4b2c-b625-fdd1f79d2cc0", null, 0, "c2f033cd-5158-4aa1-aeaa-83a563b86780", "admin@example.local", false, false, null, "ADMIN@EXAMPLE.LOCAL", "ADMIN", "AQAAAAEAACcQAAAAEHcnJe+yZ9BMU/ZP+V42eQaJYhEMQw4gKoLXDQFEHKcwhElL+c2NC7MkZJu2onNIdw==", null, false, "a85edc9c-6b4a-494c-ac0a-ea31c0d1f06d", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "324bce58-f582-4ec8-bfb6-af6ed133b2f1", "ce1d19d2-ac15-4b2c-b625-fdd1f79d2cc0" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01be9433-66f4-4bf9-9645-3f7ac228150c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7e36c5df-8d22-4d78-9943-ac37ffcb4326");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "82ef1cd3-10a2-4fd9-9b14-dc705ce0e84a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9c173c0f-867e-44da-a83a-055d71a5396a");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "324bce58-f582-4ec8-bfb6-af6ed133b2f1", "ce1d19d2-ac15-4b2c-b625-fdd1f79d2cc0" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "324bce58-f582-4ec8-bfb6-af6ed133b2f1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ce1d19d2-ac15-4b2c-b625-fdd1f79d2cc0");

            migrationBuilder.CreateTable(
                name: "ImageEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatorUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    From = table.Column<string>(type: "text", nullable: false),
                    IsAcceptProposal = table.Column<bool>(type: "boolean", nullable: true),
                    IsHidden = table.Column<bool>(type: "boolean", nullable: false),
                    IsMain = table.Column<bool>(type: "boolean", nullable: false),
                    IsOriginal = table.Column<bool>(type: "boolean", nullable: false),
                    Language = table.Column<string>(type: "text", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Large = table.Column<string>(type: "text", nullable: true),
                    Medium = table.Column<string>(type: "text", nullable: true),
                    Original = table.Column<string>(type: "text", nullable: false),
                    Small = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageEntity", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "20383517-c26f-49ba-860d-3d1c08ce1fd4", "1", "Creator", "CREATOR" },
                    { "43203eb8-8ddd-4f98-80b3-19cf5446ea1d", "1", "Guest", "GUEST" },
                    { "5c965bc6-9480-4afc-a0a2-802eaf9e8cee", "1", "User", "USER" },
                    { "82a5b66e-63a7-4b70-8dbe-70ab22417027", "1", "Administrator", "ADMINISTRATOR" },
                    { "a9cd3e35-6453-4af9-b33e-af78ec972651", "1", "Moderator", "MODERATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "About", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "8a7052f3-541a-41b4-a622-9b5a48cf3a1e", null, 0, "f50be5c1-fe3a-4594-a058-08f69c6f98b1", "admin@example.local", false, false, null, "ADMIN@EXAMPLE.LOCAL", "ADMIN", "AQAAAAEAACcQAAAAEHcnJe+yZ9BMU/ZP+V42eQaJYhEMQw4gKoLXDQFEHKcwhElL+c2NC7MkZJu2onNIdw==", null, false, "1fb5c1d7-4685-4791-8eec-7b7fca84c748", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "82a5b66e-63a7-4b70-8dbe-70ab22417027", "8a7052f3-541a-41b4-a622-9b5a48cf3a1e" });
        }
    }
}
