using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NekoSpace.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateImageRelationForTest18 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MediaPosterEntity_Medias_MediaId",
                table: "MediaPosterEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MediaPosterEntity",
                table: "MediaPosterEntity");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0ec68f94-23d1-44c3-91b4-a64fcebef41a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "20d82e54-bc99-43e4-b02e-c76f8bae6c26");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "39d3ad6b-f228-451e-87d6-9bcf2526d45b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d2b8799-b1c5-4342-8a21-03663529fb42");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c1449d70-e5f4-4695-abc9-75e805f6b8b9", "cef966d8-9395-4902-b9df-521dd283645a" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c1449d70-e5f4-4695-abc9-75e805f6b8b9");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cef966d8-9395-4902-b9df-521dd283645a");

            migrationBuilder.RenameTable(
                name: "MediaPosterEntity",
                newName: "MediaPosters");

            migrationBuilder.RenameIndex(
                name: "IX_MediaPosterEntity_MediaId",
                table: "MediaPosters",
                newName: "IX_MediaPosters_MediaId");

            migrationBuilder.RenameIndex(
                name: "IX_MediaPosterEntity_ImageId",
                table: "MediaPosters",
                newName: "IX_MediaPosters_ImageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MediaPosters",
                table: "MediaPosters",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "MediaCovers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Original = table.Column<string>(type: "text", nullable: false),
                    Large = table.Column<string>(type: "text", nullable: true),
                    Medium = table.Column<string>(type: "text", nullable: true),
                    Small = table.Column<string>(type: "text", nullable: true),
                    From = table.Column<int>(type: "integer", nullable: false),
                    MediaId = table.Column<Guid>(type: "uuid", nullable: false),
                    ImageId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaCovers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MediaCovers_Medias_MediaId",
                        column: x => x.MediaId,
                        principalTable: "Medias",
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
                name: "IX_MediaCovers_ImageId",
                table: "MediaCovers",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaCovers_MediaId",
                table: "MediaCovers",
                column: "MediaId");

            migrationBuilder.AddForeignKey(
                name: "FK_MediaPosters_Medias_MediaId",
                table: "MediaPosters",
                column: "MediaId",
                principalTable: "Medias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MediaPosters_Medias_MediaId",
                table: "MediaPosters");

            migrationBuilder.DropTable(
                name: "MediaCovers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MediaPosters",
                table: "MediaPosters");

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

            migrationBuilder.RenameTable(
                name: "MediaPosters",
                newName: "MediaPosterEntity");

            migrationBuilder.RenameIndex(
                name: "IX_MediaPosters_MediaId",
                table: "MediaPosterEntity",
                newName: "IX_MediaPosterEntity_MediaId");

            migrationBuilder.RenameIndex(
                name: "IX_MediaPosters_ImageId",
                table: "MediaPosterEntity",
                newName: "IX_MediaPosterEntity_ImageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MediaPosterEntity",
                table: "MediaPosterEntity",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0ec68f94-23d1-44c3-91b4-a64fcebef41a", "1", "User", "USER" },
                    { "20d82e54-bc99-43e4-b02e-c76f8bae6c26", "1", "Guest", "GUEST" },
                    { "39d3ad6b-f228-451e-87d6-9bcf2526d45b", "1", "Creator", "CREATOR" },
                    { "3d2b8799-b1c5-4342-8a21-03663529fb42", "1", "Moderator", "MODERATOR" },
                    { "c1449d70-e5f4-4695-abc9-75e805f6b8b9", "1", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "About", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "cef966d8-9395-4902-b9df-521dd283645a", null, 0, "cdca0240-c8be-4c0e-ae25-4022b8655d0b", "admin@example.local", false, false, null, "ADMIN@EXAMPLE.LOCAL", "ADMIN", "AQAAAAEAACcQAAAAEHcnJe+yZ9BMU/ZP+V42eQaJYhEMQw4gKoLXDQFEHKcwhElL+c2NC7MkZJu2onNIdw==", null, false, "941fdd29-9c44-4291-9c92-96e735d387b7", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "c1449d70-e5f4-4695-abc9-75e805f6b8b9", "cef966d8-9395-4902-b9df-521dd283645a" });

            migrationBuilder.AddForeignKey(
                name: "FK_MediaPosterEntity_Medias_MediaId",
                table: "MediaPosterEntity",
                column: "MediaId",
                principalTable: "Medias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
