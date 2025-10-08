using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class user_profile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ProfileInformationId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_ProfileInformationId",
                table: "Users",
                column: "ProfileInformationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_ProfileInformations_ProfileInformationId",
                table: "Users",
                column: "ProfileInformationId",
                principalTable: "ProfileInformations",
                principalColumn: "ProfileInformationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_ProfileInformations_ProfileInformationId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_ProfileInformationId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ProfileInformationId",
                table: "Users");
        }
    }
}
