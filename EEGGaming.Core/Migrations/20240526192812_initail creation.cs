using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EEGGaming.Core.Migrations
{
    /// <inheritdoc />
    public partial class initailcreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BrainWaves",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    GamingSessionId = table.Column<int>(type: "INTEGER", nullable: false),
                    PackNumber = table.Column<uint>(type: "INTEGER", nullable: false),
                    Marker = table.Column<byte>(type: "INTEGER", nullable: false),
                    Date = table.Column<string>(type: "TEXT", nullable: false),
                    Time = table.Column<string>(type: "TEXT", nullable: false),
                    Second = table.Column<double>(type: "REAL", nullable: false),
                    MiliSecond = table.Column<double>(type: "REAL", nullable: false),
                    Delta = table.Column<double>(type: "REAL", nullable: false),
                    Theta = table.Column<double>(type: "REAL", nullable: false),
                    Alpha1 = table.Column<double>(type: "REAL", nullable: false),
                    Beta1 = table.Column<double>(type: "REAL", nullable: false),
                    Gamma1 = table.Column<double>(type: "REAL", nullable: false),
                    Delta_Rel = table.Column<double>(type: "REAL", nullable: false),
                    Theta_Rel = table.Column<double>(type: "REAL", nullable: false),
                    Alpha1_Rel = table.Column<double>(type: "REAL", nullable: false),
                    Beta1_Rel = table.Column<double>(type: "REAL", nullable: false),
                    Gamma1_Rel = table.Column<double>(type: "REAL", nullable: false),
                    Blinked = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrainWaves", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BrainWaves");
        }
    }
}
