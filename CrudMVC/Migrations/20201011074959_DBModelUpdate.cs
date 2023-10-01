using Microsoft.EntityFrameworkCore.Migrations;

namespace CrudMVC.Migrations
{
    public partial class DBModelUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "OrderDesc",
                table: "Orders",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<double>(
                name: "LineCost",
                table: "Orders",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "OrderCost",
                table: "Orders",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "SKUDescr",
                table: "Orders",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LineCost",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderCost",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "SKUDescr",
                table: "Orders");

            migrationBuilder.AlterColumn<string>(
                name: "OrderDesc",
                table: "Orders",
                type: "text",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
