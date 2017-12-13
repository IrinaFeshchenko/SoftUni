using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Teamwork.Data.Migrations
{
    public partial class studentId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "StudentNumber",
                table: "Students",
                nullable: true,
                oldClrType: typeof(string));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "StudentNumber",
                table: "Students",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
