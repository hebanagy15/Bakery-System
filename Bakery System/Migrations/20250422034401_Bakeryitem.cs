using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bakery_System.Migrations
{
    /// <inheritdoc />
    public partial class BakeryItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BakeryItems",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    QuantityInStock = table.Column<int>(type: "int", nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BakeryItems", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BakeryItems_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BakeryItems_CategoryId",
                table: "BakeryItems",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BakeryItems");
        }
    }
}
