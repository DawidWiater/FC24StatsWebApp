using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FC24StatsWebApp.Migrations
{
    /// <inheritdoc />
    public partial class AddPointsToResult : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Points",
                table: "Results",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Points",
                table: "Results");
        }
    }
}
