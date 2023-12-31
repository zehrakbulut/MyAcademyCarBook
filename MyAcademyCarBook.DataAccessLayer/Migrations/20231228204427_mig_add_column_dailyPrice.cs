using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyAcademyCarBook.DataAccessLayer.Migrations
{
    public partial class mig_add_column_dailyPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DailyPrice",
                table: "Cars",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DailyPrice",
                table: "Cars");
        }
    }
}
