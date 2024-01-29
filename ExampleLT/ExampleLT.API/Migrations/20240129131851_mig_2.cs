using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExampleLT.API.Migrations
{
    /// <inheritdoc />
    public partial class mig_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IssueType",
                table: "Issues",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Priority",
                table: "Issues",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IssueType",
                table: "Issues");

            migrationBuilder.DropColumn(
                name: "Priority",
                table: "Issues");
        }
    }
}
