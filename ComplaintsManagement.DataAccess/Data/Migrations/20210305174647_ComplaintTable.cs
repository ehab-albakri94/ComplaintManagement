using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ComplaintsManagement.WebHost.Data.Migrations
{
    public partial class ComplaintTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ComplaintDetails",
                table: "Complaints",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ComplaintTime",
                table: "Complaints",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ComplaintType",
                table: "Complaints",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Complaints",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ComplaintDetails",
                table: "Complaints");

            migrationBuilder.DropColumn(
                name: "ComplaintTime",
                table: "Complaints");

            migrationBuilder.DropColumn(
                name: "ComplaintType",
                table: "Complaints");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Complaints");
        }
    }
}
