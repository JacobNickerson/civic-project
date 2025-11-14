using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class LowercaseAllColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_auth_users_UserId",
                table: "auth");

            migrationBuilder.DropForeignKey(
                name: "FK_conversationmembers_conversations_UserId",
                table: "conversationmembers");

            migrationBuilder.DropForeignKey(
                name: "FK_conversationmembers_users_ConversationId",
                table: "conversationmembers");

            migrationBuilder.DropForeignKey(
                name: "FK_eventfollows_events_EventId",
                table: "eventfollows");

            migrationBuilder.DropForeignKey(
                name: "FK_eventfollows_users_UserId",
                table: "eventfollows");

            migrationBuilder.DropForeignKey(
                name: "FK_events_users_AuthorId",
                table: "events");

            migrationBuilder.DropForeignKey(
                name: "FK_messages_conversations_ConversationId",
                table: "messages");

            migrationBuilder.DropForeignKey(
                name: "FK_messages_users_SenderId",
                table: "messages");

            migrationBuilder.DropForeignKey(
                name: "FK_petitions_posts_Id",
                table: "petitions");

            migrationBuilder.DropForeignKey(
                name: "FK_petitionsignatures_petitions_PetitionId",
                table: "petitionsignatures");

            migrationBuilder.DropForeignKey(
                name: "FK_petitionsignatures_users_UserId",
                table: "petitionsignatures");

            migrationBuilder.DropForeignKey(
                name: "FK_postreactions_posts_PostId",
                table: "postreactions");

            migrationBuilder.DropForeignKey(
                name: "FK_postreactions_users_UserId",
                table: "postreactions");

            migrationBuilder.DropForeignKey(
                name: "FK_posts_users_UserId",
                table: "posts");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "users",
                newName: "username");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "users",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "users",
                newName: "createdat");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "users",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "posts",
                newName: "userid");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "posts",
                newName: "updatedat");

            migrationBuilder.RenameColumn(
                name: "IsOfficial",
                table: "posts",
                newName: "isofficial");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "posts",
                newName: "isdeleted");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "posts",
                newName: "createdat");

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "posts",
                newName: "content");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "posts",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_posts_UserId",
                table: "posts",
                newName: "IX_posts_userid");

            migrationBuilder.RenameColumn(
                name: "ReactionType",
                table: "postreactions",
                newName: "reactiontype");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "postreactions",
                newName: "createdat");

            migrationBuilder.RenameColumn(
                name: "PostId",
                table: "postreactions",
                newName: "postid");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "postreactions",
                newName: "userid");

            migrationBuilder.RenameIndex(
                name: "IX_postreactions_PostId",
                table: "postreactions",
                newName: "IX_postreactions_postid");

            migrationBuilder.RenameColumn(
                name: "PetitionId",
                table: "petitionsignatures",
                newName: "petitionid");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "petitionsignatures",
                newName: "userid");

            migrationBuilder.RenameIndex(
                name: "IX_petitionsignatures_PetitionId",
                table: "petitionsignatures",
                newName: "IX_petitionsignatures_petitionid");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "petitions",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "SignatureCount",
                table: "petitions",
                newName: "signaturecount");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "petitions",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "SenderId",
                table: "messages",
                newName: "senderid");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "messages",
                newName: "isdeleted");

            migrationBuilder.RenameColumn(
                name: "EditedAt",
                table: "messages",
                newName: "editedat");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "messages",
                newName: "createdat");

            migrationBuilder.RenameColumn(
                name: "ConversationId",
                table: "messages",
                newName: "conversationid");

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "messages",
                newName: "content");

            migrationBuilder.RenameColumn(
                name: "AttachmentUrl",
                table: "messages",
                newName: "attachmenturl");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "messages",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_messages_SenderId",
                table: "messages",
                newName: "IX_messages_senderid");

            migrationBuilder.RenameIndex(
                name: "IX_messages_ConversationId",
                table: "messages",
                newName: "IX_messages_conversationid");

            migrationBuilder.RenameColumn(
                name: "Visibility",
                table: "events",
                newName: "visibility");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "events",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "StartTime",
                table: "events",
                newName: "starttime");

            migrationBuilder.RenameColumn(
                name: "EndTime",
                table: "events",
                newName: "endtime");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "events",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "AuthorId",
                table: "events",
                newName: "authorid");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "events",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_events_AuthorId",
                table: "events",
                newName: "IX_events_authorid");

            migrationBuilder.RenameColumn(
                name: "IsNotified",
                table: "eventfollows",
                newName: "isnotified");

            migrationBuilder.RenameColumn(
                name: "EventId",
                table: "eventfollows",
                newName: "eventid");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "eventfollows",
                newName: "userid");

            migrationBuilder.RenameIndex(
                name: "IX_eventfollows_EventId",
                table: "eventfollows",
                newName: "IX_eventfollows_eventid");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "conversations",
                newName: "updatedat");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "conversations",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "conversations",
                newName: "createdat");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "conversations",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "LastReadMessageId",
                table: "conversationmembers",
                newName: "lastreadmessageid");

            migrationBuilder.RenameColumn(
                name: "JoinedAt",
                table: "conversationmembers",
                newName: "joinedat");

            migrationBuilder.RenameColumn(
                name: "ConversationId",
                table: "conversationmembers",
                newName: "conversationid");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "conversationmembers",
                newName: "userid");

            migrationBuilder.RenameIndex(
                name: "IX_conversationmembers_ConversationId",
                table: "conversationmembers",
                newName: "IX_conversationmembers_conversationid");

            migrationBuilder.RenameColumn(
                name: "PasswordSalt",
                table: "auth",
                newName: "passwordsalt");

            migrationBuilder.RenameColumn(
                name: "PasswordHash",
                table: "auth",
                newName: "passwordhash");

            migrationBuilder.RenameColumn(
                name: "LockUntil",
                table: "auth",
                newName: "lockuntil");

            migrationBuilder.RenameColumn(
                name: "LastLogin",
                table: "auth",
                newName: "lastlogin");

            migrationBuilder.RenameColumn(
                name: "FailedAttempts",
                table: "auth",
                newName: "failedattempts");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "auth",
                newName: "userid");

            migrationBuilder.AddForeignKey(
                name: "FK_auth_users_userid",
                table: "auth",
                column: "userid",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_conversationmembers_conversations_userid",
                table: "conversationmembers",
                column: "userid",
                principalTable: "conversations",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_conversationmembers_users_conversationid",
                table: "conversationmembers",
                column: "conversationid",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_eventfollows_events_eventid",
                table: "eventfollows",
                column: "eventid",
                principalTable: "events",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_eventfollows_users_userid",
                table: "eventfollows",
                column: "userid",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_events_users_authorid",
                table: "events",
                column: "authorid",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_messages_conversations_conversationid",
                table: "messages",
                column: "conversationid",
                principalTable: "conversations",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_messages_users_senderid",
                table: "messages",
                column: "senderid",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_petitions_posts_id",
                table: "petitions",
                column: "id",
                principalTable: "posts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_petitionsignatures_petitions_petitionid",
                table: "petitionsignatures",
                column: "petitionid",
                principalTable: "petitions",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_petitionsignatures_users_userid",
                table: "petitionsignatures",
                column: "userid",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_postreactions_posts_postid",
                table: "postreactions",
                column: "postid",
                principalTable: "posts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_postreactions_users_userid",
                table: "postreactions",
                column: "userid",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_posts_users_userid",
                table: "posts",
                column: "userid",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_auth_users_userid",
                table: "auth");

            migrationBuilder.DropForeignKey(
                name: "FK_conversationmembers_conversations_userid",
                table: "conversationmembers");

            migrationBuilder.DropForeignKey(
                name: "FK_conversationmembers_users_conversationid",
                table: "conversationmembers");

            migrationBuilder.DropForeignKey(
                name: "FK_eventfollows_events_eventid",
                table: "eventfollows");

            migrationBuilder.DropForeignKey(
                name: "FK_eventfollows_users_userid",
                table: "eventfollows");

            migrationBuilder.DropForeignKey(
                name: "FK_events_users_authorid",
                table: "events");

            migrationBuilder.DropForeignKey(
                name: "FK_messages_conversations_conversationid",
                table: "messages");

            migrationBuilder.DropForeignKey(
                name: "FK_messages_users_senderid",
                table: "messages");

            migrationBuilder.DropForeignKey(
                name: "FK_petitions_posts_id",
                table: "petitions");

            migrationBuilder.DropForeignKey(
                name: "FK_petitionsignatures_petitions_petitionid",
                table: "petitionsignatures");

            migrationBuilder.DropForeignKey(
                name: "FK_petitionsignatures_users_userid",
                table: "petitionsignatures");

            migrationBuilder.DropForeignKey(
                name: "FK_postreactions_posts_postid",
                table: "postreactions");

            migrationBuilder.DropForeignKey(
                name: "FK_postreactions_users_userid",
                table: "postreactions");

            migrationBuilder.DropForeignKey(
                name: "FK_posts_users_userid",
                table: "posts");

            migrationBuilder.RenameColumn(
                name: "username",
                table: "users",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "users",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "createdat",
                table: "users",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "userid",
                table: "posts",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "updatedat",
                table: "posts",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "isofficial",
                table: "posts",
                newName: "IsOfficial");

            migrationBuilder.RenameColumn(
                name: "isdeleted",
                table: "posts",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "createdat",
                table: "posts",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "content",
                table: "posts",
                newName: "Content");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "posts",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_posts_userid",
                table: "posts",
                newName: "IX_posts_UserId");

            migrationBuilder.RenameColumn(
                name: "reactiontype",
                table: "postreactions",
                newName: "ReactionType");

            migrationBuilder.RenameColumn(
                name: "createdat",
                table: "postreactions",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "postid",
                table: "postreactions",
                newName: "PostId");

            migrationBuilder.RenameColumn(
                name: "userid",
                table: "postreactions",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_postreactions_postid",
                table: "postreactions",
                newName: "IX_postreactions_PostId");

            migrationBuilder.RenameColumn(
                name: "petitionid",
                table: "petitionsignatures",
                newName: "PetitionId");

            migrationBuilder.RenameColumn(
                name: "userid",
                table: "petitionsignatures",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_petitionsignatures_petitionid",
                table: "petitionsignatures",
                newName: "IX_petitionsignatures_PetitionId");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "petitions",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "signaturecount",
                table: "petitions",
                newName: "SignatureCount");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "petitions",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "senderid",
                table: "messages",
                newName: "SenderId");

            migrationBuilder.RenameColumn(
                name: "isdeleted",
                table: "messages",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "editedat",
                table: "messages",
                newName: "EditedAt");

            migrationBuilder.RenameColumn(
                name: "createdat",
                table: "messages",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "conversationid",
                table: "messages",
                newName: "ConversationId");

            migrationBuilder.RenameColumn(
                name: "content",
                table: "messages",
                newName: "Content");

            migrationBuilder.RenameColumn(
                name: "attachmenturl",
                table: "messages",
                newName: "AttachmentUrl");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "messages",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_messages_senderid",
                table: "messages",
                newName: "IX_messages_SenderId");

            migrationBuilder.RenameIndex(
                name: "IX_messages_conversationid",
                table: "messages",
                newName: "IX_messages_ConversationId");

            migrationBuilder.RenameColumn(
                name: "visibility",
                table: "events",
                newName: "Visibility");

            migrationBuilder.RenameColumn(
                name: "title",
                table: "events",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "starttime",
                table: "events",
                newName: "StartTime");

            migrationBuilder.RenameColumn(
                name: "endtime",
                table: "events",
                newName: "EndTime");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "events",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "authorid",
                table: "events",
                newName: "AuthorId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "events",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_events_authorid",
                table: "events",
                newName: "IX_events_AuthorId");

            migrationBuilder.RenameColumn(
                name: "isnotified",
                table: "eventfollows",
                newName: "IsNotified");

            migrationBuilder.RenameColumn(
                name: "eventid",
                table: "eventfollows",
                newName: "EventId");

            migrationBuilder.RenameColumn(
                name: "userid",
                table: "eventfollows",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_eventfollows_eventid",
                table: "eventfollows",
                newName: "IX_eventfollows_EventId");

            migrationBuilder.RenameColumn(
                name: "updatedat",
                table: "conversations",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "title",
                table: "conversations",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "createdat",
                table: "conversations",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "conversations",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "lastreadmessageid",
                table: "conversationmembers",
                newName: "LastReadMessageId");

            migrationBuilder.RenameColumn(
                name: "joinedat",
                table: "conversationmembers",
                newName: "JoinedAt");

            migrationBuilder.RenameColumn(
                name: "conversationid",
                table: "conversationmembers",
                newName: "ConversationId");

            migrationBuilder.RenameColumn(
                name: "userid",
                table: "conversationmembers",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_conversationmembers_conversationid",
                table: "conversationmembers",
                newName: "IX_conversationmembers_ConversationId");

            migrationBuilder.RenameColumn(
                name: "passwordsalt",
                table: "auth",
                newName: "PasswordSalt");

            migrationBuilder.RenameColumn(
                name: "passwordhash",
                table: "auth",
                newName: "PasswordHash");

            migrationBuilder.RenameColumn(
                name: "lockuntil",
                table: "auth",
                newName: "LockUntil");

            migrationBuilder.RenameColumn(
                name: "lastlogin",
                table: "auth",
                newName: "LastLogin");

            migrationBuilder.RenameColumn(
                name: "failedattempts",
                table: "auth",
                newName: "FailedAttempts");

            migrationBuilder.RenameColumn(
                name: "userid",
                table: "auth",
                newName: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_auth_users_UserId",
                table: "auth",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_conversationmembers_conversations_UserId",
                table: "conversationmembers",
                column: "UserId",
                principalTable: "conversations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_conversationmembers_users_ConversationId",
                table: "conversationmembers",
                column: "ConversationId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_eventfollows_events_EventId",
                table: "eventfollows",
                column: "EventId",
                principalTable: "events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_eventfollows_users_UserId",
                table: "eventfollows",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_events_users_AuthorId",
                table: "events",
                column: "AuthorId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_messages_conversations_ConversationId",
                table: "messages",
                column: "ConversationId",
                principalTable: "conversations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_messages_users_SenderId",
                table: "messages",
                column: "SenderId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_petitions_posts_Id",
                table: "petitions",
                column: "Id",
                principalTable: "posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_petitionsignatures_petitions_PetitionId",
                table: "petitionsignatures",
                column: "PetitionId",
                principalTable: "petitions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_petitionsignatures_users_UserId",
                table: "petitionsignatures",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_postreactions_posts_PostId",
                table: "postreactions",
                column: "PostId",
                principalTable: "posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_postreactions_users_UserId",
                table: "postreactions",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_posts_users_UserId",
                table: "posts",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
