using Microsoft.EntityFrameworkCore.Migrations;

namespace CrudMVC.Migrations
{
    public partial class ProductnOrderUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PartDesc",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "PartNo",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "PartNo",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "AvailableQty",
                table: "Products",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Products",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "SKU",
                table: "Products",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "SKU",
                table: "Orders",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Orders",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvailableQty",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SKU",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SKU",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Orders");

            migrationBuilder.AddColumn<string>(
                name: "PartDesc",
                table: "Products",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PartNo",
                table: "Products",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PartNo",
                table: "Orders",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
