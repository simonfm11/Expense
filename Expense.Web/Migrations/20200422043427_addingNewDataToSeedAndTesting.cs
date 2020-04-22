using Microsoft.EntityFrameworkCore.Migrations;

namespace Expense.Web.Migrations
{
    public partial class addingNewDataToSeedAndTesting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PicturePath",
                table: "UserEntity",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserType",
                table: "UserEntity",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PicturePath",
                table: "UserEntity");

            migrationBuilder.DropColumn(
                name: "UserType",
                table: "UserEntity");
        }
    }
}
