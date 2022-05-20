using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBoards.Migrations
{
    public partial class AdditionWorkItemStateSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "WorkItemStates",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "WorkItemStates",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "WorkItemStates",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "WorkItemStates",
                newName: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "WorkItemStates",
                newName: "Id");

            migrationBuilder.InsertData(
                table: "WorkItemStates",
                columns: new[] { "Id", "Value" },
                values: new object[] { 1, "To Do" });

            migrationBuilder.InsertData(
                table: "WorkItemStates",
                columns: new[] { "Id", "Value" },
                values: new object[] { 2, "Doing" });

            migrationBuilder.InsertData(
                table: "WorkItemStates",
                columns: new[] { "Id", "Value" },
                values: new object[] { 3, "Done" });
        }
    }
}
