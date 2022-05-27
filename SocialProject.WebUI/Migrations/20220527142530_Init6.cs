using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialProject.WebUI.Migrations
{
    public partial class Init6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "ToUserId",
                table: "Notfications",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FromUserId",
                table: "Notfications",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Notfications_FromUserId",
                table: "Notfications",
                column: "FromUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Notfications_ToUserId",
                table: "Notfications",
                column: "ToUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notfications_AspNetUsers_FromUserId",
                table: "Notfications",
                column: "FromUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Notfications_AspNetUsers_ToUserId",
                table: "Notfications",
                column: "ToUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notfications_AspNetUsers_FromUserId",
                table: "Notfications");

            migrationBuilder.DropForeignKey(
                name: "FK_Notfications_AspNetUsers_ToUserId",
                table: "Notfications");

            migrationBuilder.DropIndex(
                name: "IX_Notfications_FromUserId",
                table: "Notfications");

            migrationBuilder.DropIndex(
                name: "IX_Notfications_ToUserId",
                table: "Notfications");

            migrationBuilder.AlterColumn<string>(
                name: "ToUserId",
                table: "Notfications",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FromUserId",
                table: "Notfications",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomIdentityUserId",
                table: "Notfications",
                type: "nvarchar(450)",
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
    }
}
