using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialProject.WebUI.Migrations
{
    public partial class _13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Notfications",
                table: "Notfications");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Notfications");

            migrationBuilder.AddColumn<int>(
                name: "NotficationId",
                table: "Notfications",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Notfications",
                table: "Notfications",
                column: "NotficationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Notfications",
                table: "Notfications");

            migrationBuilder.DropColumn(
                name: "NotficationId",
                table: "Notfications");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Notfications",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Notfications",
                table: "Notfications",
                column: "Id");
        }
    }
}
