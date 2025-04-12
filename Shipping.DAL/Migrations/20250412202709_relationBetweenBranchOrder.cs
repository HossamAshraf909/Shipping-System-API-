using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shipping.DAL.Migrations
{
    /// <inheritdoc />
    public partial class relationBetweenBranchOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "branchId",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_branchId",
                table: "Orders",
                column: "branchId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Branches_branchId",
                table: "Orders",
                column: "branchId",
                principalTable: "Branches",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Branches_branchId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_branchId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "branchId",
                table: "Orders");
        }
    }
}
