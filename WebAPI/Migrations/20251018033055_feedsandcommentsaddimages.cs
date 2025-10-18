using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class feedsandcommentsaddimages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NewsFeeds",
                columns: table => new
                {
                    NewsFeedId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MyOrganizationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsFeeds", x => x.NewsFeedId);
                    table.ForeignKey(
                        name: "FK_NewsFeeds_MyOrganizations_MyOrganizationId",
                        column: x => x.MyOrganizationId,
                        principalTable: "MyOrganizations",
                        principalColumn: "MyOrganizationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NewsFeedComments",
                columns: table => new
                {
                    NewsFeedCommentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NewsFeedId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ParentCommentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    NewsFeedCommentModelNewsFeedCommentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsFeedComments", x => x.NewsFeedCommentId);
                    table.ForeignKey(
                        name: "FK_NewsFeedComments_NewsFeedComments_NewsFeedCommentModelNewsFeedCommentId",
                        column: x => x.NewsFeedCommentModelNewsFeedCommentId,
                        principalTable: "NewsFeedComments",
                        principalColumn: "NewsFeedCommentId");
                    table.ForeignKey(
                        name: "FK_NewsFeedComments_NewsFeeds_NewsFeedId",
                        column: x => x.NewsFeedId,
                        principalTable: "NewsFeeds",
                        principalColumn: "NewsFeedId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NewsFeedComments_Users_Id",
                        column: x => x.Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NewsFeedImages",
                columns: table => new
                {
                    NewsFeedImageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImageData = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    NewsFeedId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsFeedImages", x => x.NewsFeedImageId);
                    table.ForeignKey(
                        name: "FK_NewsFeedImages_NewsFeeds_NewsFeedId",
                        column: x => x.NewsFeedId,
                        principalTable: "NewsFeeds",
                        principalColumn: "NewsFeedId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NewsFeedComments_Id",
                table: "NewsFeedComments",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_NewsFeedComments_NewsFeedCommentModelNewsFeedCommentId",
                table: "NewsFeedComments",
                column: "NewsFeedCommentModelNewsFeedCommentId");

            migrationBuilder.CreateIndex(
                name: "IX_NewsFeedComments_NewsFeedId",
                table: "NewsFeedComments",
                column: "NewsFeedId");

            migrationBuilder.CreateIndex(
                name: "IX_NewsFeedImages_NewsFeedId",
                table: "NewsFeedImages",
                column: "NewsFeedId");

            migrationBuilder.CreateIndex(
                name: "IX_NewsFeeds_MyOrganizationId",
                table: "NewsFeeds",
                column: "MyOrganizationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NewsFeedComments");

            migrationBuilder.DropTable(
                name: "NewsFeedImages");

            migrationBuilder.DropTable(
                name: "NewsFeeds");
        }
    }
}
