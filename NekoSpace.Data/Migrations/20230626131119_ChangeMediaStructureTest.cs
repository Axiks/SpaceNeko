using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NekoSpace.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeMediaStructureTest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssociatedServiceEntity_Animes_MediaEntityId",
                table: "AssociatedServiceEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_AssociatedServiceEntity_Characters_MediaEntityId",
                table: "AssociatedServiceEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_AssociatedServiceEntity_Mangas_MediaEntityId",
                table: "AssociatedServiceEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AssociatedServiceEntity",
                table: "AssociatedServiceEntity");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6deb1799-2769-450d-815a-7562f0771f85");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aafb73a2-34ac-49be-acae-dac700c2b8f2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cb35a1b1-9f50-4d73-98f7-1126de485846");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ff55d958-87c4-49c0-be9b-e6656aaffc4d");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "9992e784-36b4-475f-bff0-0a0c9d28bdbe", "dfa15516-0832-4e1d-b450-30abbb0fda3b" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9992e784-36b4-475f-bff0-0a0c9d28bdbe");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dfa15516-0832-4e1d-b450-30abbb0fda3b");

            migrationBuilder.RenameTable(
                name: "AssociatedServiceEntity",
                newName: "AssociatedService");

            migrationBuilder.RenameIndex(
                name: "IX_AssociatedServiceEntity_MediaEntityId",
                table: "AssociatedService",
                newName: "IX_AssociatedService_MediaEntityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AssociatedService",
                table: "AssociatedService",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "00169072-1b35-4fe1-ab74-222ceeb4b54e", "1", "User", "USER" },
                    { "372f7529-2778-4c9e-9317-f1f9aa78bc71", "1", "Administrator", "ADMINISTRATOR" },
                    { "79b49f12-0f6b-4848-96dc-fd2a902089f8", "1", "Creator", "CREATOR" },
                    { "8997db88-354d-4530-b9ca-9f1be82bd4f8", "1", "Moderator", "MODERATOR" },
                    { "ab4a48d8-4d2e-4e8b-a6f9-85d7b0294de4", "1", "Guest", "GUEST" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "About", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "d0832308-b8e5-4df1-8fb0-20c5d36e4279", null, 0, "1df6e7fb-fa13-4e29-b141-a92ac2797393", "admin@example.local", false, false, null, "ADMIN@EXAMPLE.LOCAL", "ADMIN", "AQAAAAEAACcQAAAAEHcnJe+yZ9BMU/ZP+V42eQaJYhEMQw4gKoLXDQFEHKcwhElL+c2NC7MkZJu2onNIdw==", null, false, "440bff40-c973-4a46-acc9-fef8cd93062f", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "372f7529-2778-4c9e-9317-f1f9aa78bc71", "d0832308-b8e5-4df1-8fb0-20c5d36e4279" });

            migrationBuilder.AddForeignKey(
                name: "FK_AssociatedService_Animes_MediaEntityId",
                table: "AssociatedService",
                column: "MediaEntityId",
                principalTable: "Animes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AssociatedService_Characters_MediaEntityId",
                table: "AssociatedService",
                column: "MediaEntityId",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AssociatedService_Mangas_MediaEntityId",
                table: "AssociatedService",
                column: "MediaEntityId",
                principalTable: "Mangas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssociatedService_Animes_MediaEntityId",
                table: "AssociatedService");

            migrationBuilder.DropForeignKey(
                name: "FK_AssociatedService_Characters_MediaEntityId",
                table: "AssociatedService");

            migrationBuilder.DropForeignKey(
                name: "FK_AssociatedService_Mangas_MediaEntityId",
                table: "AssociatedService");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AssociatedService",
                table: "AssociatedService");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "00169072-1b35-4fe1-ab74-222ceeb4b54e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "79b49f12-0f6b-4848-96dc-fd2a902089f8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8997db88-354d-4530-b9ca-9f1be82bd4f8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ab4a48d8-4d2e-4e8b-a6f9-85d7b0294de4");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "372f7529-2778-4c9e-9317-f1f9aa78bc71", "d0832308-b8e5-4df1-8fb0-20c5d36e4279" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "372f7529-2778-4c9e-9317-f1f9aa78bc71");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d0832308-b8e5-4df1-8fb0-20c5d36e4279");

            migrationBuilder.RenameTable(
                name: "AssociatedService",
                newName: "AssociatedServiceEntity");

            migrationBuilder.RenameIndex(
                name: "IX_AssociatedService_MediaEntityId",
                table: "AssociatedServiceEntity",
                newName: "IX_AssociatedServiceEntity_MediaEntityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AssociatedServiceEntity",
                table: "AssociatedServiceEntity",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6deb1799-2769-450d-815a-7562f0771f85", "1", "Guest", "GUEST" },
                    { "9992e784-36b4-475f-bff0-0a0c9d28bdbe", "1", "Administrator", "ADMINISTRATOR" },
                    { "aafb73a2-34ac-49be-acae-dac700c2b8f2", "1", "User", "USER" },
                    { "cb35a1b1-9f50-4d73-98f7-1126de485846", "1", "Creator", "CREATOR" },
                    { "ff55d958-87c4-49c0-be9b-e6656aaffc4d", "1", "Moderator", "MODERATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "About", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "dfa15516-0832-4e1d-b450-30abbb0fda3b", null, 0, "7236d18c-930b-42a6-8e6e-c814b5748dc8", "admin@example.local", false, false, null, "ADMIN@EXAMPLE.LOCAL", "ADMIN", "AQAAAAEAACcQAAAAEHcnJe+yZ9BMU/ZP+V42eQaJYhEMQw4gKoLXDQFEHKcwhElL+c2NC7MkZJu2onNIdw==", null, false, "c2f6a3b2-afb9-4a7c-9ae8-fba3b1246853", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "9992e784-36b4-475f-bff0-0a0c9d28bdbe", "dfa15516-0832-4e1d-b450-30abbb0fda3b" });

            migrationBuilder.AddForeignKey(
                name: "FK_AssociatedServiceEntity_Animes_MediaEntityId",
                table: "AssociatedServiceEntity",
                column: "MediaEntityId",
                principalTable: "Animes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AssociatedServiceEntity_Characters_MediaEntityId",
                table: "AssociatedServiceEntity",
                column: "MediaEntityId",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AssociatedServiceEntity_Mangas_MediaEntityId",
                table: "AssociatedServiceEntity",
                column: "MediaEntityId",
                principalTable: "Mangas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
