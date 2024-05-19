using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddedUniqueConstraints : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_RentalOffers_RentalTimeInMinutes_Price_Bicycle_Id",
                table: "RentalOffers",
                columns: new[] { "RentalTimeInMinutes", "Price", "Bicycle_Id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Parkings_StreetAdress_City_Id",
                table: "Parkings",
                columns: new[] { "StreetAdress", "City_Id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cities_Name",
                table: "Cities",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BicycleTypes_Name",
                table: "BicycleTypes",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_RentalOffers_RentalTimeInMinutes_Price_Bicycle_Id",
                table: "RentalOffers");

            migrationBuilder.DropIndex(
                name: "IX_Parkings_StreetAdress_City_Id",
                table: "Parkings");

            migrationBuilder.DropIndex(
                name: "IX_Cities_Name",
                table: "Cities");

            migrationBuilder.DropIndex(
                name: "IX_BicycleTypes_Name",
                table: "BicycleTypes");
        }
    }
}
