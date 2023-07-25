using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NekoSpace.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateImageRelationForTest14 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharacterCover_ImageEntity_CoverId1",
                table: "CharacterCover");

            migrationBuilder.DropForeignKey(
                name: "FK_Cover_Media_Animes_AnimeId",
                table: "Cover_Media");

            migrationBuilder.DropForeignKey(
                name: "FK_Cover_Media_Covers_Id",
                table: "Cover_Media");

            migrationBuilder.DropForeignKey(
                name: "FK_Poster_Media_Animes_AnimeId",
                table: "Poster_Media");

            migrationBuilder.DropForeignKey(
                name: "FK_Poster_Media_Posters_Id",
                table: "Poster_Media");

            migrationBuilder.DropTable(
                name: "Covers");

            migrationBuilder.DropTable(
                name: "Posters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Poster_Media",
                table: "Poster_Media");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ImageEntity",
                table: "ImageEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cover_Media",
                table: "Cover_Media");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3ff43889-ef56-4e11-ab68-5320a769022c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a49fa0f6-7b16-48ee-8ee8-1b48b4a82ba2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b9d3aeea-ab1d-4dd1-a4ca-65971f793352");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d54241d9-3330-438a-9d9e-06a74e87cc01");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0a2d7862-edf8-4026-bc0f-6eff1c756c33", "2a9ec42f-23be-4bbd-b7e2-b47e7c25c950" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0a2d7862-edf8-4026-bc0f-6eff1c756c33");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2a9ec42f-23be-4bbd-b7e2-b47e7c25c950");

            migrationBuilder.RenameTable(
                name: "Poster_Media",
                newName: "AnimePosters");

            migrationBuilder.RenameTable(
                name: "ImageEntity",
                newName: "Images");

            migrationBuilder.RenameTable(
                name: "Cover_Media",
                newName: "AnimeCovers");

            migrationBuilder.RenameIndex(
                name: "IX_Poster_Media_AnimeId",
                table: "AnimePosters",
                newName: "IX_AnimePosters_AnimeId");

            migrationBuilder.RenameIndex(
                name: "IX_Cover_Media_AnimeId",
                table: "AnimeCovers",
                newName: "IX_AnimeCovers_AnimeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AnimePosters",
                table: "AnimePosters",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Images",
                table: "Images",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AnimeCovers",
                table: "AnimeCovers",
                column: "Id");

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
                name: "FK_AnimeCovers_Animes_AnimeId",
                table: "AnimeCovers",
                column: "AnimeId",
                principalTable: "Animes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AnimeCovers_Images_Id",
                table: "AnimeCovers",
                column: "Id",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AnimePosters_Animes_AnimeId",
                table: "AnimePosters",
                column: "AnimeId",
                principalTable: "Animes",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnimeCovers_Animes_AnimeId",
                table: "AnimeCovers");

            migrationBuilder.DropForeignKey(
                name: "FK_AnimeCovers_Images_Id",
                table: "AnimeCovers");

            migrationBuilder.DropForeignKey(
                name: "FK_AnimePosters_Animes_AnimeId",
                table: "AnimePosters");

            migrationBuilder.DropForeignKey(
                name: "FK_AnimePosters_Images_Id",
                table: "AnimePosters");

            migrationBuilder.DropForeignKey(
                name: "FK_CharacterCover_Images_CoverId1",
                table: "CharacterCover");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Images",
                table: "Images");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AnimePosters",
                table: "AnimePosters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AnimeCovers",
                table: "AnimeCovers");

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

            migrationBuilder.RenameTable(
                name: "Images",
                newName: "ImageEntity");

            migrationBuilder.RenameTable(
                name: "AnimePosters",
                newName: "Poster_Media");

            migrationBuilder.RenameTable(
                name: "AnimeCovers",
                newName: "Cover_Media");

            migrationBuilder.RenameIndex(
                name: "IX_AnimePosters_AnimeId",
                table: "Poster_Media",
                newName: "IX_Poster_Media_AnimeId");

            migrationBuilder.RenameIndex(
                name: "IX_AnimeCovers_AnimeId",
                table: "Cover_Media",
                newName: "IX_Cover_Media_AnimeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ImageEntity",
                table: "ImageEntity",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Poster_Media",
                table: "Poster_Media",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cover_Media",
                table: "Cover_Media",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Covers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Covers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Covers_ImageEntity_Id",
                        column: x => x.Id,
                        principalTable: "ImageEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Posters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posters_ImageEntity_Id",
                        column: x => x.Id,
                        principalTable: "ImageEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0a2d7862-edf8-4026-bc0f-6eff1c756c33", "1", "Administrator", "ADMINISTRATOR" },
                    { "3ff43889-ef56-4e11-ab68-5320a769022c", "1", "Guest", "GUEST" },
                    { "a49fa0f6-7b16-48ee-8ee8-1b48b4a82ba2", "1", "User", "USER" },
                    { "b9d3aeea-ab1d-4dd1-a4ca-65971f793352", "1", "Creator", "CREATOR" },
                    { "d54241d9-3330-438a-9d9e-06a74e87cc01", "1", "Moderator", "MODERATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "About", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "2a9ec42f-23be-4bbd-b7e2-b47e7c25c950", null, 0, "4c61b3a5-bd02-4486-bc36-de7128b9cf69", "admin@example.local", false, false, null, "ADMIN@EXAMPLE.LOCAL", "ADMIN", "AQAAAAEAACcQAAAAEHcnJe+yZ9BMU/ZP+V42eQaJYhEMQw4gKoLXDQFEHKcwhElL+c2NC7MkZJu2onNIdw==", null, false, "59e47f2f-fbd5-42e1-bfdf-df8a34283dcd", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "0a2d7862-edf8-4026-bc0f-6eff1c756c33", "2a9ec42f-23be-4bbd-b7e2-b47e7c25c950" });

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterCover_ImageEntity_CoverId1",
                table: "CharacterCover",
                column: "CoverId1",
                principalTable: "ImageEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cover_Media_Animes_AnimeId",
                table: "Cover_Media",
                column: "AnimeId",
                principalTable: "Animes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cover_Media_Covers_Id",
                table: "Cover_Media",
                column: "Id",
                principalTable: "Covers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Poster_Media_Animes_AnimeId",
                table: "Poster_Media",
                column: "AnimeId",
                principalTable: "Animes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Poster_Media_Posters_Id",
                table: "Poster_Media",
                column: "Id",
                principalTable: "Posters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
