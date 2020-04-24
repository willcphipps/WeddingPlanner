using Microsoft.EntityFrameworkCore.Migrations;

namespace WeddingPlanner.Migrations
{
    public partial class seccond : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invetations_Users_AttendingUserId",
                table: "Invetations");

            migrationBuilder.DropForeignKey(
                name: "FK_Invetations_Weddings_EventWeddingId",
                table: "Invetations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Invetations",
                table: "Invetations");

            migrationBuilder.DropIndex(
                name: "IX_Invetations_AttendingUserId",
                table: "Invetations");

            migrationBuilder.DropIndex(
                name: "IX_Invetations_EventWeddingId",
                table: "Invetations");

            migrationBuilder.DropColumn(
                name: "AttendingUserId",
                table: "Invetations");

            migrationBuilder.DropColumn(
                name: "EventWeddingId",
                table: "Invetations");

            migrationBuilder.RenameTable(
                name: "Invetations",
                newName: "Invitations");

            migrationBuilder.RenameColumn(
                name: "WedId",
                table: "Invitations",
                newName: "WeddingId");

            migrationBuilder.RenameColumn(
                name: "UsId",
                table: "Invitations",
                newName: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Invitations",
                table: "Invitations",
                column: "InviteId");

            migrationBuilder.CreateIndex(
                name: "IX_Invitations_UserId",
                table: "Invitations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Invitations_WeddingId",
                table: "Invitations",
                column: "WeddingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invitations_Users_UserId",
                table: "Invitations",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Invitations_Weddings_WeddingId",
                table: "Invitations",
                column: "WeddingId",
                principalTable: "Weddings",
                principalColumn: "WeddingId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invitations_Users_UserId",
                table: "Invitations");

            migrationBuilder.DropForeignKey(
                name: "FK_Invitations_Weddings_WeddingId",
                table: "Invitations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Invitations",
                table: "Invitations");

            migrationBuilder.DropIndex(
                name: "IX_Invitations_UserId",
                table: "Invitations");

            migrationBuilder.DropIndex(
                name: "IX_Invitations_WeddingId",
                table: "Invitations");

            migrationBuilder.RenameTable(
                name: "Invitations",
                newName: "Invetations");

            migrationBuilder.RenameColumn(
                name: "WeddingId",
                table: "Invetations",
                newName: "WedId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Invetations",
                newName: "UsId");

            migrationBuilder.AddColumn<int>(
                name: "AttendingUserId",
                table: "Invetations",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EventWeddingId",
                table: "Invetations",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Invetations",
                table: "Invetations",
                column: "InviteId");

            migrationBuilder.CreateIndex(
                name: "IX_Invetations_AttendingUserId",
                table: "Invetations",
                column: "AttendingUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Invetations_EventWeddingId",
                table: "Invetations",
                column: "EventWeddingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invetations_Users_AttendingUserId",
                table: "Invetations",
                column: "AttendingUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Invetations_Weddings_EventWeddingId",
                table: "Invetations",
                column: "EventWeddingId",
                principalTable: "Weddings",
                principalColumn: "WeddingId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
