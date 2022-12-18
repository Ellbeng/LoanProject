using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoanPoject.Data.Migrations
{
    /// <inheritdoc />
    public partial class test3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Loan_LoanID",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_LoanID",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LoanID",
                table: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Loan",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Loan_UserId",
                table: "Loan",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Loan_Users_UserId",
                table: "Loan",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Loan_Users_UserId",
                table: "Loan");

            migrationBuilder.DropIndex(
                name: "IX_Loan_UserId",
                table: "Loan");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Loan");

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LoanID",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Users_LoanID",
                table: "Users",
                column: "LoanID");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Loan_LoanID",
                table: "Users",
                column: "LoanID",
                principalTable: "Loan",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
