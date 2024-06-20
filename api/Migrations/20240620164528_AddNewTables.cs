using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class AddNewTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProxyId",
                table: "OSRSAccounts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_OSRSAccounts_ProxyId",
                table: "OSRSAccounts",
                column: "ProxyId");

            migrationBuilder.AddForeignKey(
                name: "FK_OSRSAccounts_OSRSProxies_ProxyId",
                table: "OSRSAccounts",
                column: "ProxyId",
                principalTable: "OSRSProxies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OSRSAccounts_OSRSProxies_ProxyId",
                table: "OSRSAccounts");

            migrationBuilder.DropIndex(
                name: "IX_OSRSAccounts_ProxyId",
                table: "OSRSAccounts");

            migrationBuilder.DropColumn(
                name: "ProxyId",
                table: "OSRSAccounts");
        }
    }
}
