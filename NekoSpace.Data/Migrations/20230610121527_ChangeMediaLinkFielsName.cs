using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NekoSpace.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeMediaLinkFielsName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "1cd1cf70-b2ec-45d4-8d82-c0cdbee02870", "1", "Moderator", "MODERATOR" },
                    { "24a123e2-13dd-4eca-96ae-0c175033a2bf", "1", "Creator", "CREATOR" },
                    { "7d60af7e-879a-44d1-83da-d8596784b8af", "1", "Administrator", "ADMINISTRATOR" },
                    { "bf30fd64-2028-42e6-a393-cc2372af5638", "1", "User", "USER" },
                    { "e1331d9b-54a8-42bb-81d2-1276783869c9", "1", "Guest", "GUEST" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "About", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "f74e3711-8aed-49c0-acff-1bcb683b7afa", null, 0, "c1a3177e-9647-4c2e-8cff-4571b4421784", "admin@example.local", false, false, null, "ADMIN@EXAMPLE.LOCAL", "ADMIN", "AQAAAAEAACcQAAAAEHcnJe+yZ9BMU/ZP+V42eQaJYhEMQw4gKoLXDQFEHKcwhElL+c2NC7MkZJu2onNIdw==", null, false, "f472ea48-70b4-4ad6-9154-380b3e99eb12", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "7d60af7e-879a-44d1-83da-d8596784b8af", "f74e3711-8aed-49c0-acff-1bcb683b7afa" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1cd1cf70-b2ec-45d4-8d82-c0cdbee02870");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "24a123e2-13dd-4eca-96ae-0c175033a2bf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bf30fd64-2028-42e6-a393-cc2372af5638");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e1331d9b-54a8-42bb-81d2-1276783869c9");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "7d60af7e-879a-44d1-83da-d8596784b8af", "f74e3711-8aed-49c0-acff-1bcb683b7afa" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7d60af7e-879a-44d1-83da-d8596784b8af");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f74e3711-8aed-49c0-acff-1bcb683b7afa");

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
    }
}
