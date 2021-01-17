using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace PurchasingSystemServices.Migrations
{
    public partial class removeProductBalanceTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "product_balance");

            migrationBuilder.AddColumn<long>(
                name: "balance_amount",
                table: "product",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<int>(
                name: "product_parent_id",
                table: "product",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "balance_amount",
                table: "product");

            migrationBuilder.DropColumn(
                name: "product_parent_id",
                table: "product");

            migrationBuilder.CreateTable(
                name: "product_balance",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    active = table.Column<string>(type: "char", nullable: false),
                    balance_amount = table.Column<long>(type: "bigint", nullable: false),
                    create_by = table.Column<int>(type: "integer", nullable: false),
                    create_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    product_parent_id = table.Column<int>(type: "integer", nullable: false),
                    update_by = table.Column<int>(type: "integer", nullable: true),
                    update_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_balance", x => x.id);
                });
        }
    }
}
