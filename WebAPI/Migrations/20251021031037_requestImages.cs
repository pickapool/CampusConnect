using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class requestImages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PageRequestImages",
                columns: table => new
                {
                    PageRequestImageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AdminPageRequestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PageRequestImages", x => x.PageRequestImageId);
                    table.ForeignKey(
                        name: "FK_PageRequestImages_RequestPages_AdminPageRequestId",
                        column: x => x.AdminPageRequestId,
                        principalTable: "RequestPages",
                        principalColumn: "AdminPageRequestId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PageRequestImages_AdminPageRequestId",
                table: "PageRequestImages",
                column: "AdminPageRequestId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PageRequestImages");
        }
    }
}
