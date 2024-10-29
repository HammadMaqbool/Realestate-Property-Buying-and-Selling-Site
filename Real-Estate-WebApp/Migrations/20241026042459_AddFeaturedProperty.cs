using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Real_Estate_WebApp.Migrations
{
    /// <inheritdoc />
    public partial class AddFeaturedProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Featured",
                table: "tbl_Property",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Featured",
                table: "tbl_Property");
        }
    }
}
