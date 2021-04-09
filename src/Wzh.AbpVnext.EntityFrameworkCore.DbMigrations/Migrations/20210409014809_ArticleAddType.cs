using Microsoft.EntityFrameworkCore.Migrations;

namespace Wzh.AbpVnext.Migrations
{
    public partial class ArticleAddType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "AppArticles",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "AppArticles");
        }
    }
}
