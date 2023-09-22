using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NekoSpace.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateImageRelationForTest5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7dc99fdf-2b45-4a31-88d5-16f5447197f7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "de7b4456-213a-41b0-8bd0-e241521027a4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ed9b284c-9077-4e8d-8778-82ebe5e855ce");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f2eb358d-694a-4b22-a25f-e9ce92071ba1");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b871117d-fd9c-447b-a086-3d17ee2cec30", "543f1111-f16b-4664-beda-31f18cccd55f" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b871117d-fd9c-447b-a086-3d17ee2cec30");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "543f1111-f16b-4664-beda-31f18cccd55f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1f6a690f-44c1-4177-b338-5e5b551fd7e5", "1", "Creator", "CREATOR" },
                    { "2cb752db-1f77-4757-a3d5-e34d4366dd60", "1", "Moderator", "MODERATOR" },
                    { "2f867cb5-c794-409a-b120-7cec2549cd70", "1", "User", "USER" },
                    { "db147fc5-d399-4fe5-9f52-7f3b9791b5cc", "1", "Administrator", "ADMINISTRATOR" },
                    { "f612955a-5a87-4293-85db-c023ef0b6430", "1", "Guest", "GUEST" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "About", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "fac7b659-70ef-4d0b-b942-c1763cba2638", null, 0, "88d74129-0c8c-4948-9319-24913a35494d", "admin@example.local", false, false, null, "ADMIN@EXAMPLE.LOCAL", "ADMIN", "AQAAAAEAACcQAAAAEHcnJe+yZ9BMU/ZP+V42eQaJYhEMQw4gKoLXDQFEHKcwhElL+c2NC7MkZJu2onNIdw==", null, false, "698f57c9-6fff-44fe-aa91-69cf1596d07d", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "db147fc5-d399-4fe5-9f52-7f3b9791b5cc", "fac7b659-70ef-4d0b-b942-c1763cba2638" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1f6a690f-44c1-4177-b338-5e5b551fd7e5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2cb752db-1f77-4757-a3d5-e34d4366dd60");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2f867cb5-c794-409a-b120-7cec2549cd70");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f612955a-5a87-4293-85db-c023ef0b6430");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "db147fc5-d399-4fe5-9f52-7f3b9791b5cc", "fac7b659-70ef-4d0b-b942-c1763cba2638" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "db147fc5-d399-4fe5-9f52-7f3b9791b5cc");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fac7b659-70ef-4d0b-b942-c1763cba2638");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7dc99fdf-2b45-4a31-88d5-16f5447197f7", "1", "Guest", "GUEST" },
                    { "b871117d-fd9c-447b-a086-3d17ee2cec30", "1", "Administrator", "ADMINISTRATOR" },
                    { "de7b4456-213a-41b0-8bd0-e241521027a4", "1", "User", "USER" },
                    { "ed9b284c-9077-4e8d-8778-82ebe5e855ce", "1", "Moderator", "MODERATOR" },
                    { "f2eb358d-694a-4b22-a25f-e9ce92071ba1", "1", "Creator", "CREATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "About", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "543f1111-f16b-4664-beda-31f18cccd55f", null, 0, "25926e80-6e43-49ff-9bd5-50917a2aa524", "admin@example.local", false, false, null, "ADMIN@EXAMPLE.LOCAL", "ADMIN", "AQAAAAEAACcQAAAAEHcnJe+yZ9BMU/ZP+V42eQaJYhEMQw4gKoLXDQFEHKcwhElL+c2NC7MkZJu2onNIdw==", null, false, "326e2667-f01f-4734-81d6-cb1b1235a3af", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "b871117d-fd9c-447b-a086-3d17ee2cec30", "543f1111-f16b-4664-beda-31f18cccd55f" });
        }
    }
}
