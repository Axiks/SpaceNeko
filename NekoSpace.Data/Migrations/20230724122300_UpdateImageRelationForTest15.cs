using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NekoSpace.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateImageRelationForTest15 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnimeCovers_Images_Id",
                table: "AnimeCovers");

            migrationBuilder.DropForeignKey(
                name: "FK_AnimePosters_Images_Id",
                table: "AnimePosters");

            migrationBuilder.DropForeignKey(
                name: "FK_CharacterCover_Images_CoverId1",
                table: "CharacterCover");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1a794f3f-b3ca-4704-8bc7-05f158fad6da");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "31a39f1a-ce3c-4fcd-872f-cfd7accd283d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8086d7b5-9c7b-4229-b69e-7a4a7082457f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "98c8ca48-98c5-457a-a3f3-c45a2cd92bc9");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "18069ff5-53fb-432a-8ec8-bcbf2890f920", "d1101add-0513-4fa1-b2e8-49d2b2e5fa23" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "18069ff5-53fb-432a-8ec8-bcbf2890f920");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d1101add-0513-4fa1-b2e8-49d2b2e5fa23");

            migrationBuilder.AddColumn<int>(
                name: "From",
                table: "AnimePosters",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Large",
                table: "AnimePosters",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Medium",
                table: "AnimePosters",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Original",
                table: "AnimePosters",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Small",
                table: "AnimePosters",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "From",
                table: "AnimeCovers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Large",
                table: "AnimeCovers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Medium",
                table: "AnimeCovers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Original",
                table: "AnimeCovers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Small",
                table: "AnimeCovers",
                type: "text",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "47bb23fb-152f-4980-9191-2198a0e1e6a2", "1", "User", "USER" },
                    { "6a69ba74-f024-42d0-be01-7ec2ac45d166", "1", "Moderator", "MODERATOR" },
                    { "ca497994-e231-42d2-849e-184af3ba01f5", "1", "Guest", "GUEST" },
                    { "f3a663ff-040a-4b2b-a6ea-f1f4086d7539", "1", "Administrator", "ADMINISTRATOR" },
                    { "fe4a3a30-4a41-48cb-b0c2-0ad9021ed0ff", "1", "Creator", "CREATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "About", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1d029781-e052-4c72-b025-69f9c025decc", null, 0, "bac635ed-28d2-4f94-890c-bf15b94ab761", "admin@example.local", false, false, null, "ADMIN@EXAMPLE.LOCAL", "ADMIN", "AQAAAAEAACcQAAAAEHcnJe+yZ9BMU/ZP+V42eQaJYhEMQw4gKoLXDQFEHKcwhElL+c2NC7MkZJu2onNIdw==", null, false, "960628d0-fbbd-43d6-b6ae-7b9d2f2d9874", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "f3a663ff-040a-4b2b-a6ea-f1f4086d7539", "1d029781-e052-4c72-b025-69f9c025decc" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "47bb23fb-152f-4980-9191-2198a0e1e6a2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6a69ba74-f024-42d0-be01-7ec2ac45d166");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ca497994-e231-42d2-849e-184af3ba01f5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fe4a3a30-4a41-48cb-b0c2-0ad9021ed0ff");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f3a663ff-040a-4b2b-a6ea-f1f4086d7539", "1d029781-e052-4c72-b025-69f9c025decc" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f3a663ff-040a-4b2b-a6ea-f1f4086d7539");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1d029781-e052-4c72-b025-69f9c025decc");

            migrationBuilder.DropColumn(
                name: "From",
                table: "AnimePosters");

            migrationBuilder.DropColumn(
                name: "Large",
                table: "AnimePosters");

            migrationBuilder.DropColumn(
                name: "Medium",
                table: "AnimePosters");

            migrationBuilder.DropColumn(
                name: "Original",
                table: "AnimePosters");

            migrationBuilder.DropColumn(
                name: "Small",
                table: "AnimePosters");

            migrationBuilder.DropColumn(
                name: "From",
                table: "AnimeCovers");

            migrationBuilder.DropColumn(
                name: "Large",
                table: "AnimeCovers");

            migrationBuilder.DropColumn(
                name: "Medium",
                table: "AnimeCovers");

            migrationBuilder.DropColumn(
                name: "Original",
                table: "AnimeCovers");

            migrationBuilder.DropColumn(
                name: "Small",
                table: "AnimeCovers");

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    From = table.Column<int>(type: "integer", nullable: false),
                    Large = table.Column<string>(type: "text", nullable: true),
                    Medium = table.Column<string>(type: "text", nullable: true),
                    Original = table.Column<string>(type: "text", nullable: false),
                    Small = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "18069ff5-53fb-432a-8ec8-bcbf2890f920", "1", "Administrator", "ADMINISTRATOR" },
                    { "1a794f3f-b3ca-4704-8bc7-05f158fad6da", "1", "Guest", "GUEST" },
                    { "31a39f1a-ce3c-4fcd-872f-cfd7accd283d", "1", "User", "USER" },
                    { "8086d7b5-9c7b-4229-b69e-7a4a7082457f", "1", "Moderator", "MODERATOR" },
                    { "98c8ca48-98c5-457a-a3f3-c45a2cd92bc9", "1", "Creator", "CREATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "About", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "d1101add-0513-4fa1-b2e8-49d2b2e5fa23", null, 0, "7162427b-1f6f-43b3-9e69-e2cbf841986c", "admin@example.local", false, false, null, "ADMIN@EXAMPLE.LOCAL", "ADMIN", "AQAAAAEAACcQAAAAEHcnJe+yZ9BMU/ZP+V42eQaJYhEMQw4gKoLXDQFEHKcwhElL+c2NC7MkZJu2onNIdw==", null, false, "32dde766-b3ea-4309-8255-f98c481cfcab", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "18069ff5-53fb-432a-8ec8-bcbf2890f920", "d1101add-0513-4fa1-b2e8-49d2b2e5fa23" });

            migrationBuilder.AddForeignKey(
                name: "FK_AnimeCovers_Images_Id",
                table: "AnimeCovers",
                column: "Id",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AnimePosters_Images_Id",
                table: "AnimePosters",
                column: "Id",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterCover_Images_CoverId1",
                table: "CharacterCover",
                column: "CoverId1",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
