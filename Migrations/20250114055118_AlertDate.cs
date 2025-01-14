using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SportsScheduleProLibrary.Migrations
{
    public partial class AlertDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "AlertDate",
                table: "Alert",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AlertType",
                table: "Alert",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Alert",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Message",
                table: "Alert",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AlertDate",
                table: "Alert");

            migrationBuilder.DropColumn(
                name: "AlertType",
                table: "Alert");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Alert");

            migrationBuilder.DropColumn(
                name: "Message",
                table: "Alert");
        }
    }
}
