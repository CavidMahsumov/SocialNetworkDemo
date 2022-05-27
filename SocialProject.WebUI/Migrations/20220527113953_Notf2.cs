using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialProject.WebUI.Migrations
{
    public partial class Notf2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CustomIdentityUserId",
                table: "Notfications",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Notfications_CustomIdentityUserId",
                table: "Notfications",
                column: "CustomIdentityUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notfications_AspNetUsers_CustomIdentityUserId",
                table: "Notfications",
                column: "CustomIdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notfications_AspNetUsers_CustomIdentityUserId",
                table: "Notfications");

            migrationBuilder.DropIndex(
                name: "IX_Notfications_CustomIdentityUserId",
                table: "Notfications");

            migrationBuilder.DropColumn(
                name: "CustomIdentityUserId",
                table: "Notfications");
        }
    }
}
