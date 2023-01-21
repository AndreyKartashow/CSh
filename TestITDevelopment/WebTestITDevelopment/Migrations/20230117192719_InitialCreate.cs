using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebTestITDevelopment.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TaskDB",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameProject = table.Column<string>(maxLength: 40, nullable: false),
                    Times = table.Column<DateTime>(nullable: false),
                    StartTimes = table.Column<DateTime>(nullable: false),
                    EndTimes = table.Column<DateTime>(nullable: false),
                    NameTask = table.Column<string>(maxLength: 40, nullable: false),
                    Comment = table.Column<string>(maxLength: 200, nullable: false),
                    DataCreate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskDB", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaskDB");
        }
    }
}
