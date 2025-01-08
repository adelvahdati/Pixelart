using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pixelart.Orders.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Set_Some_New_Configuration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_CustomerId",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",
                table: "Customers");

            migrationBuilder.RenameTable(
                name: "Customers",
                newName: "Pixelart_Customers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pixelart_Customers",
                table: "Pixelart_Customers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Pixelart_Customers_CustomerId",
                table: "Orders",
                column: "CustomerId",
                principalTable: "Pixelart_Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Pixelart_Customers_CustomerId",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pixelart_Customers",
                table: "Pixelart_Customers");

            migrationBuilder.RenameTable(
                name: "Pixelart_Customers",
                newName: "Customers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                table: "Customers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_CustomerId",
                table: "Orders",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
