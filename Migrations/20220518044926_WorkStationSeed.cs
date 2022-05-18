using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBoards.Migrations
{
    public partial class WorkStationSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "workItemStates",
                newName: "Id");

            migrationBuilder.InsertData(
                table: "workItemStates",
                columns: new[] { "Id", "Value" },
                values: new object[] { 1, "To Do" });

            migrationBuilder.InsertData(
                table: "workItemStates",
                columns: new[] { "Id", "Value" },
                values: new object[] { 2, "Doing" });

            migrationBuilder.InsertData(
                table: "workItemStates",
                columns: new[] { "Id", "Value" },
                values: new object[] { 3, "Done" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "workItemStates",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "workItemStates",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "workItemStates",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "workItemStates",
                newName: "id");
        }
    }
}
