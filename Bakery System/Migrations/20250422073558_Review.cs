using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bakery_System.Migrations
{
    /// <inheritdoc />
    public partial class Review : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItem_BakeryItems_BakeryItemId",
                table: "OrderItem");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItem_Orders_OrderId",
                table: "OrderItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderItem",
                table: "OrderItem");

            migrationBuilder.RenameTable(
                name: "OrderItem",
                newName: "OrderItems");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItem_OrderId",
                table: "OrderItems",
                newName: "IX_OrderItems_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItem_BakeryItemId",
                table: "OrderItems",
                newName: "IX_OrderItems_BakeryItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderItems",
                table: "OrderItems",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    BakeryItemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_BakeryItems_BakeryItemId",
                        column: x => x.BakeryItemId,
                        principalTable: "BakeryItems",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_BakeryItemId",
                table: "Reviews",
                column: "BakeryItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_CustomerId",
                table: "Reviews",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_BakeryItems_BakeryItemId",
                table: "OrderItems",
                column: "BakeryItemId",
                principalTable: "BakeryItems",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Orders_OrderId",
                table: "OrderItems",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_BakeryItems_BakeryItemId",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Orders_OrderId",
                table: "OrderItems");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderItems",
                table: "OrderItems");

            migrationBuilder.RenameTable(
                name: "OrderItems",
                newName: "OrderItem");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItem",
                newName: "IX_OrderItem_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItems_BakeryItemId",
                table: "OrderItem",
                newName: "IX_OrderItem_BakeryItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderItem",
                table: "OrderItem",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItem_BakeryItems_BakeryItemId",
                table: "OrderItem",
                column: "BakeryItemId",
                principalTable: "BakeryItems",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItem_Orders_OrderId",
                table: "OrderItem",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
