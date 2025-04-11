using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shipping.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddMerchentRelationWithCity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "specialPackages",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "merchantID",
                table: "specialPackages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Merchants",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "cityId",
                table: "Merchants",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "governrateId",
                table: "Merchants",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Branch",
                table: "Employees",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Employees",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserRole",
                table: "Employees",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "password",
                table: "Employees",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Deliveries",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_specialPackages_merchantID",
                table: "specialPackages",
                column: "merchantID");

            migrationBuilder.CreateIndex(
                name: "IX_Merchants_cityId",
                table: "Merchants",
                column: "cityId");

            migrationBuilder.CreateIndex(
                name: "IX_Merchants_governrateId",
                table: "Merchants",
                column: "governrateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Merchants_Cities_cityId",
                table: "Merchants",
                column: "cityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Merchants_governorates_governrateId",
                table: "Merchants",
                column: "governrateId",
                principalTable: "governorates",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_specialPackages_Merchants_merchantID",
                table: "specialPackages",
                column: "merchantID",
                principalTable: "Merchants",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Merchants_Cities_cityId",
                table: "Merchants");

            migrationBuilder.DropForeignKey(
                name: "FK_Merchants_governorates_governrateId",
                table: "Merchants");

            migrationBuilder.DropForeignKey(
                name: "FK_specialPackages_Merchants_merchantID",
                table: "specialPackages");

            migrationBuilder.DropIndex(
                name: "IX_specialPackages_merchantID",
                table: "specialPackages");

            migrationBuilder.DropIndex(
                name: "IX_Merchants_cityId",
                table: "Merchants");

            migrationBuilder.DropIndex(
                name: "IX_Merchants_governrateId",
                table: "Merchants");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "specialPackages");

            migrationBuilder.DropColumn(
                name: "merchantID",
                table: "specialPackages");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Merchants");

            migrationBuilder.DropColumn(
                name: "cityId",
                table: "Merchants");

            migrationBuilder.DropColumn(
                name: "governrateId",
                table: "Merchants");

            migrationBuilder.DropColumn(
                name: "Branch",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "UserRole",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "password",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Branch",
                table: "Deliveries");

            migrationBuilder.DropColumn(
                name: "Governorate",
                table: "Deliveries");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Deliveries");
        }
    }
}
