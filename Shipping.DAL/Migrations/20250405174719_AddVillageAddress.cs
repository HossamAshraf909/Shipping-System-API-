using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shipping.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddVillageAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "VillageStreetAddress",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VillageStreetAddress",
                table: "Orders");
        }
    }
}
