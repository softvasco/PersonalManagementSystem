using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class FixProxyRequirement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OSRSAccounts_OSRSProxies_ProxyId",
                table: "OSRSAccounts");

            migrationBuilder.AlterColumn<int>(
                name: "ProxyId",
                table: "OSRSAccounts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_OSRSAccounts_OSRSProxies_ProxyId",
                table: "OSRSAccounts",
                column: "ProxyId",
                principalTable: "OSRSProxies",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OSRSAccounts_OSRSProxies_ProxyId",
                table: "OSRSAccounts");

            migrationBuilder.AlterColumn<int>(
                name: "ProxyId",
                table: "OSRSAccounts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OSRSAccounts_OSRSProxies_ProxyId",
                table: "OSRSAccounts",
                column: "ProxyId",
                principalTable: "OSRSProxies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
