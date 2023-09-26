using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SelfieAWookie.API.UI.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModelSelfie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Selfie_Images_ImageId",
                table: "Selfie");

            migrationBuilder.AlterColumn<int>(
                name: "ImageId",
                table: "Selfie",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Selfie_Images_ImageId",
                table: "Selfie",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Selfie_Images_ImageId",
                table: "Selfie");

            migrationBuilder.AlterColumn<int>(
                name: "ImageId",
                table: "Selfie",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Selfie_Images_ImageId",
                table: "Selfie",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
