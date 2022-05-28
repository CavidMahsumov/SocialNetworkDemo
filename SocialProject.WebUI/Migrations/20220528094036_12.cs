using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialProject.WebUI.Migrations
{
    public partial class _12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Friends_AspNetUsers_FriendId",
                table: "Friends");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Friends",
                table: "Friends");

            migrationBuilder.DropColumn(
                name: "FriendId",
                table: "Friends");

            migrationBuilder.AlterColumn<string>(
                name: "ReceiverId",
                table: "Friends",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Friends",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Friends",
                table: "Friends",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Friends_ReceiverId",
                table: "Friends",
                column: "ReceiverId");

            migrationBuilder.AddForeignKey(
                name: "FK_Friends_AspNetUsers_ReceiverId",
                table: "Friends",
                column: "ReceiverId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Friends_AspNetUsers_ReceiverId",
                table: "Friends");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Friends",
                table: "Friends");

            migrationBuilder.DropIndex(
                name: "IX_Friends_ReceiverId",
                table: "Friends");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Friends");

            migrationBuilder.AlterColumn<string>(
                name: "ReceiverId",
                table: "Friends",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FriendId",
                table: "Friends",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Friends",
                table: "Friends",
                column: "FriendId");

            migrationBuilder.AddForeignKey(
                name: "FK_Friends_AspNetUsers_FriendId",
                table: "Friends",
                column: "FriendId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
