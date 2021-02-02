using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Wzh.AbpVnext.Migrations
{
    public partial class ArticleIMultiTenant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DeleterId",
                table: "AppArticles",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "AppArticles",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AppArticles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "TenantId",
                table: "AppArticles",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeleterId",
                table: "AppArticleCategories",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "AppArticleCategories",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AppArticleCategories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "TenantId",
                table: "AppArticleCategories",
                type: "uniqueidentifier",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeleterId",
                table: "AppArticles");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "AppArticles");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AppArticles");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "AppArticles");

            migrationBuilder.DropColumn(
                name: "DeleterId",
                table: "AppArticleCategories");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "AppArticleCategories");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AppArticleCategories");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "AppArticleCategories");
        }
    }
}
