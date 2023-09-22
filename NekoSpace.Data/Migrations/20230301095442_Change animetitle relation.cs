using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NekoSpace.Data.Migrations
{
    /// <inheritdoc />
    public partial class Changeanimetitlerelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "554e3f7c-f06d-4c0e-9117-c01a478a25f5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5b2b9ac7-f945-46eb-ba04-6dace3f8c2d5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5e0c637c-4beb-47aa-87fe-50c64588dfc2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c5eaf95f-cc5e-4da7-99fe-41bbecae52a6");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "96b15b96-5e87-400b-b164-cd833f714435", "6719a642-d26e-4b89-b999-6d9d7a07c35d" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "96b15b96-5e87-400b-b164-cd833f714435");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6719a642-d26e-4b89-b999-6d9d7a07c35d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1b5451e2-7a74-45e8-ada6-69c964bdedd7", "1", "Guest", "GUEST" },
                    { "51176bb0-f675-430c-b584-f83bbf9556ef", "1", "Creator", "CREATOR" },
                    { "5eb82349-480d-4aee-be13-68347db69248", "1", "User", "USER" },
                    { "a06905ad-c918-4445-87ac-9a9bbbd691db", "1", "Moderator", "MODERATOR" },
                    { "e1943c9b-7456-4b0f-b11b-fc0458648a4e", "1", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "About", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "4b821192-0e8d-44cc-b79d-b9e8caeb06b7", null, 0, "00b1262f-17f4-4ae4-a069-89c05dd036eb", "admin@example.local", false, false, null, "ADMIN@EXAMPLE.LOCAL", "ADMIN", "AQAAAAEAACcQAAAAEHcnJe+yZ9BMU/ZP+V42eQaJYhEMQw4gKoLXDQFEHKcwhElL+c2NC7MkZJu2onNIdw==", null, false, "c0d40022-4423-401a-8aa4-5671cc9d9570", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "e1943c9b-7456-4b0f-b11b-fc0458648a4e", "4b821192-0e8d-44cc-b79d-b9e8caeb06b7" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1b5451e2-7a74-45e8-ada6-69c964bdedd7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "51176bb0-f675-430c-b584-f83bbf9556ef");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5eb82349-480d-4aee-be13-68347db69248");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a06905ad-c918-4445-87ac-9a9bbbd691db");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e1943c9b-7456-4b0f-b11b-fc0458648a4e", "4b821192-0e8d-44cc-b79d-b9e8caeb06b7" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e1943c9b-7456-4b0f-b11b-fc0458648a4e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4b821192-0e8d-44cc-b79d-b9e8caeb06b7");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "554e3f7c-f06d-4c0e-9117-c01a478a25f5", "1", "Moderator", "MODERATOR" },
                    { "5b2b9ac7-f945-46eb-ba04-6dace3f8c2d5", "1", "Guest", "GUEST" },
                    { "5e0c637c-4beb-47aa-87fe-50c64588dfc2", "1", "User", "USER" },
                    { "96b15b96-5e87-400b-b164-cd833f714435", "1", "Administrator", "ADMINISTRATOR" },
                    { "c5eaf95f-cc5e-4da7-99fe-41bbecae52a6", "1", "Creator", "CREATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "About", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "6719a642-d26e-4b89-b999-6d9d7a07c35d", null, 0, "a5ab14d5-a161-471d-8f33-194aa131d85a", "admin@example.local", false, false, null, "ADMIN@EXAMPLE.LOCAL", "ADMIN", "AQAAAAEAACcQAAAAEHcnJe+yZ9BMU/ZP+V42eQaJYhEMQw4gKoLXDQFEHKcwhElL+c2NC7MkZJu2onNIdw==", null, false, "3f5b140f-ac68-48b7-be8e-bd2d26a111f5", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "96b15b96-5e87-400b-b164-cd833f714435", "6719a642-d26e-4b89-b999-6d9d7a07c35d" });
        }
    }
}
