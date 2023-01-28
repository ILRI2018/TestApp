using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NasaStars.DAL.Migrations
{
    public partial class updateFieldsData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Coordinates",
                table: "Stars",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Stars",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Coordinates",
                table: "Stars");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Stars");
        }
    }
}
