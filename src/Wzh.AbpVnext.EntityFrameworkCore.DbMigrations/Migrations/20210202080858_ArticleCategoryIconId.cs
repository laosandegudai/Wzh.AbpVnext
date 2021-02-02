using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Wzh.AbpVnext.Migrations
{
    public partial class ArticleCategoryIconId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "IconId",
                table: "AppArticleCategories",
                type: "uniqueidentifier",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IconId",
                table: "AppArticleCategories");
        }
    }
}
