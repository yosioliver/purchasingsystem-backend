using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace PurchasingSystemServices.Migrations
{
    public partial class AddTableOrder_OrderDetail_Product_Category_Balance_UserBalance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "category",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(maxLength: 200, nullable: false),
                    level = table.Column<int>(nullable: false),
                    parent_id = table.Column<int>(nullable: false),
                    active = table.Column<string>(type: "char", nullable: false),
                    create_by = table.Column<int>(nullable: false),
                    create_date = table.Column<DateTime>(nullable: false),
                    update_by = table.Column<int>(nullable: true),
                    update_date = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_category", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "order",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    order_number = table.Column<string>(maxLength: 10, nullable: false),
                    order_date = table.Column<DateTime>(nullable: false),
                    user_id = table.Column<int>(nullable: false),
                    invoice_number = table.Column<string>(maxLength: 10, nullable: false),
                    order_status = table.Column<string>(nullable: false),
                    grand_total = table.Column<long>(nullable: false),
                    create_by = table.Column<int>(nullable: false),
                    create_date = table.Column<DateTime>(nullable: false),
                    update_by = table.Column<int>(nullable: true),
                    update_date = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "order_detail",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    order_number = table.Column<string>(maxLength: 10, nullable: false),
                    item_id = table.Column<string>(nullable: false),
                    item_name = table.Column<string>(nullable: false),
                    order_quantity = table.Column<int>(nullable: false),
                    sub_total = table.Column<long>(nullable: false),
                    create_by = table.Column<int>(nullable: false),
                    create_date = table.Column<DateTime>(nullable: false),
                    update_by = table.Column<int>(nullable: true),
                    update_date = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order_detail", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "product",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(maxLength: 200, nullable: false),
                    category_id = table.Column<int>(nullable: false),
                    active = table.Column<string>(type: "char", nullable: false),
                    create_by = table.Column<int>(nullable: false),
                    create_date = table.Column<DateTime>(nullable: false),
                    update_by = table.Column<int>(nullable: true),
                    update_date = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "product_balance",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    product_id = table.Column<int>(nullable: false),
                    name = table.Column<string>(maxLength: 200, nullable: false),
                    balance_amount = table.Column<long>(nullable: false),
                    active = table.Column<string>(type: "char", nullable: false),
                    create_by = table.Column<int>(nullable: false),
                    create_date = table.Column<DateTime>(nullable: false),
                    update_by = table.Column<int>(nullable: true),
                    update_date = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_balance", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user_balance",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<int>(nullable: false),
                    balance_amount = table.Column<long>(nullable: false),
                    active = table.Column<string>(type: "char", nullable: false),
                    create_by = table.Column<int>(nullable: false),
                    create_date = table.Column<DateTime>(nullable: false),
                    update_by = table.Column<int>(nullable: true),
                    update_date = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_balance", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "category");

            migrationBuilder.DropTable(
                name: "order");

            migrationBuilder.DropTable(
                name: "order_detail");

            migrationBuilder.DropTable(
                name: "product");

            migrationBuilder.DropTable(
                name: "product_balance");

            migrationBuilder.DropTable(
                name: "user_balance");
        }
    }
}
