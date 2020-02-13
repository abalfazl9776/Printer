using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class testthirtytwo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPayed",
                table: "Payments",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "PaymentDate",
                table: "Payments",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<double>(
                name: "TotalPrice",
                table: "Orders",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<int>(
                name: "PriceId",
                table: "OrderLines",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CategoryBasePrices",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false),
                    PrintingHouseId = table.Column<int>(nullable: false),
                    CategoryPrice = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryBasePrices", x => new { x.CategoryId, x.PrintingHouseId });
                });

            migrationBuilder.CreateTable(
                name: "ColorBasePrices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Color = table.Column<string>(nullable: true),
                    ColorPer = table.Column<double>(nullable: false),
                    PrintingHouseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColorBasePrices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QuantityBasePrices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(nullable: false),
                    QuantityPer = table.Column<double>(nullable: false),
                    PrintingHouseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuantityBasePrices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoundedCornerBasePrices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoundedCorner = table.Column<bool>(nullable: false),
                    RoundedCornerPer = table.Column<double>(nullable: false),
                    PrintingHouseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoundedCornerBasePrices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SizeBasePrices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Size = table.Column<string>(nullable: true),
                    SizePer = table.Column<double>(nullable: false),
                    PrintingHouseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SizeBasePrices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Prices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuantityBasePriceId = table.Column<int>(nullable: false),
                    ColorBasePriceId = table.Column<int>(nullable: false),
                    SizeBasePriceId = table.Column<int>(nullable: false),
                    RoundedCornerBasePriceId = table.Column<int>(nullable: false),
                    CategoryBasePriceId = table.Column<int>(nullable: false),
                    CategoryBasePriceCategoryId = table.Column<int>(nullable: false),
                    CategoryBasePricePrintingHouseId = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    PrintingHouseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prices_ColorBasePrices_ColorBasePriceId",
                        column: x => x.ColorBasePriceId,
                        principalTable: "ColorBasePrices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Prices_QuantityBasePrices_QuantityBasePriceId",
                        column: x => x.QuantityBasePriceId,
                        principalTable: "QuantityBasePrices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Prices_RoundedCornerBasePrices_RoundedCornerBasePriceId",
                        column: x => x.RoundedCornerBasePriceId,
                        principalTable: "RoundedCornerBasePrices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Prices_SizeBasePrices_SizeBasePriceId",
                        column: x => x.SizeBasePriceId,
                        principalTable: "SizeBasePrices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Prices_CategoryBasePrices_CategoryBasePriceCategoryId_CategoryBasePricePrintingHouseId",
                        columns: x => new { x.CategoryBasePriceCategoryId, x.CategoryBasePricePrintingHouseId },
                        principalTable: "CategoryBasePrices",
                        principalColumns: new[] { "CategoryId", "PrintingHouseId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderLines_PriceId",
                table: "OrderLines",
                column: "PriceId");

            migrationBuilder.CreateIndex(
                name: "IX_Prices_ColorBasePriceId",
                table: "Prices",
                column: "ColorBasePriceId");

            migrationBuilder.CreateIndex(
                name: "IX_Prices_QuantityBasePriceId",
                table: "Prices",
                column: "QuantityBasePriceId");

            migrationBuilder.CreateIndex(
                name: "IX_Prices_RoundedCornerBasePriceId",
                table: "Prices",
                column: "RoundedCornerBasePriceId");

            migrationBuilder.CreateIndex(
                name: "IX_Prices_SizeBasePriceId",
                table: "Prices",
                column: "SizeBasePriceId");

            migrationBuilder.CreateIndex(
                name: "IX_Prices_CategoryBasePriceCategoryId_CategoryBasePricePrintingHouseId",
                table: "Prices",
                columns: new[] { "CategoryBasePriceCategoryId", "CategoryBasePricePrintingHouseId" });

            migrationBuilder.AddForeignKey(
                name: "FK_OrderLines_Prices_PriceId",
                table: "OrderLines",
                column: "PriceId",
                principalTable: "Prices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderLines_Prices_PriceId",
                table: "OrderLines");

            migrationBuilder.DropTable(
                name: "Prices");

            migrationBuilder.DropTable(
                name: "ColorBasePrices");

            migrationBuilder.DropTable(
                name: "QuantityBasePrices");

            migrationBuilder.DropTable(
                name: "RoundedCornerBasePrices");

            migrationBuilder.DropTable(
                name: "SizeBasePrices");

            migrationBuilder.DropTable(
                name: "CategoryBasePrices");

            migrationBuilder.DropIndex(
                name: "IX_OrderLines_PriceId",
                table: "OrderLines");

            migrationBuilder.DropColumn(
                name: "IsPayed",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "PaymentDate",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "PriceId",
                table: "OrderLines");

            migrationBuilder.AlterColumn<long>(
                name: "TotalPrice",
                table: "Orders",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(double));
        }
    }
}
