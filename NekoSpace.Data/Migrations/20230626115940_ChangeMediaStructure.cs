using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NekoSpace.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeMediaStructure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6deb1799-2769-450d-815a-7562f0771f85", "1", "Guest", "GUEST" },
                    { "9992e784-36b4-475f-bff0-0a0c9d28bdbe", "1", "Administrator", "ADMINISTRATOR" },
                    { "aafb73a2-34ac-49be-acae-dac700c2b8f2", "1", "User", "USER" },
                    { "cb35a1b1-9f50-4d73-98f7-1126de485846", "1", "Creator", "CREATOR" },
                    { "ff55d958-87c4-49c0-be9b-e6656aaffc4d", "1", "Moderator", "MODERATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "About", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "dfa15516-0832-4e1d-b450-30abbb0fda3b", null, 0, "7236d18c-930b-42a6-8e6e-c814b5748dc8", "admin@example.local", false, false, null, "ADMIN@EXAMPLE.LOCAL", "ADMIN", "AQAAAAEAACcQAAAAEHcnJe+yZ9BMU/ZP+V42eQaJYhEMQw4gKoLXDQFEHKcwhElL+c2NC7MkZJu2onNIdw==", null, false, "c2f6a3b2-afb9-4a7c-9ae8-fba3b1246853", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "9992e784-36b4-475f-bff0-0a0c9d28bdbe", "dfa15516-0832-4e1d-b450-30abbb0fda3b" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6deb1799-2769-450d-815a-7562f0771f85");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aafb73a2-34ac-49be-acae-dac700c2b8f2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cb35a1b1-9f50-4d73-98f7-1126de485846");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ff55d958-87c4-49c0-be9b-e6656aaffc4d");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "9992e784-36b4-475f-bff0-0a0c9d28bdbe", "dfa15516-0832-4e1d-b450-30abbb0fda3b" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9992e784-36b4-475f-bff0-0a0c9d28bdbe");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dfa15516-0832-4e1d-b450-30abbb0fda3b");

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
    }
}
