using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shipping.DAL.Migrations
{
    /// <inheritdoc />
    public partial class RelationDeliveryAndBranch : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Branch",
                table: "Deliveries");

            migrationBuilder.DropColumn(
                name: "Governorate",
                table: "Deliveries");

            migrationBuilder.AddColumn<int>(
                name: "governorateId",
                table: "Deliveries",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Deliveries_governorateId",
                table: "Deliveries",
                column: "governorateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Deliveries_governorates_governorateId",
                table: "Deliveries",
                column: "governorateId",
                principalTable: "governorates",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deliveries_governorates_governorateId",
                table: "Deliveries");

            migrationBuilder.DropIndex(
                name: "IX_Deliveries_governorateId",
                table: "Deliveries");

            migrationBuilder.DropColumn(
                name: "governorateId",
                table: "Deliveries");

            migrationBuilder.AddColumn<string>(
                name: "Branch",
                table: "Deliveries",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Governorate",
                table: "Deliveries",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}
