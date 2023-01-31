using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NekoSpace.API.Migrations
{
    public partial class ChangedeleteMalIdfields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsOriginal",
                table: "Mangas");

            migrationBuilder.DropColumn(
                name: "MalId",
                table: "Mangas");

            migrationBuilder.DropColumn(
                name: "MalId",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "MalId",
                table: "Animes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsOriginal",
                table: "Mangas",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "MalId",
                table: "Mangas",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "MalId",
                table: "Characters",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "MalId",
                table: "Animes",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
