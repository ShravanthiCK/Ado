using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace codefirstentityframeworkdemo.Migrations
{
    /// <inheritdoc />
    public partial class _3moretablesaddedwithfluentvalidaton : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "authors2",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_authors2", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "userdetails2",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    NewPassword = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    ConfirmPassword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "date", nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    PostalCode = table.Column<int>(type: "int", nullable: false),
                    PhoneNo = table.Column<int>(type: "int", nullable: false),
                    Profile = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userdetails2", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "courses2",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Stitle = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(220)", maxLength: 220, nullable: false),
                    fullprice = table.Column<double>(type: "float", nullable: false),
                    Author2Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_courses2", x => x.Id);
                    table.ForeignKey(
                        name: "FK_courses2_authors2_Author2Id",
                        column: x => x.Author2Id,
                        principalTable: "authors2",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "authors2",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Author One" },
                    { 2, "Author Two" }
                });

            migrationBuilder.InsertData(
                table: "courses2",
                columns: new[] { "Id", "Author2Id", "Description", "Stitle", "fullprice" },
                values: new object[,]
                {
                    { 1, 1, "Description A", "Course A", 100.0 },
                    { 2, 2, "Description B", "Course B", 200.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_courses2_Author2Id",
                table: "courses2",
                column: "Author2Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "courses2");

            migrationBuilder.DropTable(
                name: "userdetails2");

            migrationBuilder.DropTable(
                name: "authors2");
        }
    }
}
