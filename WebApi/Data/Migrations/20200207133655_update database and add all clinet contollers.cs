using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class updatedatabaseandaddallclinetcontollers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cash",
                table: "PrintingHouseWallets");

            migrationBuilder.DropColumn(
                name: "LicenseNumber",
                table: "PrintingHouses");

            migrationBuilder.AddColumn<string>(
                name: "Iban",
                table: "PrintingHouseWallets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DocumentsUrl",
                table: "PrintingHouses",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PrintingHouseWalletId",
                table: "PrintingHouses",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ServiceId",
                table: "Categories",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DescriptionId",
                table: "Categories",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "FullAddress",
                table: "Addresses",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Iban",
                table: "PrintingHouseWallets");

            migrationBuilder.DropColumn(
                name: "DocumentsUrl",
                table: "PrintingHouses");

            migrationBuilder.DropColumn(
                name: "PrintingHouseWalletId",
                table: "PrintingHouses");

            migrationBuilder.DropColumn(
                name: "DescriptionId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "FullAddress",
                table: "Addresses");

            migrationBuilder.AddColumn<double>(
                name: "Cash",
                table: "PrintingHouseWallets",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<long>(
                name: "LicenseNumber",
                table: "PrintingHouses",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<int>(
                name: "ServiceId",
                table: "Categories",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
