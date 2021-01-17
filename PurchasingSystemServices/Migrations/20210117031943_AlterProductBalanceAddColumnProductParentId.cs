using Microsoft.EntityFrameworkCore.Migrations;

namespace PurchasingSystemServices.Migrations
{
    public partial class AlterProductBalanceAddColumnProductParentId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "product_parent_id",
                table: "product_balance",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "product_parent_id",
                table: "product_balance");
        }
    }
}
