using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class addnewfieldsToCreditCardsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CloseExtractDay",
                table: "CreditCards",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EntityNumber",
                table: "CreditCards",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RefNumber",
                table: "CreditCards",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CloseExtractDay",
                table: "CreditCards");

            migrationBuilder.DropColumn(
                name: "EntityNumber",
                table: "CreditCards");

            migrationBuilder.DropColumn(
                name: "RefNumber",
                table: "CreditCards");
        }
    }
}
