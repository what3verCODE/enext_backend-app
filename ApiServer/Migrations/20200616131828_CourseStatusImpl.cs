﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiServer.Migrations
{
    public partial class CourseStatusImpl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Courses",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Courses");
        }
    }
}
