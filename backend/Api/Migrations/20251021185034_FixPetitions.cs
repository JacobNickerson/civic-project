using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class FixPetitions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_petitions_users_UserId1",
                table: "petitions");

            migrationBuilder.DropIndex(
                name: "IX_petitions_UserId1",
                table: "petitions");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "petitions");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "petitions",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_petitions_UserId1",
                table: "petitions",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_petitions_users_UserId1",
                table: "petitions",
                column: "UserId1",
                principalTable: "users",
                principalColumn: "Id");
        }
    }
}
