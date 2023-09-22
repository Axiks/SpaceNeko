using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NekoSpace.Data.Migrations
{
    /// <inheritdoc />
    public partial class Updaterefreshtockenuserid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImageEntity");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1cf2b208-da59-4870-9c1b-5fba7875e426");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "230c910a-1375-4711-aab4-b4680c75b91c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c3795761-3e09-4996-8014-5a9a5b262771");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cfb4865e-14f6-43be-a342-b1168b56cb5e");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "6884685c-4bbb-4638-841f-55cc669f9a8f", "85ff06e3-6b77-4bc9-b3a7-b87c62a060f7" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6884685c-4bbb-4638-841f-55cc669f9a8f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "85ff06e3-6b77-4bc9-b3a7-b87c62a060f7");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0962d682-0a0d-4432-b71e-ac0adfe5feae", "1", "User", "USER" },
                    { "7d1ae767-42ae-44d3-9e28-a8050def76cf", "1", "Administrator", "ADMINISTRATOR" },
                    { "80718012-e7d6-45d2-b360-7329ff0dc7e1", "1", "Moderator", "MODERATOR" },
                    { "938847f2-a8d3-4647-86a3-833ea26f73d1", "1", "Guest", "GUEST" },
                    { "eb287bbe-c944-4442-b20b-3e237d24e889", "1", "Creator", "CREATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "About", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "d7661412-d0cf-4736-ad0d-d1cf5224d527", null, 0, "8ed341eb-9f7f-40a3-b98f-f5d3ecea2981", "admin@example.local", false, false, null, "ADMIN@EXAMPLE.LOCAL", "ADMIN", "AQAAAAEAACcQAAAAEHcnJe+yZ9BMU/ZP+V42eQaJYhEMQw4gKoLXDQFEHKcwhElL+c2NC7MkZJu2onNIdw==", null, false, "241e2268-0064-4d79-acb1-49c1dcab8b8a", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "7d1ae767-42ae-44d3-9e28-a8050def76cf", "d7661412-d0cf-4736-ad0d-d1cf5224d527" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0962d682-0a0d-4432-b71e-ac0adfe5feae");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "80718012-e7d6-45d2-b360-7329ff0dc7e1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "938847f2-a8d3-4647-86a3-833ea26f73d1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eb287bbe-c944-4442-b20b-3e237d24e889");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "7d1ae767-42ae-44d3-9e28-a8050def76cf", "d7661412-d0cf-4736-ad0d-d1cf5224d527" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7d1ae767-42ae-44d3-9e28-a8050def76cf");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d7661412-d0cf-4736-ad0d-d1cf5224d527");

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
                    Language = table.Column<string>(type: "text", nullable: true),
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
                    { "1cf2b208-da59-4870-9c1b-5fba7875e426", "1", "Guest", "GUEST" },
                    { "230c910a-1375-4711-aab4-b4680c75b91c", "1", "Moderator", "MODERATOR" },
                    { "6884685c-4bbb-4638-841f-55cc669f9a8f", "1", "Administrator", "ADMINISTRATOR" },
                    { "c3795761-3e09-4996-8014-5a9a5b262771", "1", "User", "USER" },
                    { "cfb4865e-14f6-43be-a342-b1168b56cb5e", "1", "Creator", "CREATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "About", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "85ff06e3-6b77-4bc9-b3a7-b87c62a060f7", null, 0, "df8cd461-55e1-4b20-92e7-60ef8560c8c6", "admin@example.local", false, false, null, "ADMIN@EXAMPLE.LOCAL", "ADMIN", "AQAAAAEAACcQAAAAEHcnJe+yZ9BMU/ZP+V42eQaJYhEMQw4gKoLXDQFEHKcwhElL+c2NC7MkZJu2onNIdw==", null, false, "6c5119ed-f12c-4684-b3fe-c04a1af12a58", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "6884685c-4bbb-4638-841f-55cc669f9a8f", "85ff06e3-6b77-4bc9-b3a7-b87c62a060f7" });
        }
    }
}
