using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NekoSpace.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateImageRelationForTest10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharacterCover_ImageEntity_CoverImageId",
                table: "CharacterCover");

            migrationBuilder.DropForeignKey(
                name: "FK_CharacterPoster_ImageEntity_PosterImageId",
                table: "CharacterPoster");

            migrationBuilder.DropForeignKey(
                name: "FK_Covers_ImageEntity_ImageId",
                table: "Covers");

            migrationBuilder.DropForeignKey(
                name: "FK_Posters_ImageEntity_ImageId",
                table: "Posters");

            migrationBuilder.DropTable(
                name: "ImageEntity");

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

            migrationBuilder.AddColumn<int>(
                name: "From",
                table: "Posters",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Large",
                table: "Posters",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "MediaId",
                table: "Posters",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Medium",
                table: "Posters",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Original",
                table: "Posters",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Small",
                table: "Posters",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "From",
                table: "Covers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Large",
                table: "Covers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "MediaId",
                table: "Covers",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Medium",
                table: "Covers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Original",
                table: "Covers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Small",
                table: "Covers",
                type: "text",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "477940d8-243c-4837-85cb-e07ce664dd4c", "1", "Moderator", "MODERATOR" },
                    { "56110733-9eb0-4887-a563-aabd35b559a9", "1", "Creator", "CREATOR" },
                    { "73060836-93d7-4b55-bbf5-422e2e77fcf4", "1", "User", "USER" },
                    { "83b2f3f2-036f-46a4-bacc-6565ba950df6", "1", "Guest", "GUEST" },
                    { "844e429f-32e2-4bc3-b66c-c38a0863b691", "1", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "About", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "6fe542c1-af58-40aa-a343-a274e89884f3", null, 0, "40aebee0-7f31-4333-b369-46699ab2d865", "admin@example.local", false, false, null, "ADMIN@EXAMPLE.LOCAL", "ADMIN", "AQAAAAEAACcQAAAAEHcnJe+yZ9BMU/ZP+V42eQaJYhEMQw4gKoLXDQFEHKcwhElL+c2NC7MkZJu2onNIdw==", null, false, "2b2fff9d-dd59-40df-b109-617c729a4ea7", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "844e429f-32e2-4bc3-b66c-c38a0863b691", "6fe542c1-af58-40aa-a343-a274e89884f3" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "477940d8-243c-4837-85cb-e07ce664dd4c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "56110733-9eb0-4887-a563-aabd35b559a9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "73060836-93d7-4b55-bbf5-422e2e77fcf4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "83b2f3f2-036f-46a4-bacc-6565ba950df6");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "844e429f-32e2-4bc3-b66c-c38a0863b691", "6fe542c1-af58-40aa-a343-a274e89884f3" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "844e429f-32e2-4bc3-b66c-c38a0863b691");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6fe542c1-af58-40aa-a343-a274e89884f3");

            migrationBuilder.DropColumn(
                name: "From",
                table: "Posters");

            migrationBuilder.DropColumn(
                name: "Large",
                table: "Posters");

            migrationBuilder.DropColumn(
                name: "MediaId",
                table: "Posters");

            migrationBuilder.DropColumn(
                name: "Medium",
                table: "Posters");

            migrationBuilder.DropColumn(
                name: "Original",
                table: "Posters");

            migrationBuilder.DropColumn(
                name: "Small",
                table: "Posters");

            migrationBuilder.DropColumn(
                name: "From",
                table: "Covers");

            migrationBuilder.DropColumn(
                name: "Large",
                table: "Covers");

            migrationBuilder.DropColumn(
                name: "MediaId",
                table: "Covers");

            migrationBuilder.DropColumn(
                name: "Medium",
                table: "Covers");

            migrationBuilder.DropColumn(
                name: "Original",
                table: "Covers");

            migrationBuilder.DropColumn(
                name: "Small",
                table: "Covers");

            migrationBuilder.CreateTable(
                name: "ImageEntity",
                columns: table => new
                {
                    ImageId = table.Column<Guid>(type: "uuid", nullable: false),
                    From = table.Column<int>(type: "integer", nullable: false),
                    Large = table.Column<string>(type: "text", nullable: true),
                    MediaId = table.Column<Guid>(type: "uuid", nullable: false),
                    Medium = table.Column<string>(type: "text", nullable: true),
                    Original = table.Column<string>(type: "text", nullable: false),
                    Small = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageEntity", x => x.ImageId);
                });

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

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterCover_ImageEntity_CoverImageId",
                table: "CharacterCover",
                column: "CoverImageId",
                principalTable: "ImageEntity",
                principalColumn: "ImageId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterPoster_ImageEntity_PosterImageId",
                table: "CharacterPoster",
                column: "PosterImageId",
                principalTable: "ImageEntity",
                principalColumn: "ImageId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Covers_ImageEntity_ImageId",
                table: "Covers",
                column: "ImageId",
                principalTable: "ImageEntity",
                principalColumn: "ImageId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Posters_ImageEntity_ImageId",
                table: "Posters",
                column: "ImageId",
                principalTable: "ImageEntity",
                principalColumn: "ImageId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
