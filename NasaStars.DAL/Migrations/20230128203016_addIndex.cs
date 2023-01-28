using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NasaStars.DAL.Migrations
{
    public partial class addIndex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Recclass",
                table: "Stars",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Stars_Year_Recclass",
                table: "Stars",
                columns: new[] { "Year", "Recclass" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Stars_Year_Recclass",
                table: "Stars");

            migrationBuilder.AlterColumn<string>(
                name: "Recclass",
                table: "Stars",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }
    }
}
