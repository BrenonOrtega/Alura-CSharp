using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CatalogApp.Database.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReadingLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    Category = table.Column<string>(type: "TEXT", nullable: true),
                    Creator = table.Column<string>(type: "TEXT", nullable: true),
                    CategoriesId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReadingLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReadingLists_ReadingLists_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "ReadingLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", maxLength: 40, nullable: true),
                    Description = table.Column<string>(type: "TEXT", maxLength: 125, nullable: true),
                    LaunchDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Author = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    ListId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_ReadingLists_ListId",
                        column: x => x.ListId,
                        principalTable: "ReadingLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_ListId",
                table: "Books",
                column: "ListId");

            migrationBuilder.CreateIndex(
                name: "IX_ReadingLists_CategoriesId",
                table: "ReadingLists",
                column: "CategoriesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "ReadingLists");
        }
    }
}
