using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SelfieAWookie.API.UI.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class AddDecriptions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Selfie",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Selfie");
        }
    }
}
