using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NekoSpace.Data.Migrations
{
    /// <inheritdoc />
    public partial class Changeanimetitlerelation8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "36a1bb76-663f-4c43-9da1-901a7ddb6ea7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "80a625b9-c377-4812-b751-faaa1bbb1890");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "93ce44b5-58c0-4316-a946-a9bb2d72719e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "abd9afc8-d346-4276-83d3-3d1371efc9cc");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "df4123a7-2b24-4a7a-9a54-2b4ff9bea466", "9c530d32-8b6c-4192-b495-b86533b0dc64" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "df4123a7-2b24-4a7a-9a54-2b4ff9bea466");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9c530d32-8b6c-4192-b495-b86533b0dc64");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "36a1bb76-663f-4c43-9da1-901a7ddb6ea7", "1", "Moderator", "MODERATOR" },
                    { "80a625b9-c377-4812-b751-faaa1bbb1890", "1", "Guest", "GUEST" },
                    { "93ce44b5-58c0-4316-a946-a9bb2d72719e", "1", "User", "USER" },
                    { "abd9afc8-d346-4276-83d3-3d1371efc9cc", "1", "Creator", "CREATOR" },
                    { "df4123a7-2b24-4a7a-9a54-2b4ff9bea466", "1", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "About", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "9c530d32-8b6c-4192-b495-b86533b0dc64", null, 0, "b09ab2e9-4131-4b2f-b35a-055042d496c3", "admin@example.local", false, false, null, "ADMIN@EXAMPLE.LOCAL", "ADMIN", "AQAAAAEAACcQAAAAEHcnJe+yZ9BMU/ZP+V42eQaJYhEMQw4gKoLXDQFEHKcwhElL+c2NC7MkZJu2onNIdw==", null, false, "f67052b4-454e-48da-bf17-05975424c40f", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "df4123a7-2b24-4a7a-9a54-2b4ff9bea466", "9c530d32-8b6c-4192-b495-b86533b0dc64" });
        }
    }
}
