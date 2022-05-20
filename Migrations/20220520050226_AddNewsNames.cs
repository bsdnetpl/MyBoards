using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBoards.Migrations
{
    public partial class AddNewsNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
               name: "EnddDate",
               table: "WorkItem",
               newName: "EndDate");

            migrationBuilder.RenameColumn(
               name: "Effort",
               table: "WorkItem",
               newName: "Efford");

            migrationBuilder.RenameColumn(
               name: "Prioryti",
               table: "WorkItem",
               newName: "Priority");


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
               name: "EndDate",
               table: "WorkItem",
               newName: "EnddDate");

            migrationBuilder.RenameColumn(
               name: "Efford",
               table: "WorkItem",
               newName: "Effort");

            migrationBuilder.RenameColumn(
               name: "Priority",
               table: "WorkItem",
               newName: "Prioryti");
        }
    }
}
