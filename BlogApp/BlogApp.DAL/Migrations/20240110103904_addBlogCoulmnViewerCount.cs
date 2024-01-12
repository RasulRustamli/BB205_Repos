using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogApp.DAL.Migrations
{
    public partial class addBlogCoulmnViewerCount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "Blogs",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "Getutcdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 1, 8, 10, 48, 30, 208, DateTimeKind.Utc).AddTicks(6210));

            migrationBuilder.AddColumn<int>(
                name: "ViewerCount",
                table: "Blogs",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ViewerCount",
                table: "Blogs");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "Blogs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 8, 10, 48, 30, 208, DateTimeKind.Utc).AddTicks(6210),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "Getutcdate()");
        }
    }
}
