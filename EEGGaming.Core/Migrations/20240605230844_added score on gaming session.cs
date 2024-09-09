using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EEGGaming.Core.Migrations
{
    /// <inheritdoc />
    public partial class addedscoreongamingsession : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Score",
                table: "GameSession",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Score",
                table: "GameSession");
        }
    }
}
