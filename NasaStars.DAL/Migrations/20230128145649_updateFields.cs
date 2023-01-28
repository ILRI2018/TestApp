using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NasaStars.DAL.Migrations
{
    public partial class updateFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Reclong",
                table: "Stars",
                type: "decimal(14,6)",
                precision: 14,
                scale: 6,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Reclat",
                table: "Stars",
                type: "decimal(14,6)",
                precision: 14,
                scale: 6,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Mass",
                table: "Stars",
                type: "decimal(14,6)",
                precision: 14,
                scale: 6,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Reclong",
                table: "Stars",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(14,6)",
                oldPrecision: 14,
                oldScale: 6);

            migrationBuilder.AlterColumn<decimal>(
                name: "Reclat",
                table: "Stars",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(14,6)",
                oldPrecision: 14,
                oldScale: 6);

            migrationBuilder.AlterColumn<decimal>(
                name: "Mass",
                table: "Stars",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(14,6)",
                oldPrecision: 14,
                oldScale: 6);
        }
    }
}
