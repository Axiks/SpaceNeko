using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NekoSpace.Data.Migrations
{
    /// <inheritdoc />
    public partial class Shangeanimetitlerelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1208396f-e413-490b-a068-09439ee1a6ce");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bb03faa3-7df8-4075-bd90-e8f7f0e5c549");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cd017b6c-478e-4a2e-9599-0a41a7f26d91");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e7a06474-e159-43a7-a972-8137ed520017");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "9c30579f-9f32-477f-a3ce-c474a1f387b6", "bbd2394e-b7dc-4512-a4a8-bc86d0926f2f" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9c30579f-9f32-477f-a3ce-c474a1f387b6");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bbd2394e-b7dc-4512-a4a8-bc86d0926f2f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2fd471fa-d68a-4d2a-8331-4fc914655eb7", "1", "Creator", "CREATOR" },
                    { "39ee3e69-8ce3-46e5-bb71-8e6e6a803ca1", "1", "Administrator", "ADMINISTRATOR" },
                    { "3d65b528-e0ee-4714-933b-970e8ad27f08", "1", "User", "USER" },
                    { "6d6d9047-95c1-4071-a58d-159de72f9e4a", "1", "Moderator", "MODERATOR" },
                    { "e196126e-ed46-4c25-8e64-491c9f6e771a", "1", "Guest", "GUEST" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "About", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "12622371-ba3e-414c-8836-44a975367091", null, 0, "5030bdc7-5bad-4482-89fa-a9abcd30899e", "admin@example.local", false, false, null, "ADMIN@EXAMPLE.LOCAL", "ADMIN", "AQAAAAEAACcQAAAAEHcnJe+yZ9BMU/ZP+V42eQaJYhEMQw4gKoLXDQFEHKcwhElL+c2NC7MkZJu2onNIdw==", null, false, "b3c433b6-4553-46ad-b7c7-07a2f62e59d6", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "39ee3e69-8ce3-46e5-bb71-8e6e6a803ca1", "12622371-ba3e-414c-8836-44a975367091" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2fd471fa-d68a-4d2a-8331-4fc914655eb7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d65b528-e0ee-4714-933b-970e8ad27f08");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6d6d9047-95c1-4071-a58d-159de72f9e4a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e196126e-ed46-4c25-8e64-491c9f6e771a");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "39ee3e69-8ce3-46e5-bb71-8e6e6a803ca1", "12622371-ba3e-414c-8836-44a975367091" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "39ee3e69-8ce3-46e5-bb71-8e6e6a803ca1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "12622371-ba3e-414c-8836-44a975367091");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1208396f-e413-490b-a068-09439ee1a6ce", "1", "User", "USER" },
                    { "9c30579f-9f32-477f-a3ce-c474a1f387b6", "1", "Administrator", "ADMINISTRATOR" },
                    { "bb03faa3-7df8-4075-bd90-e8f7f0e5c549", "1", "Guest", "GUEST" },
                    { "cd017b6c-478e-4a2e-9599-0a41a7f26d91", "1", "Creator", "CREATOR" },
                    { "e7a06474-e159-43a7-a972-8137ed520017", "1", "Moderator", "MODERATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "About", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "bbd2394e-b7dc-4512-a4a8-bc86d0926f2f", null, 0, "21ea1616-3ab7-411b-af39-eeb1680f33e4", "admin@example.local", false, false, null, "ADMIN@EXAMPLE.LOCAL", "ADMIN", "AQAAAAEAACcQAAAAEHcnJe+yZ9BMU/ZP+V42eQaJYhEMQw4gKoLXDQFEHKcwhElL+c2NC7MkZJu2onNIdw==", null, false, "259c7e62-add5-4638-ac19-0746eedd9ccd", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "9c30579f-9f32-477f-a3ce-c474a1f387b6", "bbd2394e-b7dc-4512-a4a8-bc86d0926f2f" });
        }
    }
}
