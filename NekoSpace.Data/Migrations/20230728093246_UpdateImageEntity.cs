using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NekoSpace.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateImageEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<Guid>(
                name: "CreatorUserId",
                table: "MediaPosters",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsAcceptProposal",
                table: "MediaPosters",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsHidden",
                table: "MediaPosters",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsMain",
                table: "MediaPosters",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsOriginal",
                table: "MediaPosters",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Language",
                table: "MediaPosters",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatorUserId",
                table: "MediaCovers",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsAcceptProposal",
                table: "MediaCovers",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsHidden",
                table: "MediaCovers",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsMain",
                table: "MediaCovers",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsOriginal",
                table: "MediaCovers",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Language",
                table: "MediaCovers",
                type: "integer",
                nullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "MediaPosters");

            migrationBuilder.DropColumn(
                name: "IsAcceptProposal",
                table: "MediaPosters");

            migrationBuilder.DropColumn(
                name: "IsHidden",
                table: "MediaPosters");

            migrationBuilder.DropColumn(
                name: "IsMain",
                table: "MediaPosters");

            migrationBuilder.DropColumn(
                name: "IsOriginal",
                table: "MediaPosters");

            migrationBuilder.DropColumn(
                name: "Language",
                table: "MediaPosters");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "MediaCovers");

            migrationBuilder.DropColumn(
                name: "IsAcceptProposal",
                table: "MediaCovers");

            migrationBuilder.DropColumn(
                name: "IsHidden",
                table: "MediaCovers");

            migrationBuilder.DropColumn(
                name: "IsMain",
                table: "MediaCovers");

            migrationBuilder.DropColumn(
                name: "IsOriginal",
                table: "MediaCovers");

            migrationBuilder.DropColumn(
                name: "Language",
                table: "MediaCovers");

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
    }
}
