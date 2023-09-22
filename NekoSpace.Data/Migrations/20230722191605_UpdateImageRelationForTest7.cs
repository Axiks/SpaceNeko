using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NekoSpace.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateImageRelationForTest7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Posters_MediaId",
                table: "Posters");

            migrationBuilder.DropIndex(
                name: "IX_Covers_MediaId",
                table: "Covers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29aa6ae4-0cca-4ef8-9ded-f37ee23ab731");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "58f31c62-9d98-4678-9172-6da8662e8a03");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c5d51098-986e-439a-bc30-1d32ab65a38d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d622578f-d7b0-4bab-87b9-22c7afa6f456");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "12de4dc3-4367-4a15-8385-bacf401a8abd", "6e096425-b4f0-488c-92da-acb8432a1850" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "12de4dc3-4367-4a15-8385-bacf401a8abd");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6e096425-b4f0-488c-92da-acb8432a1850");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3ea0129a-1938-4ad0-9a36-f09d36ed8cc8", "1", "Administrator", "ADMINISTRATOR" },
                    { "44e76cb8-9b20-41b6-9de7-adca87ea42ef", "1", "Moderator", "MODERATOR" },
                    { "a24d75f5-95d2-4c60-8894-d0cd3e63fb9e", "1", "Creator", "CREATOR" },
                    { "a8a32d31-96c1-49a2-b327-076f1495ab17", "1", "User", "USER" },
                    { "dfddea2a-ea78-4e0e-a75b-f33fc6c50c32", "1", "Guest", "GUEST" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "About", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "333b0692-2a36-4151-96a4-11e84412a1d9", null, 0, "7b22f6c8-992b-459a-9122-929fd7533dcd", "admin@example.local", false, false, null, "ADMIN@EXAMPLE.LOCAL", "ADMIN", "AQAAAAEAACcQAAAAEHcnJe+yZ9BMU/ZP+V42eQaJYhEMQw4gKoLXDQFEHKcwhElL+c2NC7MkZJu2onNIdw==", null, false, "dab7a5b7-bf8f-4dcf-82b8-e4f86b45f664", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "3ea0129a-1938-4ad0-9a36-f09d36ed8cc8", "333b0692-2a36-4151-96a4-11e84412a1d9" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44e76cb8-9b20-41b6-9de7-adca87ea42ef");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a24d75f5-95d2-4c60-8894-d0cd3e63fb9e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a8a32d31-96c1-49a2-b327-076f1495ab17");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dfddea2a-ea78-4e0e-a75b-f33fc6c50c32");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3ea0129a-1938-4ad0-9a36-f09d36ed8cc8", "333b0692-2a36-4151-96a4-11e84412a1d9" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3ea0129a-1938-4ad0-9a36-f09d36ed8cc8");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "333b0692-2a36-4151-96a4-11e84412a1d9");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "12de4dc3-4367-4a15-8385-bacf401a8abd", "1", "Administrator", "ADMINISTRATOR" },
                    { "29aa6ae4-0cca-4ef8-9ded-f37ee23ab731", "1", "Moderator", "MODERATOR" },
                    { "58f31c62-9d98-4678-9172-6da8662e8a03", "1", "User", "USER" },
                    { "c5d51098-986e-439a-bc30-1d32ab65a38d", "1", "Creator", "CREATOR" },
                    { "d622578f-d7b0-4bab-87b9-22c7afa6f456", "1", "Guest", "GUEST" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "About", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "6e096425-b4f0-488c-92da-acb8432a1850", null, 0, "d51a0cfd-0831-4d19-a282-82831c4c4f78", "admin@example.local", false, false, null, "ADMIN@EXAMPLE.LOCAL", "ADMIN", "AQAAAAEAACcQAAAAEHcnJe+yZ9BMU/ZP+V42eQaJYhEMQw4gKoLXDQFEHKcwhElL+c2NC7MkZJu2onNIdw==", null, false, "7dbb175a-2be9-45a7-b92f-33bd116293f8", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "12de4dc3-4367-4a15-8385-bacf401a8abd", "6e096425-b4f0-488c-92da-acb8432a1850" });

            migrationBuilder.CreateIndex(
                name: "IX_Posters_MediaId",
                table: "Posters",
                column: "MediaId");

            migrationBuilder.CreateIndex(
                name: "IX_Covers_MediaId",
                table: "Covers",
                column: "MediaId");
        }
    }
}
