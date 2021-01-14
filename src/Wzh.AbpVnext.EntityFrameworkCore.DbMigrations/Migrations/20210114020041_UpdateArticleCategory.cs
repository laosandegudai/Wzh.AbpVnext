using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Wzh.AbpVnext.Migrations
{
    public partial class UpdateArticleCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "AppArticleCategories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatorId",
                table: "AppArticleCategories",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "AppArticleCategories",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LastModifierId",
                table: "AppArticleCategories",
                type: "uniqueidentifier",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "AppArticleCategories");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "AppArticleCategories");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "AppArticleCategories");

            migrationBuilder.DropColumn(
                name: "LastModifierId",
                table: "AppArticleCategories");
        }
    }
}
