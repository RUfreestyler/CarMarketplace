using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarMarketplace.Migrations
{
    public partial class CarsOwnersUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TechnicalState",
                table: "Cars");

            migrationBuilder.RenameColumn(
                name: "Caption",
                table: "Advertisements",
                newName: "Title");

            migrationBuilder.AddColumn<int>(
                name: "PasswordHash",
                table: "Owners",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Transmission",
                table: "Cars",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<string>(
                name: "Kilometrage",
                table: "Cars",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Cars",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Owners");

            migrationBuilder.DropColumn(
                name: "Kilometrage",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Cars");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Advertisements",
                newName: "Caption");

            migrationBuilder.AlterColumn<string>(
                name: "Transmission",
                table: "Cars",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<string>(
                name: "TechnicalState",
                table: "Cars",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
