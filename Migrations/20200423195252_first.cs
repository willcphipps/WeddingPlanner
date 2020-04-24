using Microsoft.EntityFrameworkCore.Migrations;

namespace WeddingPlanner.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreatorUserId",
                table: "Weddings",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Weddings_CreatorUserId",
                table: "Weddings",
                column: "CreatorUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Weddings_Users_CreatorUserId",
                table: "Weddings",
                column: "CreatorUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Weddings_Users_CreatorUserId",
                table: "Weddings");

            migrationBuilder.DropIndex(
                name: "IX_Weddings_CreatorUserId",
                table: "Weddings");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "Weddings");
        }
    }
}
