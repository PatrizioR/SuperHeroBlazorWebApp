using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SuperHeroBlazorWebApp.Server.Migrations
{
    /// <inheritdoc />
    public partial class MoviesNavigation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MovieIds",
                table: "SuperHeroes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MovieIds",
                table: "SuperHeroes",
                type: "TEXT",
                nullable: true);
        }
    }
}
