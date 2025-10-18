using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class requestpagesrename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RequestPages",
                columns: table => new
                {
                    AdminPageRequestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    MyOrganizationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestPages", x => x.AdminPageRequestId);
                    table.ForeignKey(
                        name: "FK_RequestPages_MyOrganizations_MyOrganizationId",
                        column: x => x.MyOrganizationId,
                        principalTable: "MyOrganizations",
                        principalColumn: "MyOrganizationId");
                    table.ForeignKey(
                        name: "FK_RequestPages_Users_Id",
                        column: x => x.Id,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_RequestPages_Id",
                table: "RequestPages",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_RequestPages_MyOrganizationId",
                table: "RequestPages",
                column: "MyOrganizationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RequestPages");
        }
    }
}
