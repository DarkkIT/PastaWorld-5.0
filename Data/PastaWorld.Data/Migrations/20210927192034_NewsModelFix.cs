using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PastaWorld.Data.Migrations
{
    public partial class NewsModelFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PublishDate",
                table: "News",
                newName: "NewsDate");

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "News",
                newName: "ImageName");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "News",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "News",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "News",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "News",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "News",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_News_ApplicationUserId",
                table: "News",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_News_IsDeleted",
                table: "News",
                column: "IsDeleted");

            migrationBuilder.AddForeignKey(
                name: "FK_News_AspNetUsers_ApplicationUserId",
                table: "News",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_News_AspNetUsers_ApplicationUserId",
                table: "News");

            migrationBuilder.DropIndex(
                name: "IX_News_ApplicationUserId",
                table: "News");

            migrationBuilder.DropIndex(
                name: "IX_News_IsDeleted",
                table: "News");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "News");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "News");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "News");

            migrationBuilder.RenameColumn(
                name: "NewsDate",
                table: "News",
                newName: "PublishDate");

            migrationBuilder.RenameColumn(
                name: "ImageName",
                table: "News",
                newName: "Image");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "News",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "News",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
