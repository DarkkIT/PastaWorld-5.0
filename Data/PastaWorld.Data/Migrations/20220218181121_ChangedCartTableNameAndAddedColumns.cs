using Microsoft.EntityFrameworkCore.Migrations;

namespace PastaWorld.Data.Migrations
{
    public partial class ChangedCartTableNameAndAddedColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItem_Carts_CartId",
                table: "CartItem");

            migrationBuilder.RenameColumn(
                name: "CartId",
                table: "CartItem",
                newName: "OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_CartItem_CartId",
                table: "CartItem",
                newName: "IX_CartItem_OrderId");

            migrationBuilder.AddColumn<string>(
                name: "CliendId",
                table: "Carts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ClientId",
                table: "Carts",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Carts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FamilyName",
                table: "Carts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Carts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "MealsPrice",
                table: "Carts",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Carts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Carts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPrice",
                table: "Carts",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_Carts_ClientId",
                table: "Carts",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItem_Carts_OrderId",
                table: "CartItem",
                column: "OrderId",
                principalTable: "Carts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_AspNetUsers_ClientId",
                table: "Carts",
                column: "ClientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItem_Carts_OrderId",
                table: "CartItem");

            migrationBuilder.DropForeignKey(
                name: "FK_Carts_AspNetUsers_ClientId",
                table: "Carts");

            migrationBuilder.DropIndex(
                name: "IX_Carts_ClientId",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "CliendId",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "FamilyName",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "MealsPrice",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "Carts");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "CartItem",
                newName: "CartId");

            migrationBuilder.RenameIndex(
                name: "IX_CartItem_OrderId",
                table: "CartItem",
                newName: "IX_CartItem_CartId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItem_Carts_CartId",
                table: "CartItem",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
