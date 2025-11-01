using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class ParentPost : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "parentid",
                table: "posts",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "parentpostid",
                table: "posts",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_posts_parentpostid",
                table: "posts",
                column: "parentpostid");

            migrationBuilder.AddForeignKey(
                name: "FK_posts_posts_parentpostid",
                table: "posts",
                column: "parentpostid",
                principalTable: "posts",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_posts_posts_parentpostid",
                table: "posts");

            migrationBuilder.DropIndex(
                name: "IX_posts_parentpostid",
                table: "posts");

            migrationBuilder.DropColumn(
                name: "parentid",
                table: "posts");

            migrationBuilder.DropColumn(
                name: "parentpostid",
                table: "posts");
        }
    }
}
