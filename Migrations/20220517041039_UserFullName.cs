﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBoards.Migrations
{
    public partial class UserFullName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<string>(
                 name: "FullName",
                 table: "Users",
                 type: "nvarchar(max)",
                 nullable: true);


            migrationBuilder.Sql(@"
                update Users
                set FullName = FirstName +' '+ LastName");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Users");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                  name: "LastName",
                  table: "Users",
                  type: "nvarchar(max)",
                  nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "User");


        }
    }
}
