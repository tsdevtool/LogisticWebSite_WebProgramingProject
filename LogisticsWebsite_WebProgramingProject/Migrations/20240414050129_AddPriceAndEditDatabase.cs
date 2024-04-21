using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogisticsWebsite_WebProgramingProject.Migrations
{
    /// <inheritdoc />
    public partial class AddPriceAndEditDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_CostsIncurred",
                table: "Invoice");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Schedule",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<decimal>(
                name: "Surcharge",
                table: "Invoice",
                type: "money",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "money",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CostsIncurredID",
                table: "Invoice",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_CostsIncurred",
                table: "Invoice",
                column: "CostsIncurredID",
                principalTable: "CostsIncurred",
                principalColumn: "CostsIncurredID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_CostsIncurred",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Schedule");

            migrationBuilder.AlterColumn<decimal>(
                name: "Surcharge",
                table: "Invoice",
                type: "money",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "money");

            migrationBuilder.AlterColumn<int>(
                name: "CostsIncurredID",
                table: "Invoice",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_CostsIncurred",
                table: "Invoice",
                column: "CostsIncurredID",
                principalTable: "CostsIncurred",
                principalColumn: "CostsIncurredID");
        }
    }
}
