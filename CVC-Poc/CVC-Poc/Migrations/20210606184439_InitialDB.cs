using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CVC_Poc.Migrations
{
    public partial class InitialDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    CompanyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    HeadOffice = table.Column<string>(nullable: true),
                    Founder = table.Column<string>(nullable: true),
                    FoundingYear = table.Column<int>(nullable: false),
                    HeadCount = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.CompanyId);
                });

            migrationBuilder.CreateTable(
                name: "DisaplayObjects",
                columns: table => new
                {
                    ObjectId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false),
                    DeveloperId = table.Column<int>(nullable: false),
                    Fields = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisaplayObjects", x => x.ObjectId);
                });

            migrationBuilder.CreateTable(
                name: "DisaplayScreens",
                columns: table => new
                {
                    ScreenId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    DeveloperId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Template = table.Column<int>(nullable: false),
                    ObjectPlacements = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisaplayScreens", x => x.ScreenId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "DisaplayObjects");

            migrationBuilder.DropTable(
                name: "DisaplayScreens");
        }
    }
}
