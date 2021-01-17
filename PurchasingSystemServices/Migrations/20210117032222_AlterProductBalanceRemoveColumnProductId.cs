using Microsoft.EntityFrameworkCore.Migrations;

namespace PurchasingSystemServices.Migrations
{
    public partial class AlterProductBalanceRemoveColumnProductId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "product_id",
                table: "product_balance");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "product_id",
                table: "product_balance",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
