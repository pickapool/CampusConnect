using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class updates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "OrganizationDepartmentId",
                table: "MyOrganizations",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "OrganizationDepartments",
                columns: table => new
                {
                    OrganizationDepartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MyOrganizationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationDepartments", x => x.OrganizationDepartmentId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MyOrganizations_OrganizationDepartmentId",
                table: "MyOrganizations",
                column: "OrganizationDepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_MyOrganizations_OrganizationDepartments_OrganizationDepartmentId",
                table: "MyOrganizations",
                column: "OrganizationDepartmentId",
                principalTable: "OrganizationDepartments",
                principalColumn: "OrganizationDepartmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MyOrganizations_OrganizationDepartments_OrganizationDepartmentId",
                table: "MyOrganizations");

            migrationBuilder.DropTable(
                name: "OrganizationDepartments");

            migrationBuilder.DropIndex(
                name: "IX_MyOrganizations_OrganizationDepartmentId",
                table: "MyOrganizations");

            migrationBuilder.DropColumn(
                name: "OrganizationDepartmentId",
                table: "MyOrganizations");
        }
    }
}
