using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NekoSpace.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateImageRelationForTest9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0c840c13-7df9-45ff-9758-3f1be74d1aea");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "353f5cad-bf2e-40de-a78e-996a0c20a50f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "66b50987-3a9f-41ef-92c1-fea1c6c69a9b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b39ff557-2b01-473e-8a9f-dbbc29df1162");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e77345ed-4959-4455-8354-75eb8a44dac4", "0bc7b54e-0c52-494f-883f-39a53432d6ba" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e77345ed-4959-4455-8354-75eb8a44dac4");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0bc7b54e-0c52-494f-883f-39a53432d6ba");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0da733e0-92b1-48d7-bcd9-bb8310a5c1d7", "1", "Creator", "CREATOR" },
                    { "1323b2fb-399c-4891-bd9c-9d405bc21aa9", "1", "User", "USER" },
                    { "27a59072-f518-41db-a670-aae27a7ab146", "1", "Guest", "GUEST" },
                    { "33f44590-659f-4f0d-8ede-1f02e9c7028a", "1", "Administrator", "ADMINISTRATOR" },
                    { "3e312e3c-b6b2-4a57-ae75-2720bf52965f", "1", "Moderator", "MODERATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "About", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b16555b8-4d23-419f-8ed8-833b94c65eb9", null, 0, "7221ed97-762f-4121-a471-4194b735fa52", "admin@example.local", false, false, null, "ADMIN@EXAMPLE.LOCAL", "ADMIN", "AQAAAAEAACcQAAAAEHcnJe+yZ9BMU/ZP+V42eQaJYhEMQw4gKoLXDQFEHKcwhElL+c2NC7MkZJu2onNIdw==", null, false, "554a0ed5-49d9-4e46-9ba1-10e1986b737f", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "33f44590-659f-4f0d-8ede-1f02e9c7028a", "b16555b8-4d23-419f-8ed8-833b94c65eb9" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0da733e0-92b1-48d7-bcd9-bb8310a5c1d7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1323b2fb-399c-4891-bd9c-9d405bc21aa9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "27a59072-f518-41db-a670-aae27a7ab146");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3e312e3c-b6b2-4a57-ae75-2720bf52965f");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "33f44590-659f-4f0d-8ede-1f02e9c7028a", "b16555b8-4d23-419f-8ed8-833b94c65eb9" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "33f44590-659f-4f0d-8ede-1f02e9c7028a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b16555b8-4d23-419f-8ed8-833b94c65eb9");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0c840c13-7df9-45ff-9758-3f1be74d1aea", "1", "Creator", "CREATOR" },
                    { "353f5cad-bf2e-40de-a78e-996a0c20a50f", "1", "Guest", "GUEST" },
                    { "66b50987-3a9f-41ef-92c1-fea1c6c69a9b", "1", "Moderator", "MODERATOR" },
                    { "b39ff557-2b01-473e-8a9f-dbbc29df1162", "1", "User", "USER" },
                    { "e77345ed-4959-4455-8354-75eb8a44dac4", "1", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "About", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "0bc7b54e-0c52-494f-883f-39a53432d6ba", null, 0, "9adb2154-30c7-46dc-86cc-0f59d8aff304", "admin@example.local", false, false, null, "ADMIN@EXAMPLE.LOCAL", "ADMIN", "AQAAAAEAACcQAAAAEHcnJe+yZ9BMU/ZP+V42eQaJYhEMQw4gKoLXDQFEHKcwhElL+c2NC7MkZJu2onNIdw==", null, false, "0aad8d1c-78b0-46a4-9dec-542a506ad7b8", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "e77345ed-4959-4455-8354-75eb8a44dac4", "0bc7b54e-0c52-494f-883f-39a53432d6ba" });
        }
    }
}
