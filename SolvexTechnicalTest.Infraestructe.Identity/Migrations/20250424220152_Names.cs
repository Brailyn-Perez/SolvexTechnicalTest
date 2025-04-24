using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SolvexTechnicalTest.Infraestructe.Identity.Migrations
{
    /// <inheritdoc />
    public partial class Names : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "Identity",
                table: "Users",
                newName: "LastName");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                schema: "Identity",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                schema: "Identity",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "LastName",
                schema: "Identity",
                table: "Users",
                newName: "Name");
        }
    }
}
