using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class updateprofileinfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProfileInformations_Departments_DepartmentId",
                table: "ProfileInformations");

            migrationBuilder.RenameColumn(
                name: "DepartmentId",
                table: "ProfileInformations",
                newName: "MyOrganizationId");

            migrationBuilder.RenameIndex(
                name: "IX_ProfileInformations_DepartmentId",
                table: "ProfileInformations",
                newName: "IX_ProfileInformations_MyOrganizationId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProfileInformations_MyOrganizations_MyOrganizationId",
                table: "ProfileInformations",
                column: "MyOrganizationId",
                principalTable: "MyOrganizations",
                principalColumn: "MyOrganizationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProfileInformations_MyOrganizations_MyOrganizationId",
                table: "ProfileInformations");

            migrationBuilder.RenameColumn(
                name: "MyOrganizationId",
                table: "ProfileInformations",
                newName: "DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_ProfileInformations_MyOrganizationId",
                table: "ProfileInformations",
                newName: "IX_ProfileInformations_DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProfileInformations_Departments_DepartmentId",
                table: "ProfileInformations",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "DepartmentId");
        }
    }
}
