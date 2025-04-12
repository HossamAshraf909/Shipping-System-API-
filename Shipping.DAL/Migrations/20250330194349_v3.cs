using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shipping.DAL.Migrations
{
    /// <inheritdoc />
    public partial class v3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_villageDeliveries_VillageDeliveryId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DefaultPrice",
                table: "weightPrices");

            migrationBuilder.AlterColumn<int>(
                name: "VillageDeliveryId",
                table: "Orders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_villageDeliveries_VillageDeliveryId",
                table: "Orders",
                column: "VillageDeliveryId",
                principalTable: "villageDeliveries",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_villageDeliveries_VillageDeliveryId",
                table: "Orders");

            migrationBuilder.AddColumn<decimal>(
                name: "DefaultPrice",
                table: "weightPrices",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<int>(
                name: "VillageDeliveryId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_villageDeliveries_VillageDeliveryId",
                table: "Orders",
                column: "VillageDeliveryId",
                principalTable: "villageDeliveries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
