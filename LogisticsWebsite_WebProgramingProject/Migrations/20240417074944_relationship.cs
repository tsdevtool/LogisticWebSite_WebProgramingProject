using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogisticsWebsite_WebProgramingProject.Migrations
{
    /// <inheritdoc />
    public partial class relationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_CostsIncurred",
                table: "Invoice");

            migrationBuilder.AlterColumn<int>(
                name: "CostsIncurredID",
                table: "Invoice",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "BookingInfomation",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_BookingInfomation_UserID",
                table: "BookingInfomation",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingInfomation_AspNetUsers_UserID",
                table: "BookingInfomation",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_CostsIncurred",
                table: "Invoice",
                column: "CostsIncurredID",
                principalTable: "CostsIncurred",
                principalColumn: "CostsIncurredID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingInfomation_AspNetUsers_UserID",
                table: "BookingInfomation");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_CostsIncurred",
                table: "Invoice");

            migrationBuilder.DropIndex(
                name: "IX_BookingInfomation_UserID",
                table: "BookingInfomation");

            migrationBuilder.AlterColumn<int>(
                name: "CostsIncurredID",
                table: "Invoice",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "BookingInfomation",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_CostsIncurred",
                table: "Invoice",
                column: "CostsIncurredID",
                principalTable: "CostsIncurred",
                principalColumn: "CostsIncurredID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
