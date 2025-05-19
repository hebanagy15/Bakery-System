using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bakery_System.Migrations
{
    /// <inheritdoc />
    public partial class testtt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemName",
                table: "Orders");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ItemName",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
