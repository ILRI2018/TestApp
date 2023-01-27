using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NasaStars.DAL.Migrations
{
    public partial class addStarsTAble : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nametype = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Recclass = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mass = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fall = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Year = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Reclat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Reclong = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ComputedRegionCbhkFwbd = table.Column<int>(type: "int", nullable: false),
                    ComputedRegionNnqa = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stars", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stars");
        }
    }
}
