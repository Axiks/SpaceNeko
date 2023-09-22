using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NekoSpace.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateImageRelationForTest19 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnimeCovers");

            migrationBuilder.DropTable(
                name: "AnimePosters");

            migrationBuilder.DropTable(
                name: "CharacterCover");

            migrationBuilder.DropIndex(
                name: "IX_MediaPosters_ImageId",
                table: "MediaPosters");

            migrationBuilder.DropIndex(
                name: "IX_MediaCovers_ImageId",
                table: "MediaCovers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad8c8a0f-4905-42ac-95a0-9e486a6a9545");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c1d0f310-2806-43f7-9324-8f53f3692483");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d2826481-3999-409c-a09b-c8b72c4923bf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d2f945a9-71c1-4ce3-b2fc-6a296a10de61");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1dc636a3-1ed6-4555-8fba-79e7d23793f0", "25bbc59b-bd52-413e-bd61-233b83e2c7be" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1dc636a3-1ed6-4555-8fba-79e7d23793f0");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "25bbc59b-bd52-413e-bd61-233b83e2c7be");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "MediaPosters");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "MediaCovers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5510a192-8611-445a-96f3-835c7841457e", "1", "Guest", "GUEST" },
                    { "798ffa3b-7a1a-47c7-8391-1cf15d9085c5", "1", "Administrator", "ADMINISTRATOR" },
                    { "d365ce16-c6b2-4e58-970b-44f4e830f7fd", "1", "User", "USER" },
                    { "de3bcd21-721b-4d56-b35d-76b69a5ed006", "1", "Creator", "CREATOR" },
                    { "f5948b10-0a08-4a72-a44f-f3adf3089183", "1", "Moderator", "MODERATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "About", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "73c6c996-aecd-4af6-bddf-523fdbac29be", null, 0, "a7338e31-ab43-4a58-b9ac-1c6a5c973a98", "admin@example.local", false, false, null, "ADMIN@EXAMPLE.LOCAL", "ADMIN", "AQAAAAEAACcQAAAAEHcnJe+yZ9BMU/ZP+V42eQaJYhEMQw4gKoLXDQFEHKcwhElL+c2NC7MkZJu2onNIdw==", null, false, "bb14aafd-23b4-4dbf-87fe-40c122ebbf03", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "798ffa3b-7a1a-47c7-8391-1cf15d9085c5", "73c6c996-aecd-4af6-bddf-523fdbac29be" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5510a192-8611-445a-96f3-835c7841457e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d365ce16-c6b2-4e58-970b-44f4e830f7fd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "de3bcd21-721b-4d56-b35d-76b69a5ed006");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f5948b10-0a08-4a72-a44f-f3adf3089183");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "798ffa3b-7a1a-47c7-8391-1cf15d9085c5", "73c6c996-aecd-4af6-bddf-523fdbac29be" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "798ffa3b-7a1a-47c7-8391-1cf15d9085c5");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "73c6c996-aecd-4af6-bddf-523fdbac29be");

            migrationBuilder.AddColumn<Guid>(
                name: "ImageId",
                table: "MediaPosters",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ImageId",
                table: "MediaCovers",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "AnimeCovers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    From = table.Column<int>(type: "integer", nullable: false),
                    Large = table.Column<string>(type: "text", nullable: true),
                    Medium = table.Column<string>(type: "text", nullable: true),
                    Original = table.Column<string>(type: "text", nullable: false),
                    Small = table.Column<string>(type: "text", nullable: true),
                    AnimeId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimeCovers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnimeCovers_Animes_AnimeId",
                        column: x => x.AnimeId,
                        principalTable: "Animes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnimePosters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    From = table.Column<int>(type: "integer", nullable: false),
                    Large = table.Column<string>(type: "text", nullable: true),
                    Medium = table.Column<string>(type: "text", nullable: true),
                    Original = table.Column<string>(type: "text", nullable: false),
                    Small = table.Column<string>(type: "text", nullable: true),
                    AnimeId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimePosters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnimePosters_Animes_AnimeId",
                        column: x => x.AnimeId,
                        principalTable: "Animes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharacterCover",
                columns: table => new
                {
                    CoverId = table.Column<int>(type: "integer", nullable: false),
                    CharacterId = table.Column<Guid>(type: "uuid", nullable: false),
                    CoverId1 = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterCover", x => new { x.CoverId, x.CharacterId });
                    table.ForeignKey(
                        name: "FK_CharacterCover_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1dc636a3-1ed6-4555-8fba-79e7d23793f0", "1", "Administrator", "ADMINISTRATOR" },
                    { "ad8c8a0f-4905-42ac-95a0-9e486a6a9545", "1", "Guest", "GUEST" },
                    { "c1d0f310-2806-43f7-9324-8f53f3692483", "1", "Creator", "CREATOR" },
                    { "d2826481-3999-409c-a09b-c8b72c4923bf", "1", "User", "USER" },
                    { "d2f945a9-71c1-4ce3-b2fc-6a296a10de61", "1", "Moderator", "MODERATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "About", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "25bbc59b-bd52-413e-bd61-233b83e2c7be", null, 0, "83cac04f-676e-4209-833b-2b8d7486ba34", "admin@example.local", false, false, null, "ADMIN@EXAMPLE.LOCAL", "ADMIN", "AQAAAAEAACcQAAAAEHcnJe+yZ9BMU/ZP+V42eQaJYhEMQw4gKoLXDQFEHKcwhElL+c2NC7MkZJu2onNIdw==", null, false, "8895dbe9-534b-4421-a90a-6a48850493d5", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1dc636a3-1ed6-4555-8fba-79e7d23793f0", "25bbc59b-bd52-413e-bd61-233b83e2c7be" });

            migrationBuilder.CreateIndex(
                name: "IX_MediaPosters_ImageId",
                table: "MediaPosters",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaCovers_ImageId",
                table: "MediaCovers",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_AnimeCovers_AnimeId",
                table: "AnimeCovers",
                column: "AnimeId");

            migrationBuilder.CreateIndex(
                name: "IX_AnimePosters_AnimeId",
                table: "AnimePosters",
                column: "AnimeId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterCover_CharacterId",
                table: "CharacterCover",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterCover_CoverId1",
                table: "CharacterCover",
                column: "CoverId1");
        }
    }
}
