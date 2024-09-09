using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EEGGaming.Core.Migrations
{
    /// <inheritdoc />
    public partial class removedmode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Mode",
                table: "GameSession");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Mode",
                table: "GameSession",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
