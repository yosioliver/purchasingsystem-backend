using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PurchasingSystemServices.Migrations
{
    public partial class AlterTblDocNoAddAuditTrail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "create_by",
                table: "document_number",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "create_date",
                table: "document_number",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "update_by",
                table: "document_number",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "update_date",
                table: "document_number",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "create_by",
                table: "document_number");

            migrationBuilder.DropColumn(
                name: "create_date",
                table: "document_number");

            migrationBuilder.DropColumn(
                name: "update_by",
                table: "document_number");

            migrationBuilder.DropColumn(
                name: "update_date",
                table: "document_number");
        }
    }
}
