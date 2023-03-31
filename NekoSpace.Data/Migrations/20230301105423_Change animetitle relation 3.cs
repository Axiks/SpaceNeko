using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NekoSpace.Data.Migrations
{
    /// <inheritdoc />
    public partial class Changeanimetitlerelation3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnimeTitle_Animes_AnimeId",
                table: "AnimeTitle");

            migrationBuilder.DropIndex(
                name: "IX_AnimeTitle_AnimeId",
                table: "AnimeTitle");

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
                    { "267eb2ce-8783-4538-a076-373f69fdc718", "1", "Creator", "CREATOR" },
                    { "89e8cbc2-5620-4d5c-88e2-f198c4fc7b9d", "1", "Moderator", "MODERATOR" },
                    { "b0e1039b-64a6-458a-827e-73f96c87c7c4", "1", "Guest", "GUEST" },
                    { "c48f83fc-055a-4a5f-8ea9-58399d6553f0", "1", "User", "USER" },
                    { "cb987bdf-85bb-4bfc-89aa-bec9da3d83d5", "1", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "About", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "80420176-0e43-4dc7-ab60-7b09ccf8e66e", null, 0, "e44fb9b0-7c28-437a-9586-cfd664a7d5cb", "admin@example.local", false, false, null, "ADMIN@EXAMPLE.LOCAL", "ADMIN", "AQAAAAEAACcQAAAAEHcnJe+yZ9BMU/ZP+V42eQaJYhEMQw4gKoLXDQFEHKcwhElL+c2NC7MkZJu2onNIdw==", null, false, "e38bd1bb-5293-4b93-9c8f-59257fe8677e", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "cb987bdf-85bb-4bfc-89aa-bec9da3d83d5", "80420176-0e43-4dc7-ab60-7b09ccf8e66e" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "267eb2ce-8783-4538-a076-373f69fdc718");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "89e8cbc2-5620-4d5c-88e2-f198c4fc7b9d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b0e1039b-64a6-458a-827e-73f96c87c7c4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c48f83fc-055a-4a5f-8ea9-58399d6553f0");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "cb987bdf-85bb-4bfc-89aa-bec9da3d83d5", "80420176-0e43-4dc7-ab60-7b09ccf8e66e" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cb987bdf-85bb-4bfc-89aa-bec9da3d83d5");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80420176-0e43-4dc7-ab60-7b09ccf8e66e");

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

            migrationBuilder.CreateIndex(
                name: "IX_AnimeTitle_AnimeId",
                table: "AnimeTitle",
                column: "AnimeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AnimeTitle_Animes_AnimeId",
                table: "AnimeTitle",
                column: "AnimeId",
                principalTable: "Animes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
