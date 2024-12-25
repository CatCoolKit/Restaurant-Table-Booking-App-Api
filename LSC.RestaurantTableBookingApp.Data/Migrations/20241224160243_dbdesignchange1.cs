using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LSC.RestaurantTableBookingApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class dbdesignchange1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SeatsName",
                table: "DiningTables",
                newName: "TableName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TableName",
                table: "DiningTables",
                newName: "SeatsName");
        }
    }
}
