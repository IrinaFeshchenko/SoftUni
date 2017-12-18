using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Teamwork.Data.Migrations
{
    public partial class CoursesDetailsField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assessments_Students_ForStudentId",
                table: "Assessments");

            migrationBuilder.DropForeignKey(
                name: "FK_Assessments_Students_FromStudentId",
                table: "Assessments");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Courses",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Assessments_Students_ForStudentId",
                table: "Assessments",
                column: "ForStudentId",
                principalTable: "Students",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Assessments_Students_FromStudentId",
                table: "Assessments",
                column: "FromStudentId",
                principalTable: "Students",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assessments_Students_ForStudentId",
                table: "Assessments");

            migrationBuilder.DropForeignKey(
                name: "FK_Assessments_Students_FromStudentId",
                table: "Assessments");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Courses");

            migrationBuilder.AddForeignKey(
                name: "FK_Assessments_Students_ForStudentId",
                table: "Assessments",
                column: "ForStudentId",
                principalTable: "Students",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Assessments_Students_FromStudentId",
                table: "Assessments",
                column: "FromStudentId",
                principalTable: "Students",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
