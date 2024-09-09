using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EEGGaming.Core.Migrations
{
    /// <inheritdoc />
    public partial class chnagedtobrainwaveemodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Theta_Rel",
                table: "BrainWaves",
                newName: "Theta_ch2");

            migrationBuilder.RenameColumn(
                name: "Theta",
                table: "BrainWaves",
                newName: "Theta_ch1");

            migrationBuilder.RenameColumn(
                name: "Gamma1_Rel",
                table: "BrainWaves",
                newName: "Theta_avgch");

            migrationBuilder.RenameColumn(
                name: "Gamma1",
                table: "BrainWaves",
                newName: "Theta_Rel_ch2");

            migrationBuilder.RenameColumn(
                name: "Delta_Rel",
                table: "BrainWaves",
                newName: "Theta_Rel_ch1");

            migrationBuilder.RenameColumn(
                name: "Delta",
                table: "BrainWaves",
                newName: "Theta_Rel_avgch");

            migrationBuilder.RenameColumn(
                name: "Beta1_Rel",
                table: "BrainWaves",
                newName: "Gamma1_ch2");

            migrationBuilder.RenameColumn(
                name: "Beta1",
                table: "BrainWaves",
                newName: "Gamma1_ch1");

            migrationBuilder.RenameColumn(
                name: "Alpha1_Rel",
                table: "BrainWaves",
                newName: "Gamma1_avgch");

            migrationBuilder.RenameColumn(
                name: "Alpha1",
                table: "BrainWaves",
                newName: "Gamma1_Rel_ch2");

            migrationBuilder.AddColumn<double>(
                name: "Alpha1_Rel_avgch",
                table: "BrainWaves",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Alpha1_Rel_ch1",
                table: "BrainWaves",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Alpha1_Rel_ch2",
                table: "BrainWaves",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Alpha1_avgch",
                table: "BrainWaves",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Alpha1_ch1",
                table: "BrainWaves",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Alpha1_ch2",
                table: "BrainWaves",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Beta1_Rel_avgch",
                table: "BrainWaves",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Beta1_Rel_ch1",
                table: "BrainWaves",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Beta1_Rel_ch2",
                table: "BrainWaves",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Beta1_avgch",
                table: "BrainWaves",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Beta1_ch1",
                table: "BrainWaves",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Beta1_ch2",
                table: "BrainWaves",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Delta_Rel_avgch",
                table: "BrainWaves",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Delta_Rel_ch1",
                table: "BrainWaves",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Delta_Rel_ch2",
                table: "BrainWaves",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Delta_avgch",
                table: "BrainWaves",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Delta_ch1",
                table: "BrainWaves",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Delta_ch2",
                table: "BrainWaves",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Gamma1_Rel_avgch",
                table: "BrainWaves",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Gamma1_Rel_ch1",
                table: "BrainWaves",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Alpha1_Rel_avgch",
                table: "BrainWaves");

            migrationBuilder.DropColumn(
                name: "Alpha1_Rel_ch1",
                table: "BrainWaves");

            migrationBuilder.DropColumn(
                name: "Alpha1_Rel_ch2",
                table: "BrainWaves");

            migrationBuilder.DropColumn(
                name: "Alpha1_avgch",
                table: "BrainWaves");

            migrationBuilder.DropColumn(
                name: "Alpha1_ch1",
                table: "BrainWaves");

            migrationBuilder.DropColumn(
                name: "Alpha1_ch2",
                table: "BrainWaves");

            migrationBuilder.DropColumn(
                name: "Beta1_Rel_avgch",
                table: "BrainWaves");

            migrationBuilder.DropColumn(
                name: "Beta1_Rel_ch1",
                table: "BrainWaves");

            migrationBuilder.DropColumn(
                name: "Beta1_Rel_ch2",
                table: "BrainWaves");

            migrationBuilder.DropColumn(
                name: "Beta1_avgch",
                table: "BrainWaves");

            migrationBuilder.DropColumn(
                name: "Beta1_ch1",
                table: "BrainWaves");

            migrationBuilder.DropColumn(
                name: "Beta1_ch2",
                table: "BrainWaves");

            migrationBuilder.DropColumn(
                name: "Delta_Rel_avgch",
                table: "BrainWaves");

            migrationBuilder.DropColumn(
                name: "Delta_Rel_ch1",
                table: "BrainWaves");

            migrationBuilder.DropColumn(
                name: "Delta_Rel_ch2",
                table: "BrainWaves");

            migrationBuilder.DropColumn(
                name: "Delta_avgch",
                table: "BrainWaves");

            migrationBuilder.DropColumn(
                name: "Delta_ch1",
                table: "BrainWaves");

            migrationBuilder.DropColumn(
                name: "Delta_ch2",
                table: "BrainWaves");

            migrationBuilder.DropColumn(
                name: "Gamma1_Rel_avgch",
                table: "BrainWaves");

            migrationBuilder.DropColumn(
                name: "Gamma1_Rel_ch1",
                table: "BrainWaves");

            migrationBuilder.RenameColumn(
                name: "Theta_ch2",
                table: "BrainWaves",
                newName: "Theta_Rel");

            migrationBuilder.RenameColumn(
                name: "Theta_ch1",
                table: "BrainWaves",
                newName: "Theta");

            migrationBuilder.RenameColumn(
                name: "Theta_avgch",
                table: "BrainWaves",
                newName: "Gamma1_Rel");

            migrationBuilder.RenameColumn(
                name: "Theta_Rel_ch2",
                table: "BrainWaves",
                newName: "Gamma1");

            migrationBuilder.RenameColumn(
                name: "Theta_Rel_ch1",
                table: "BrainWaves",
                newName: "Delta_Rel");

            migrationBuilder.RenameColumn(
                name: "Theta_Rel_avgch",
                table: "BrainWaves",
                newName: "Delta");

            migrationBuilder.RenameColumn(
                name: "Gamma1_ch2",
                table: "BrainWaves",
                newName: "Beta1_Rel");

            migrationBuilder.RenameColumn(
                name: "Gamma1_ch1",
                table: "BrainWaves",
                newName: "Beta1");

            migrationBuilder.RenameColumn(
                name: "Gamma1_avgch",
                table: "BrainWaves",
                newName: "Alpha1_Rel");

            migrationBuilder.RenameColumn(
                name: "Gamma1_Rel_ch2",
                table: "BrainWaves",
                newName: "Alpha1");
        }
    }
}
