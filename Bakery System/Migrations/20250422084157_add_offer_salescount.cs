using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bakery_System.Migrations
{
    /// <inheritdoc />
    public partial class add_offer_salescount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Discount",
                table: "BakeryItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SalesCount",
                table: "BakeryItems",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discount",
                table: "BakeryItems");

            migrationBuilder.DropColumn(
                name: "SalesCount",
                table: "BakeryItems");
        }
    }
}
