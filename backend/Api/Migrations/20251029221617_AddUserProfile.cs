using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class AddUserProfile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "name",
                table: "users");

            migrationBuilder.CreateTable(
                name: "userprofile",
                columns: table => new
                {
                    userid = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    pic = table.Column<string>(type: "text", nullable: true),
                    bio = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userprofile", x => x.userid);
                    table.ForeignKey(
                        name: "FK_userprofile_users_userid",
                        column: x => x.userid,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "userprofile");

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "users",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
