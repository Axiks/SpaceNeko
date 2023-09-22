using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NekoSpace.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeMediaLinkStructure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a75f0d2e-78c3-4703-8fe6-ebe4eca1933f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ba25d1ac-e407-4161-82e9-55688f0d1f05");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d733dd50-2723-4075-89c6-eebecc321d71");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f63d1d5e-40a9-42fc-91c8-35256caa9f02");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d88ed450-242b-43fc-a998-ce2fd4fa65b9", "191a922d-4398-4eda-86ad-36e86eb2b1b5" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d88ed450-242b-43fc-a998-ce2fd4fa65b9");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "191a922d-4398-4eda-86ad-36e86eb2b1b5");

            migrationBuilder.AlterColumn<string>(
                name: "ServiceName",
                table: "AssociatedServiceEntity",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "ServiceId",
                table: "AssociatedServiceEntity",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4e80ccc1-95b0-4dda-9071-735429ea2864", "1", "Guest", "GUEST" },
                    { "5d37972c-19ac-4679-9ee2-b06fd67e9e70", "1", "Creator", "CREATOR" },
                    { "8faa6f32-cfe0-4d7c-b3da-86f37bd0906e", "1", "Administrator", "ADMINISTRATOR" },
                    { "d8804684-87d1-4779-8c52-aed79b0d5e35", "1", "Moderator", "MODERATOR" },
                    { "db5fd9d5-ac7c-4ab3-a3cd-67af5dc19769", "1", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "About", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "7ac7a381-6a2a-43b4-9b7b-25e81bf9d6f4", null, 0, "fe47ed24-cd6f-402f-a161-70489aa4aae6", "admin@example.local", false, false, null, "ADMIN@EXAMPLE.LOCAL", "ADMIN", "AQAAAAEAACcQAAAAEHcnJe+yZ9BMU/ZP+V42eQaJYhEMQw4gKoLXDQFEHKcwhElL+c2NC7MkZJu2onNIdw==", null, false, "38899248-85e8-4f71-8aba-56636a58fa8a", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "8faa6f32-cfe0-4d7c-b3da-86f37bd0906e", "7ac7a381-6a2a-43b4-9b7b-25e81bf9d6f4" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4e80ccc1-95b0-4dda-9071-735429ea2864");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5d37972c-19ac-4679-9ee2-b06fd67e9e70");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d8804684-87d1-4779-8c52-aed79b0d5e35");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "db5fd9d5-ac7c-4ab3-a3cd-67af5dc19769");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "8faa6f32-cfe0-4d7c-b3da-86f37bd0906e", "7ac7a381-6a2a-43b4-9b7b-25e81bf9d6f4" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8faa6f32-cfe0-4d7c-b3da-86f37bd0906e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7ac7a381-6a2a-43b4-9b7b-25e81bf9d6f4");

            migrationBuilder.AlterColumn<int>(
                name: "ServiceName",
                table: "AssociatedServiceEntity",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "ServiceId",
                table: "AssociatedServiceEntity",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a75f0d2e-78c3-4703-8fe6-ebe4eca1933f", "1", "User", "USER" },
                    { "ba25d1ac-e407-4161-82e9-55688f0d1f05", "1", "Creator", "CREATOR" },
                    { "d733dd50-2723-4075-89c6-eebecc321d71", "1", "Moderator", "MODERATOR" },
                    { "d88ed450-242b-43fc-a998-ce2fd4fa65b9", "1", "Administrator", "ADMINISTRATOR" },
                    { "f63d1d5e-40a9-42fc-91c8-35256caa9f02", "1", "Guest", "GUEST" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "About", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "191a922d-4398-4eda-86ad-36e86eb2b1b5", null, 0, "fb07c15c-094d-4d84-adbd-065bfe9ca249", "admin@example.local", false, false, null, "ADMIN@EXAMPLE.LOCAL", "ADMIN", "AQAAAAEAACcQAAAAEHcnJe+yZ9BMU/ZP+V42eQaJYhEMQw4gKoLXDQFEHKcwhElL+c2NC7MkZJu2onNIdw==", null, false, "93937e2b-4097-42be-9ea2-bbf80a05ddf4", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "d88ed450-242b-43fc-a998-ce2fd4fa65b9", "191a922d-4398-4eda-86ad-36e86eb2b1b5" });
        }
    }
}
