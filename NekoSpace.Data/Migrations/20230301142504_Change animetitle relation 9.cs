using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NekoSpace.Data.Migrations
{
    /// <inheritdoc />
    public partial class Changeanimetitlerelation9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2f0cf075-3bd3-40dd-8961-5dd1d23edeb5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5485bbe7-8c3f-4625-9166-98b084715582");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9db729fd-c6bc-4ea5-87ef-d16578683aef");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f3610b3f-3934-4059-83de-496820bdb60c");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c47ce84d-4ff1-495f-b4b7-4deaaba7de7e", "8a489318-d126-404d-880e-b9aceae39453" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c47ce84d-4ff1-495f-b4b7-4deaaba7de7e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8a489318-d126-404d-880e-b9aceae39453");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "40c94fc4-7907-4b01-a1da-d59f8a1007f5", "1", "Creator", "CREATOR" },
                    { "57c6f76c-2dba-44ad-85a1-ad285245887d", "1", "Moderator", "MODERATOR" },
                    { "66618be5-6635-4053-83ee-880bb4828c96", "1", "Administrator", "ADMINISTRATOR" },
                    { "6b2bb961-eb95-435a-bd3f-0922c3ddabe1", "1", "User", "USER" },
                    { "9c43e451-b598-4131-a69c-0dbadfd6c0cf", "1", "Guest", "GUEST" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "About", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "ccb5562e-62f7-4470-b781-ef788733119e", null, 0, "febe3e04-8d0c-428a-9351-594a29ab2a2e", "admin@example.local", false, false, null, "ADMIN@EXAMPLE.LOCAL", "ADMIN", "AQAAAAEAACcQAAAAEHcnJe+yZ9BMU/ZP+V42eQaJYhEMQw4gKoLXDQFEHKcwhElL+c2NC7MkZJu2onNIdw==", null, false, "7890ce60-acd2-42f7-8302-24461ae50589", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "66618be5-6635-4053-83ee-880bb4828c96", "ccb5562e-62f7-4470-b781-ef788733119e" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "40c94fc4-7907-4b01-a1da-d59f8a1007f5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "57c6f76c-2dba-44ad-85a1-ad285245887d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6b2bb961-eb95-435a-bd3f-0922c3ddabe1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9c43e451-b598-4131-a69c-0dbadfd6c0cf");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "66618be5-6635-4053-83ee-880bb4828c96", "ccb5562e-62f7-4470-b781-ef788733119e" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "66618be5-6635-4053-83ee-880bb4828c96");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ccb5562e-62f7-4470-b781-ef788733119e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2f0cf075-3bd3-40dd-8961-5dd1d23edeb5", "1", "Moderator", "MODERATOR" },
                    { "5485bbe7-8c3f-4625-9166-98b084715582", "1", "Creator", "CREATOR" },
                    { "9db729fd-c6bc-4ea5-87ef-d16578683aef", "1", "Guest", "GUEST" },
                    { "c47ce84d-4ff1-495f-b4b7-4deaaba7de7e", "1", "Administrator", "ADMINISTRATOR" },
                    { "f3610b3f-3934-4059-83de-496820bdb60c", "1", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "About", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "8a489318-d126-404d-880e-b9aceae39453", null, 0, "c2402218-4528-486c-b717-f9f18ef88b45", "admin@example.local", false, false, null, "ADMIN@EXAMPLE.LOCAL", "ADMIN", "AQAAAAEAACcQAAAAEHcnJe+yZ9BMU/ZP+V42eQaJYhEMQw4gKoLXDQFEHKcwhElL+c2NC7MkZJu2onNIdw==", null, false, "799d90df-8d85-422e-94ca-1432b9690e53", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "c47ce84d-4ff1-495f-b4b7-4deaaba7de7e", "8a489318-d126-404d-880e-b9aceae39453" });
        }
    }
}
