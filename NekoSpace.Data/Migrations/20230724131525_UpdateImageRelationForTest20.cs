using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NekoSpace.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateImageRelationForTest20 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5510a192-8611-445a-96f3-835c7841457e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d365ce16-c6b2-4e58-970b-44f4e830f7fd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "de3bcd21-721b-4d56-b35d-76b69a5ed006");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f5948b10-0a08-4a72-a44f-f3adf3089183");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "798ffa3b-7a1a-47c7-8391-1cf15d9085c5", "73c6c996-aecd-4af6-bddf-523fdbac29be" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "798ffa3b-7a1a-47c7-8391-1cf15d9085c5");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "73c6c996-aecd-4af6-bddf-523fdbac29be");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3239aadc-50b4-40dc-9ed8-ae6c5de0afd0", "1", "User", "USER" },
                    { "43c3da27-fcc2-4c7e-8c7d-3234b2e18868", "1", "Administrator", "ADMINISTRATOR" },
                    { "a296f7e8-fcba-441e-b483-83b57cbf4d47", "1", "Guest", "GUEST" },
                    { "ab8a86c8-7c46-48c5-a84e-c75a757de3c8", "1", "Moderator", "MODERATOR" },
                    { "e851b06b-f3c4-4892-8e4b-eff190a3039b", "1", "Creator", "CREATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "About", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "ea6e46e1-fbd4-4485-a28b-025bbc423bd1", null, 0, "5e7d577a-d28b-48bf-a58f-1ede5aee2a58", "admin@example.local", false, false, null, "ADMIN@EXAMPLE.LOCAL", "ADMIN", "AQAAAAEAACcQAAAAEHcnJe+yZ9BMU/ZP+V42eQaJYhEMQw4gKoLXDQFEHKcwhElL+c2NC7MkZJu2onNIdw==", null, false, "9cee3642-1323-4ee0-be5f-219596d890c2", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "43c3da27-fcc2-4c7e-8c7d-3234b2e18868", "ea6e46e1-fbd4-4485-a28b-025bbc423bd1" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3239aadc-50b4-40dc-9ed8-ae6c5de0afd0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a296f7e8-fcba-441e-b483-83b57cbf4d47");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ab8a86c8-7c46-48c5-a84e-c75a757de3c8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e851b06b-f3c4-4892-8e4b-eff190a3039b");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "43c3da27-fcc2-4c7e-8c7d-3234b2e18868", "ea6e46e1-fbd4-4485-a28b-025bbc423bd1" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "43c3da27-fcc2-4c7e-8c7d-3234b2e18868");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ea6e46e1-fbd4-4485-a28b-025bbc423bd1");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5510a192-8611-445a-96f3-835c7841457e", "1", "Guest", "GUEST" },
                    { "798ffa3b-7a1a-47c7-8391-1cf15d9085c5", "1", "Administrator", "ADMINISTRATOR" },
                    { "d365ce16-c6b2-4e58-970b-44f4e830f7fd", "1", "User", "USER" },
                    { "de3bcd21-721b-4d56-b35d-76b69a5ed006", "1", "Creator", "CREATOR" },
                    { "f5948b10-0a08-4a72-a44f-f3adf3089183", "1", "Moderator", "MODERATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "About", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "73c6c996-aecd-4af6-bddf-523fdbac29be", null, 0, "a7338e31-ab43-4a58-b9ac-1c6a5c973a98", "admin@example.local", false, false, null, "ADMIN@EXAMPLE.LOCAL", "ADMIN", "AQAAAAEAACcQAAAAEHcnJe+yZ9BMU/ZP+V42eQaJYhEMQw4gKoLXDQFEHKcwhElL+c2NC7MkZJu2onNIdw==", null, false, "bb14aafd-23b4-4dbf-87fe-40c122ebbf03", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "798ffa3b-7a1a-47c7-8391-1cf15d9085c5", "73c6c996-aecd-4af6-bddf-523fdbac29be" });
        }
    }
}
