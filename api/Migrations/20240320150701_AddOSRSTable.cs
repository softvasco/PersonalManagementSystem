using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class AddOSRSTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Attachment",
                table: "Credits");

            migrationBuilder.CreateTable(
                name: "OSRSWorlds",
                columns: table => new
                {
                    World = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsF2P = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OSRSWorlds", x => x.World);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OSRSWorlds");

            migrationBuilder.AddColumn<byte[]>(
                name: "Attachment",
                table: "Credits",
                type: "varbinary(max)",
                nullable: true);
        }
    }
}
