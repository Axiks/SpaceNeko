using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NekoSpace.Data.Migrations
{
    /// <inheritdoc />
    public partial class Changeanimetitlerelation2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "IsHidden",
                table: "MangaTitles");

            migrationBuilder.DropColumn(
                name: "IsHidden",
                table: "MangaSynopsis");

            migrationBuilder.DropColumn(
                name: "IsHidden",
                table: "CharacterTitles");

            migrationBuilder.DropColumn(
                name: "IsHidden",
                table: "CharacterNames");

            migrationBuilder.DropColumn(
                name: "IsHidden",
                table: "AnimeTitle");

            migrationBuilder.DropColumn(
                name: "IsHidden",
                table: "AnimeSynopsis");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "51335e0f-f86e-42e1-9679-47846abb59a1", "1", "Creator", "CREATOR" },
                    { "62be421c-1a9f-4f1d-ae79-94fe243b854e", "1", "Administrator", "ADMINISTRATOR" },
                    { "6dd70576-55ff-4776-8fec-d1643e108658", "1", "Guest", "GUEST" },
                    { "a0c8d30d-9fdc-4c02-b17b-4f409b5146d3", "1", "User", "USER" },
                    { "ba955e3d-50e3-43c4-ad17-0b20b6529532", "1", "Moderator", "MODERATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "About", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "725bb163-376b-4acd-a751-a148b3ae9fd6", null, 0, "9721f760-35b9-4e0d-b244-f241ebf9db0e", "admin@example.local", false, false, null, "ADMIN@EXAMPLE.LOCAL", "ADMIN", "AQAAAAEAACcQAAAAEHcnJe+yZ9BMU/ZP+V42eQaJYhEMQw4gKoLXDQFEHKcwhElL+c2NC7MkZJu2onNIdw==", null, false, "89fd089e-e80a-4f4a-8b5d-4c545f5ceea2", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "62be421c-1a9f-4f1d-ae79-94fe243b854e", "725bb163-376b-4acd-a751-a148b3ae9fd6" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "51335e0f-f86e-42e1-9679-47846abb59a1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6dd70576-55ff-4776-8fec-d1643e108658");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a0c8d30d-9fdc-4c02-b17b-4f409b5146d3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ba955e3d-50e3-43c4-ad17-0b20b6529532");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "62be421c-1a9f-4f1d-ae79-94fe243b854e", "725bb163-376b-4acd-a751-a148b3ae9fd6" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "62be421c-1a9f-4f1d-ae79-94fe243b854e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "725bb163-376b-4acd-a751-a148b3ae9fd6");

            migrationBuilder.AddColumn<bool>(
                name: "IsHidden",
                table: "MangaTitles",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHidden",
                table: "MangaSynopsis",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHidden",
                table: "CharacterTitles",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHidden",
                table: "CharacterNames",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHidden",
                table: "AnimeTitle",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHidden",
                table: "AnimeSynopsis",
                type: "boolean",
                nullable: false,
                defaultValue: false);

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
    }
}
