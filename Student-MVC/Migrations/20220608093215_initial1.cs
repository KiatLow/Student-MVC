using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Student_MVC.Migrations
{
    public partial class initial1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Students",
                newName: "StudentName");

            migrationBuilder.RenameColumn(
                name: "Age",
                table: "Students",
                newName: "StudentAge");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StudentName",
                table: "Students",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "StudentAge",
                table: "Students",
                newName: "Age");
        }
    }
}
