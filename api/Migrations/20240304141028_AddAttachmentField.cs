using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class AddAttachmentField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FileContent",
                table: "GiftCards",
                newName: "Attachment");

            migrationBuilder.RenameColumn(
                name: "FileContent",
                table: "Credits",
                newName: "Attachment");

            migrationBuilder.RenameColumn(
                name: "FileContent",
                table: "BankAccounts",
                newName: "Attachment");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Attachment",
                table: "GiftCards",
                newName: "FileContent");

            migrationBuilder.RenameColumn(
                name: "Attachment",
                table: "Credits",
                newName: "FileContent");

            migrationBuilder.RenameColumn(
                name: "Attachment",
                table: "BankAccounts",
                newName: "FileContent");
        }
    }
}
