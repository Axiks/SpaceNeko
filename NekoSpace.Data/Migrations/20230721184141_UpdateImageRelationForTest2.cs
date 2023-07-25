using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NekoSpace.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateImageRelationForTest2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "861d72c4-753e-4443-b741-aa32b44da1c7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8db1ac02-7cf3-42d3-9f48-e05fc3620092");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18133eb-592a-4aeb-825f-73454cecd511");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cf49383a-1b44-4b80-8efa-712f9f0008ea");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "50209e41-eb22-452e-a8bf-8c5982cdc809", "987fa849-5906-4980-a248-d85f794518ae" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "50209e41-eb22-452e-a8bf-8c5982cdc809");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "987fa849-5906-4980-a248-d85f794518ae");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4e44deca-4e0b-4153-80bd-4cbf70429b55", "1", "User", "USER" },
                    { "5535e039-44c7-48d4-9e17-6dd307303e00", "1", "Administrator", "ADMINISTRATOR" },
                    { "7047ab19-6c8d-4df3-a396-66d7863a4d6a", "1", "Moderator", "MODERATOR" },
                    { "abd84f32-ccc1-41fe-9c03-c3dc4638663a", "1", "Guest", "GUEST" },
                    { "bfefb40e-430c-4ffc-8b5a-a68154277ffa", "1", "Creator", "CREATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "About", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "9bf61b92-b38f-43a6-8714-9c58cdb89648", null, 0, "965e0475-856d-42fd-809c-161c14f27f4f", "admin@example.local", false, false, null, "ADMIN@EXAMPLE.LOCAL", "ADMIN", "AQAAAAEAACcQAAAAEHcnJe+yZ9BMU/ZP+V42eQaJYhEMQw4gKoLXDQFEHKcwhElL+c2NC7MkZJu2onNIdw==", null, false, "95ee5178-c7d1-4332-8965-e21bab7edfbc", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "5535e039-44c7-48d4-9e17-6dd307303e00", "9bf61b92-b38f-43a6-8714-9c58cdb89648" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4e44deca-4e0b-4153-80bd-4cbf70429b55");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7047ab19-6c8d-4df3-a396-66d7863a4d6a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "abd84f32-ccc1-41fe-9c03-c3dc4638663a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bfefb40e-430c-4ffc-8b5a-a68154277ffa");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "5535e039-44c7-48d4-9e17-6dd307303e00", "9bf61b92-b38f-43a6-8714-9c58cdb89648" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5535e039-44c7-48d4-9e17-6dd307303e00");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9bf61b92-b38f-43a6-8714-9c58cdb89648");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "50209e41-eb22-452e-a8bf-8c5982cdc809", "1", "Administrator", "ADMINISTRATOR" },
                    { "861d72c4-753e-4443-b741-aa32b44da1c7", "1", "Guest", "GUEST" },
                    { "8db1ac02-7cf3-42d3-9f48-e05fc3620092", "1", "User", "USER" },
                    { "a18133eb-592a-4aeb-825f-73454cecd511", "1", "Moderator", "MODERATOR" },
                    { "cf49383a-1b44-4b80-8efa-712f9f0008ea", "1", "Creator", "CREATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "About", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "987fa849-5906-4980-a248-d85f794518ae", null, 0, "0845fc65-5a67-4ac5-ba53-99271be212d3", "admin@example.local", false, false, null, "ADMIN@EXAMPLE.LOCAL", "ADMIN", "AQAAAAEAACcQAAAAEHcnJe+yZ9BMU/ZP+V42eQaJYhEMQw4gKoLXDQFEHKcwhElL+c2NC7MkZJu2onNIdw==", null, false, "b885a392-f95d-4e24-97fa-0b3eef785826", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "50209e41-eb22-452e-a8bf-8c5982cdc809", "987fa849-5906-4980-a248-d85f794518ae" });
        }
    }
}
