using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Wzh.AbpVnext.Migrations
{
    public partial class ArticleFileId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImgUrl",
                table: "AppArticles");

            migrationBuilder.AddColumn<Guid>(
                name: "ImgId",
                table: "AppArticles",
                type: "uniqueidentifier",
                maxLength: 510,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImgId",
                table: "AppArticles");

            migrationBuilder.AddColumn<string>(
                name: "ImgUrl",
                table: "AppArticles",
                type: "nvarchar(510)",
                maxLength: 510,
                nullable: true);
        }
    }
}
