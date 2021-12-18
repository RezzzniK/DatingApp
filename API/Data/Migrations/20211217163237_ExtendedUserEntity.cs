using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Data.Migrations
{
    public partial class ExtendedUserEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "USers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "USers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "USers",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "USers",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "USers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Interests",
                table: "USers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Introduction",
                table: "USers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KnownAS",
                table: "USers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastActive",
                table: "USers",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LookingFor",
                table: "USers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Url = table.Column<string>(type: "TEXT", nullable: true),
                    IsMain = table.Column<bool>(type: "INTEGER", nullable: false),
                    PublicId = table.Column<string>(type: "TEXT", nullable: true),
                    AppUserId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photos_USers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "USers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Photos_AppUserId",
                table: "Photos",
                column: "AppUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.DropColumn(
                name: "City",
                table: "USers");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "USers");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "USers");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "USers");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "USers");

            migrationBuilder.DropColumn(
                name: "Interests",
                table: "USers");

            migrationBuilder.DropColumn(
                name: "Introduction",
                table: "USers");

            migrationBuilder.DropColumn(
                name: "KnownAS",
                table: "USers");

            migrationBuilder.DropColumn(
                name: "LastActive",
                table: "USers");

            migrationBuilder.DropColumn(
                name: "LookingFor",
                table: "USers");
        }
    }
}
