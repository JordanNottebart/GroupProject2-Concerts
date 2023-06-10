using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CENV_JMH.DA.Migrations
{
    /// <inheritdoc />
    public partial class SeedHallAndShowingUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Hall_Table",
                columns: new[] { "Hall_ID", "Max_Number_Places", "Name_Hall", "Number_Hall" },
                values: new object[,]
                {
                    { 5, 111, "Sapphire Palace", 5 },
                    { 6, 78, "Elliot", 6 }
                });

            migrationBuilder.UpdateData(
                table: "Showing",
                keyColumn: "Showing_ID",
                keyValue: 4,
                column: "Ticket_Price",
                value: 29.989999999999998);

            migrationBuilder.InsertData(
                table: "Showing",
                columns: new[] { "Showing_ID", "Name_Showing", "Picture_URL", "Ticket_Price" },
                values: new object[,]
                {
                    { 5, "Royal Plam Concert", "", 89.989999999999995 },
                    { 6, "Original Music Mantra", "", 69.989999999999995 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Hall_Table",
                keyColumn: "Hall_ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Hall_Table",
                keyColumn: "Hall_ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Showing",
                keyColumn: "Showing_ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Showing",
                keyColumn: "Showing_ID",
                keyValue: 6);

            migrationBuilder.UpdateData(
                table: "Showing",
                keyColumn: "Showing_ID",
                keyValue: 4,
                column: "Ticket_Price",
                value: 219.99000000000001);
        }
    }
}
