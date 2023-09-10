using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NekoSpace.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateImageRelationForTest6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1f6a690f-44c1-4177-b338-5e5b551fd7e5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2cb752db-1f77-4757-a3d5-e34d4366dd60");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2f867cb5-c794-409a-b120-7cec2549cd70");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f612955a-5a87-4293-85db-c023ef0b6430");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "db147fc5-d399-4fe5-9f52-7f3b9791b5cc", "fac7b659-70ef-4d0b-b942-c1763cba2638" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "db147fc5-d399-4fe5-9f52-7f3b9791b5cc");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fac7b659-70ef-4d0b-b942-c1763cba2638");

            migrationBuilder.DropColumn(
                name: "MediaId1",
                table: "Posters");

            migrationBuilder.DropColumn(
                name: "MediaId1",
                table: "Covers");

            migrationBuilder.CreateTable(
                name: "Medias",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medias", x => x.Id);
                });

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Medias");

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

            migrationBuilder.AddColumn<Guid>(
                name: "MediaId1",
                table: "Posters",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "MediaId1",
                table: "Covers",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1f6a690f-44c1-4177-b338-5e5b551fd7e5", "1", "Creator", "CREATOR" },
                    { "2cb752db-1f77-4757-a3d5-e34d4366dd60", "1", "Moderator", "MODERATOR" },
                    { "2f867cb5-c794-409a-b120-7cec2549cd70", "1", "User", "USER" },
                    { "db147fc5-d399-4fe5-9f52-7f3b9791b5cc", "1", "Administrator", "ADMINISTRATOR" },
                    { "f612955a-5a87-4293-85db-c023ef0b6430", "1", "Guest", "GUEST" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "About", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "fac7b659-70ef-4d0b-b942-c1763cba2638", null, 0, "88d74129-0c8c-4948-9319-24913a35494d", "admin@example.local", false, false, null, "ADMIN@EXAMPLE.LOCAL", "ADMIN", "AQAAAAEAACcQAAAAEHcnJe+yZ9BMU/ZP+V42eQaJYhEMQw4gKoLXDQFEHKcwhElL+c2NC7MkZJu2onNIdw==", null, false, "698f57c9-6fff-44fe-aa91-69cf1596d07d", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "db147fc5-d399-4fe5-9f52-7f3b9791b5cc", "fac7b659-70ef-4d0b-b942-c1763cba2638" });
        }
    }
}
