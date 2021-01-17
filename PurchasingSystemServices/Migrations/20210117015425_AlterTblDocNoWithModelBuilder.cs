using Microsoft.EntityFrameworkCore.Migrations;

namespace PurchasingSystemServices.Migrations
{
    public partial class AlterTblDocNoWithModelBuilder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "code",
                table: "document_number",
                type: "char(3)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "char",
                oldMaxLength: 3);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "code",
                table: "document_number",
                type: "char",
                maxLength: 3,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "char(3)");
        }
    }
}
