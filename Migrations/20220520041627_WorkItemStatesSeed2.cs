using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBoards.Migrations
{
    public partial class WorkItemStatesSeed2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkItems_workItemStates_StateId",
                table: "WorkItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_workItemStates",
                table: "workItemStates");

            migrationBuilder.RenameTable(
                name: "workItemStates",
                newName: "WorkItemStates");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "WorkItemStates",
                newName: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkItemStates",
                table: "WorkItemStates",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkItems_WorkItemStates_StateId",
                table: "WorkItems",
                column: "StateId",
                principalTable: "WorkItemStates",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkItems_WorkItemStates_StateId",
                table: "WorkItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkItemStates",
                table: "WorkItemStates");

            migrationBuilder.RenameTable(
                name: "WorkItemStates",
                newName: "workItemStates");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "workItemStates",
                newName: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_workItemStates",
                table: "workItemStates",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkItems_workItemStates_StateId",
                table: "WorkItems",
                column: "StateId",
                principalTable: "workItemStates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
