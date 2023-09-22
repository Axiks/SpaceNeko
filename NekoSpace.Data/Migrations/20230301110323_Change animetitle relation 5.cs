using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NekoSpace.Data.Migrations
{
    /// <inheritdoc />
    public partial class Changeanimetitlerelation5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0096bade-b080-4baf-905d-c2e2b24596fa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a59c52cc-9cbc-45c9-a13b-573894c5fbf0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c232d302-3578-43e5-8638-44ed266eaf11");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c47fb939-c5ab-4043-b58c-e53c0e689912");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "37894077-ac89-4f9f-9966-6d1072db18a7", "28423c0c-e4d2-4e6e-a36b-9f8e6400948c" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "37894077-ac89-4f9f-9966-6d1072db18a7");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "28423c0c-e4d2-4e6e-a36b-9f8e6400948c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7deeae8b-01d9-45c8-80eb-885f93559895", "1", "Guest", "GUEST" },
                    { "c22a01e9-392a-4f05-b1a8-b9c7003ebd1c", "1", "Administrator", "ADMINISTRATOR" },
                    { "cb0f73f9-683d-46ee-82bf-e3baf32ba108", "1", "Moderator", "MODERATOR" },
                    { "cdb992b4-6861-44b6-a2a2-c7ca6a31f4fc", "1", "Creator", "CREATOR" },
                    { "f139609b-2598-43e9-bc2c-bfe1cade0a53", "1", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "About", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "3036207b-14ce-430f-a70f-d6ab9dfe5a22", null, 0, "394cbad4-fd32-490e-8a35-c5333f2f6da7", "admin@example.local", false, false, null, "ADMIN@EXAMPLE.LOCAL", "ADMIN", "AQAAAAEAACcQAAAAEHcnJe+yZ9BMU/ZP+V42eQaJYhEMQw4gKoLXDQFEHKcwhElL+c2NC7MkZJu2onNIdw==", null, false, "9dbc0ce6-fc67-4bce-bd4a-2af056ef3371", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "c22a01e9-392a-4f05-b1a8-b9c7003ebd1c", "3036207b-14ce-430f-a70f-d6ab9dfe5a22" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7deeae8b-01d9-45c8-80eb-885f93559895");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cb0f73f9-683d-46ee-82bf-e3baf32ba108");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cdb992b4-6861-44b6-a2a2-c7ca6a31f4fc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f139609b-2598-43e9-bc2c-bfe1cade0a53");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c22a01e9-392a-4f05-b1a8-b9c7003ebd1c", "3036207b-14ce-430f-a70f-d6ab9dfe5a22" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c22a01e9-392a-4f05-b1a8-b9c7003ebd1c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3036207b-14ce-430f-a70f-d6ab9dfe5a22");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0096bade-b080-4baf-905d-c2e2b24596fa", "1", "User", "USER" },
                    { "37894077-ac89-4f9f-9966-6d1072db18a7", "1", "Administrator", "ADMINISTRATOR" },
                    { "a59c52cc-9cbc-45c9-a13b-573894c5fbf0", "1", "Guest", "GUEST" },
                    { "c232d302-3578-43e5-8638-44ed266eaf11", "1", "Moderator", "MODERATOR" },
                    { "c47fb939-c5ab-4043-b58c-e53c0e689912", "1", "Creator", "CREATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "About", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "28423c0c-e4d2-4e6e-a36b-9f8e6400948c", null, 0, "e4e1a6b2-720f-4359-bba9-d8d93441c772", "admin@example.local", false, false, null, "ADMIN@EXAMPLE.LOCAL", "ADMIN", "AQAAAAEAACcQAAAAEHcnJe+yZ9BMU/ZP+V42eQaJYhEMQw4gKoLXDQFEHKcwhElL+c2NC7MkZJu2onNIdw==", null, false, "7f3fed08-f6e7-4d44-b6a4-68c36e3d372e", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "37894077-ac89-4f9f-9966-6d1072db18a7", "28423c0c-e4d2-4e6e-a36b-9f8e6400948c" });
        }
    }
}
