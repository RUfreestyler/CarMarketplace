using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarMarketplace.Migrations
{
    public partial class PurchaseRequestsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PurchaseRequests",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    City = table.Column<string>(type: "TEXT", nullable: false),
                    Make = table.Column<string>(type: "TEXT", nullable: false),
                    Model = table.Column<string>(type: "TEXT", nullable: false),
                    YearOfManufactureLowerBound = table.Column<int>(type: "INTEGER", nullable: false),
                    YearOfManufactureUpperBound = table.Column<int>(type: "INTEGER", nullable: false),
                    EnginePowerLowerBound = table.Column<int>(type: "INTEGER", nullable: false),
                    EnginePowerUpperBound = table.Column<int>(type: "INTEGER", nullable: false),
                    KilometrageLowerBound = table.Column<int>(type: "INTEGER", nullable: false),
                    KilometrageUpperBound = table.Column<int>(type: "INTEGER", nullable: false),
                    Transmission = table.Column<int>(type: "INTEGER", nullable: false),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    PriceLowerBound = table.Column<decimal>(type: "TEXT", nullable: false),
                    PriceUpperBound = table.Column<decimal>(type: "TEXT", nullable: false),
                    OwnerID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseRequests", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PurchaseRequests");
        }
    }
}
