using Microsoft.EntityFrameworkCore.Migrations;

namespace ComplaintsManagement.WebHost.Data.Migrations
{
    public partial class addUrgent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsUrgent",
                table: "Complaints",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsUrgent",
                table: "Complaints");
        }
    }
}
