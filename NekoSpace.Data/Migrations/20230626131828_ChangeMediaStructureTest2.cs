using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NekoSpace.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeMediaStructureTest2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "00169072-1b35-4fe1-ab74-222ceeb4b54e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "79b49f12-0f6b-4848-96dc-fd2a902089f8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8997db88-354d-4530-b9ca-9f1be82bd4f8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ab4a48d8-4d2e-4e8b-a6f9-85d7b0294de4");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "372f7529-2778-4c9e-9317-f1f9aa78bc71", "d0832308-b8e5-4df1-8fb0-20c5d36e4279" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "372f7529-2778-4c9e-9317-f1f9aa78bc71");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d0832308-b8e5-4df1-8fb0-20c5d36e4279");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "527532ad-0696-40c4-b4f4-ff1bb256001f", "1", "Guest", "GUEST" },
                    { "54d57874-4fb5-4592-9c7b-04b941465ece", "1", "Creator", "CREATOR" },
                    { "5acaa349-fa64-4d61-bd24-5495629b103a", "1", "User", "USER" },
                    { "661c618c-9119-4bfb-8797-d4ab22867221", "1", "Administrator", "ADMINISTRATOR" },
                    { "bba55f4c-ffc3-4866-a12a-2b09b3b1da78", "1", "Moderator", "MODERATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "About", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1acbd544-1d3e-4225-8ad2-def1c51d4119", null, 0, "86d16432-c89c-49f8-98b4-fb62c53a8857", "admin@example.local", false, false, null, "ADMIN@EXAMPLE.LOCAL", "ADMIN", "AQAAAAEAACcQAAAAEHcnJe+yZ9BMU/ZP+V42eQaJYhEMQw4gKoLXDQFEHKcwhElL+c2NC7MkZJu2onNIdw==", null, false, "5ac2bc0c-fbc3-4aa3-88aa-88198b525f51", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "661c618c-9119-4bfb-8797-d4ab22867221", "1acbd544-1d3e-4225-8ad2-def1c51d4119" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "527532ad-0696-40c4-b4f4-ff1bb256001f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "54d57874-4fb5-4592-9c7b-04b941465ece");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5acaa349-fa64-4d61-bd24-5495629b103a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bba55f4c-ffc3-4866-a12a-2b09b3b1da78");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "661c618c-9119-4bfb-8797-d4ab22867221", "1acbd544-1d3e-4225-8ad2-def1c51d4119" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "661c618c-9119-4bfb-8797-d4ab22867221");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1acbd544-1d3e-4225-8ad2-def1c51d4119");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "00169072-1b35-4fe1-ab74-222ceeb4b54e", "1", "User", "USER" },
                    { "372f7529-2778-4c9e-9317-f1f9aa78bc71", "1", "Administrator", "ADMINISTRATOR" },
                    { "79b49f12-0f6b-4848-96dc-fd2a902089f8", "1", "Creator", "CREATOR" },
                    { "8997db88-354d-4530-b9ca-9f1be82bd4f8", "1", "Moderator", "MODERATOR" },
                    { "ab4a48d8-4d2e-4e8b-a6f9-85d7b0294de4", "1", "Guest", "GUEST" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "About", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "d0832308-b8e5-4df1-8fb0-20c5d36e4279", null, 0, "1df6e7fb-fa13-4e29-b141-a92ac2797393", "admin@example.local", false, false, null, "ADMIN@EXAMPLE.LOCAL", "ADMIN", "AQAAAAEAACcQAAAAEHcnJe+yZ9BMU/ZP+V42eQaJYhEMQw4gKoLXDQFEHKcwhElL+c2NC7MkZJu2onNIdw==", null, false, "440bff40-c973-4a46-acc9-fef8cd93062f", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "372f7529-2778-4c9e-9317-f1f9aa78bc71", "d0832308-b8e5-4df1-8fb0-20c5d36e4279" });
        }
    }
}
