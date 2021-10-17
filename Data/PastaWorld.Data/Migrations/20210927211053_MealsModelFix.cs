using Microsoft.EntityFrameworkCore.Migrations;

namespace PastaWorld.Data.Migrations
{
    public partial class MealsModelFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Meals",
                newName: "ImageName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageName",
                table: "Meals",
                newName: "Image");
        }
    }
}
