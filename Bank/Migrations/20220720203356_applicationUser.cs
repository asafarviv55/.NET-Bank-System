using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bank.Migrations
{
    public partial class applicationUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Loans_AspNetUsers_ownerId",
                table: "Loans");

            migrationBuilder.DropIndex(
                name: "IX_Loans_ownerId",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "ownerId",
                table: "Loans");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Loans",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Loans_UserId",
                table: "Loans",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Loans_AspNetUsers_UserId",
                table: "Loans",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Loans_AspNetUsers_UserId",
                table: "Loans");

            migrationBuilder.DropIndex(
                name: "IX_Loans_UserId",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Loans");

            migrationBuilder.AddColumn<string>(
                name: "ownerId",
                table: "Loans",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Loans_ownerId",
                table: "Loans",
                column: "ownerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Loans_AspNetUsers_ownerId",
                table: "Loans",
                column: "ownerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
