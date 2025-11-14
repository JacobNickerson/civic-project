using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class UniquenessConstraints : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_postreactions",
                table: "postreactions");

            migrationBuilder.DropIndex(
                name: "IX_postreactions_postid",
                table: "postreactions");

            migrationBuilder.DropIndex(
                name: "IX_eventfollows_eventid",
                table: "eventfollows");

            migrationBuilder.AddColumn<int>(
                name: "id",
                table: "postreactions",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_postreactions",
                table: "postreactions",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_postreactions_postid_userid_type",
                table: "postreactions",
                columns: new[] { "postid", "userid", "type" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_postreactions_userid",
                table: "postreactions",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "IX_eventfollows_eventid_userid",
                table: "eventfollows",
                columns: new[] { "eventid", "userid" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_conversationmembers_userid_conversationid",
                table: "conversationmembers",
                columns: new[] { "userid", "conversationid" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_postreactions",
                table: "postreactions");

            migrationBuilder.DropIndex(
                name: "IX_postreactions_postid_userid_type",
                table: "postreactions");

            migrationBuilder.DropIndex(
                name: "IX_postreactions_userid",
                table: "postreactions");

            migrationBuilder.DropIndex(
                name: "IX_eventfollows_eventid_userid",
                table: "eventfollows");

            migrationBuilder.DropIndex(
                name: "IX_conversationmembers_userid_conversationid",
                table: "conversationmembers");

            migrationBuilder.DropColumn(
                name: "id",
                table: "postreactions");

            migrationBuilder.AddPrimaryKey(
                name: "PK_postreactions",
                table: "postreactions",
                columns: new[] { "userid", "postid" });

            migrationBuilder.CreateIndex(
                name: "IX_postreactions_postid",
                table: "postreactions",
                column: "postid");

            migrationBuilder.CreateIndex(
                name: "IX_eventfollows_eventid",
                table: "eventfollows",
                column: "eventid");
        }
    }
}
