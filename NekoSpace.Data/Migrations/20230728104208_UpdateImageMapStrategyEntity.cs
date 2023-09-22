using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NekoSpace.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateImageMapStrategyEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4c4dd99f-de2a-4738-8a99-bebf76de61f0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "584775b2-3674-476a-9a13-76a192005f6c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b6af634e-b121-44ed-97f4-0c96c49b88f1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d60fc03d-4f8f-4306-815d-2615d6009526");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "bdc74be2-08b4-447b-a33c-71ca0808e302", "751c0da6-3c51-49d4-b633-0d72e0e7ee40" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bdc74be2-08b4-447b-a33c-71ca0808e302");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "751c0da6-3c51-49d4-b633-0d72e0e7ee40");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "055202c4-6068-4f01-a2b5-afa133477d86", "1", "Creator", "CREATOR" },
                    { "3e835c3c-6e73-4ff4-ac1e-bcc179c22e92", "1", "Administrator", "ADMINISTRATOR" },
                    { "543054f2-c8c5-450f-85cd-bad116bf1605", "1", "Guest", "GUEST" },
                    { "5edfc6b7-0d1d-4007-861a-1a51e1385991", "1", "User", "USER" },
                    { "d38c37c0-e3fd-40cf-b35d-344f7d58cf3d", "1", "Moderator", "MODERATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "About", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "76cd7d93-7e48-48cb-b1ea-7be0767f136f", null, 0, "5f6fefe1-5d8e-48ca-bdc5-e2ff3bc7c9ff", "admin@example.local", false, false, null, "ADMIN@EXAMPLE.LOCAL", "ADMIN", "AQAAAAEAACcQAAAAEHcnJe+yZ9BMU/ZP+V42eQaJYhEMQw4gKoLXDQFEHKcwhElL+c2NC7MkZJu2onNIdw==", null, false, "58c099a9-a79b-4d2a-b111-2c4490ec081b", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "3e835c3c-6e73-4ff4-ac1e-bcc179c22e92", "76cd7d93-7e48-48cb-b1ea-7be0767f136f" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "055202c4-6068-4f01-a2b5-afa133477d86");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "543054f2-c8c5-450f-85cd-bad116bf1605");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5edfc6b7-0d1d-4007-861a-1a51e1385991");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d38c37c0-e3fd-40cf-b35d-344f7d58cf3d");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3e835c3c-6e73-4ff4-ac1e-bcc179c22e92", "76cd7d93-7e48-48cb-b1ea-7be0767f136f" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3e835c3c-6e73-4ff4-ac1e-bcc179c22e92");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "76cd7d93-7e48-48cb-b1ea-7be0767f136f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4c4dd99f-de2a-4738-8a99-bebf76de61f0", "1", "Moderator", "MODERATOR" },
                    { "584775b2-3674-476a-9a13-76a192005f6c", "1", "User", "USER" },
                    { "b6af634e-b121-44ed-97f4-0c96c49b88f1", "1", "Guest", "GUEST" },
                    { "bdc74be2-08b4-447b-a33c-71ca0808e302", "1", "Administrator", "ADMINISTRATOR" },
                    { "d60fc03d-4f8f-4306-815d-2615d6009526", "1", "Creator", "CREATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "About", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "751c0da6-3c51-49d4-b633-0d72e0e7ee40", null, 0, "3b0b3936-494d-4f05-8aad-b08606a44aba", "admin@example.local", false, false, null, "ADMIN@EXAMPLE.LOCAL", "ADMIN", "AQAAAAEAACcQAAAAEHcnJe+yZ9BMU/ZP+V42eQaJYhEMQw4gKoLXDQFEHKcwhElL+c2NC7MkZJu2onNIdw==", null, false, "473e4212-8a4a-4573-888c-ffec25a00a64", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "bdc74be2-08b4-447b-a33c-71ca0808e302", "751c0da6-3c51-49d4-b633-0d72e0e7ee40" });
        }
    }
}
