using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pixelart.Orders.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Add_Family_Column_to_Customer_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Family",
                table: "Customers",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Family",
                table: "Customers");
        }
    }
}
